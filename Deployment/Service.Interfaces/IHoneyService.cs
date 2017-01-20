using System.ServiceModel;

namespace Service.Interfaces
{
    [ServiceContract]
    public interface IHoneyService
    {
        [OperationContract]
        string Echo(string message);

        [OperationContract]
        ImageFileDTO GetImageFile(string path);
    }
}
