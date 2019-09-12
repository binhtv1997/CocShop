using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CocShopProject.Ultis
{
    public enum UserRoles
    {
        [Display(Name = "Quản lý tài khoản")]
        Admin = 0,
        [Display(Name = "Nhân viên")]
        Staff = 1,
        [Display(Name = "Khách Hàng")]
        User = 2,
    }
}
