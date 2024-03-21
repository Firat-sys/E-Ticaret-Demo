using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApplication.Expections
{
    public class NotFoundUserExpection:Exception
    {
        public NotFoundUserExpection() : base("Kullanıcı adı veya şifre hatalı!")
        {

        }

        public NotFoundUserExpection(string? message) : base(message)
        {
        }

        public NotFoundUserExpection(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
