using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocShop.Model
{
    public class MyUser : IdentityUser
    {
        public string FullName { get; set; }
        public string CardNumber { get; set; }
    }
}
