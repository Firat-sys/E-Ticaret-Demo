using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApplication.Expections
{
    public class UserCreateFailedExection:Exception
    {
        public UserCreateFailedExection():base("Kullanıcı oluşturulurken bir hata oldu!")
        {
            
        }

        public UserCreateFailedExection(string? message) : base(message)
        {
        }

        public UserCreateFailedExection(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
