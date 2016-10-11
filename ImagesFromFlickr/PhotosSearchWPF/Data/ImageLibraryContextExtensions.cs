using LiteDB;
using PhotosSearchWPF.Model;

namespace PhotosSearchWPF.Data
{
    public static class ImageLibraryContextExtensions
    {
        public static LiteCollection<Library> Libraries(this ImageLibraryContext context)
        {
            return context.GetCollection<Library>("libraries");
        }

        public static LiteCollection<Image> Images(this ImageLibraryContext context)
        {
            return context.GetCollection<Image>("images");
        }
    }
}
