using ETicaretApi_Domain.Entitys.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApplication.Abstraction.Token
{
    public interface ITokenHandler
    {
        DTOS.Token CreateAccessToken(int minute);

    }
}
