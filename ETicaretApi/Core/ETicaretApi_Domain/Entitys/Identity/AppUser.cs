﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi_Domain.Entitys.Identity
{
    public class AppUser:IdentityUser<string>
    {
        public string NameSurName { get; set; }
    }
}
