using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi_Domain.Entitys.Commen
{
    public class BaseEntitys
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
       virtual public DateTime UpdateDate { get; set; }
    }
}
