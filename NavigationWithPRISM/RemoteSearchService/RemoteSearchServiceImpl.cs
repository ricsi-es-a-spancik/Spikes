using System;
using System.Threading.Tasks;
using Business;
using NavigationWithPRISM.Infrastructure.ServiceInterfaces;
using System.Linq;
using System.Collections.Generic;

namespace RemoteSearchService
{
    public class RemoteSearchServiceImpl : IRemoteSearchService
    {
        public async Task<List<RemoteItem>> Search(string searchCriteria)
        {
            return await Task.Run(() =>
            {
                Task.Delay(TimeSpan.FromSeconds(5)).Wait();
                return Enumerable.Range(0, 10).Select(i => new RemoteItem { Id = i, Content = Guid.NewGuid().ToString() }).ToList();
            });
        }
    }
}
