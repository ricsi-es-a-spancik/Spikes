using Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NavigationWithPRISM.Infrastructure.ServiceInterfaces
{
    public interface IRemoteSearchService
    {
        Task<List<RemoteItem>> Search(string searchCriteria);
    }
}
