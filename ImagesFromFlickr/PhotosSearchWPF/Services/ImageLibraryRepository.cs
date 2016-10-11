using System.Collections.Generic;
using PhotosSearchWPF.Model;
using LiteDB;
using PhotosSearchWPF.Data;
using System.Linq;

namespace PhotosSearchWPF.Services
{
    public class ImageLibraryRepository : IImageLibraryRepository
    {
        public ImageLibraryRepository()
        {
            var mapper = BsonMapper.Global;

            // Ignore ExistsOnDisk fields??

            mapper.Entity<Library>()
                  .DbRef(l => l.Images, "images")
                  .Index(l => l.Id);

            mapper.Entity<Image>()
                  .Index(i => i.Id);
        }

        public Image AddImageToLibrary(int libraryId, Image image)
        {
            using (var db = new ImageLibraryContext())
            {
                var libraryAddingTo = db.Libraries()
                                        .Include(lib => lib.Images)
                                        .Find(lib => lib.Id == libraryId).First();

                image.Library = new Library { Id = libraryAddingTo.Id };
                db.Images().Insert(image);
                libraryAddingTo.Images.Add(image);
                db.Libraries().Update(libraryAddingTo);

                return image;
            }
        }

        public Library AddLibrary(Library library)
        {
            using (var db = new ImageLibraryContext())
            {
                var libraryInserted = db.Libraries()
                                        .Insert(library);

                library.Id = libraryInserted;
                return library;
            }
        }

        public List<Image> GetImagesOfLibrary(int libraryId)
        {
            using (var db = new ImageLibraryContext())
            {
                var library = db.Libraries()
                                .Include(lib => lib.Images)
                                .Find(lib => lib.Id == libraryId).First();

                return library.Images;
            }
        }

        public List<Library> GetLibrariesWithoutImages()
        {
            using (var db = new ImageLibraryContext())
            {
                return db.Libraries().FindAll().ToList();
            }
        }

        public Library RemoveImageFromLibrary(int libraryId, int imageId)
        {
            using (var db = new ImageLibraryContext())
            {
                var libraryRemovingFrom = db.Libraries()
                                            .Include(lib => lib.Images)
                                            .Find(lib => lib.Id == libraryId)
                                            .First();

                libraryRemovingFrom.Images.RemoveAll(img => img.Id == imageId);
                db.Libraries().Update(libraryRemovingFrom);

                db.Images().Delete(img => img.Id == imageId);

                return libraryRemovingFrom;
            }
        }

        public void RemoveLibrary(int libraryId)
        {
            using (var db = new ImageLibraryContext())
            {
                var libraryRemoving = db.Libraries()
                                        .Include(lib => lib.Images)
                                        .Find(lib => lib.Id == libraryId)
                                        .First();

                libraryRemoving.Images?.ForEach(img => db.Images().Delete(i => i.Id == img.Id));

                db.Libraries().Delete(lib => lib.Id == libraryRemoving.Id);
            }
        }
    }
}
