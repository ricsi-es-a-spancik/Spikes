using Service.Interfaces;

namespace Service.Implementation
{
    public class HoneyServiceImpl : IHoneyService
    {
        public string Echo(string message)
        {
            return message;
        }

        public ImageFileDTO GetImageFile(string path)
        {
            return new ImageFileDTO
            {
                Width = 0,
                Height = 0,
                NumberOfChannnels = 0,
                Data = new byte[] { }
            };
        }
    }
}
