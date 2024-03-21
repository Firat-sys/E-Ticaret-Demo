using ETicaretApplication.Abstraction.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.API.SignalR.HubServices
{
    public class ProductHubService : IProductHubService
    {
        public Task IProductAddMessageAsync(string message)
        {
            throw new NotImplementedException();
        }
    }
}
