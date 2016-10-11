using System.Collections.Generic;

namespace PhotosSearchWPF.Model
{
    public class Library
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DirectoryPath { get; set; }

        public bool ExistsOnDisk { get; set; }

        public List<Image> Images { get; set; } 
    }
}
