using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocShop.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace CocShopProject.Hubs
{
    public class CenterHub : Hub
    {
        private IHttpContextAccessor _contextAccessor;
        private readonly UserManager<MyUser> _userManager;
        //private readonly IHubUserConnectionService _hubService;
        private HttpContext _context { get { return _contextAccessor.HttpContext; } }
    }
}
