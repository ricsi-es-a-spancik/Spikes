using System.Runtime.Serialization;

namespace Service.Interfaces
{
    [DataContract]
    public class ImageFileDTO
    {
        [DataMember]
        public int Width { get; set; }

        [DataMember]
        public int Height { get; set; }

        [DataMember]
        public int NumberOfChannnels { get; set; }

        [DataMember]
        public byte[] Data { get; set; }
    }
}