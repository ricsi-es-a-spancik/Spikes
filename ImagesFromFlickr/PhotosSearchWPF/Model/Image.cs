namespace PhotosSearchWPF.Model
{
    public class Image
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool ExistsOnDisk { get; set; }

        public string FilePath { get; set; }

        public Library Library { get; set; }
    }
}