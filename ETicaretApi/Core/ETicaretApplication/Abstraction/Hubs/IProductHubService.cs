using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApplication.Abstraction.Hubs
{
    public interface IProductHubService
    {
        public Task IProductAddMessageAsync(string message);
    }
}
