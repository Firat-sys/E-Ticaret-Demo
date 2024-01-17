using ETicaretApi_Domain.Entitys.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi_Domain.Entitys
{
    public class Customer:BaseEntitys
    {
        public String Name  { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
