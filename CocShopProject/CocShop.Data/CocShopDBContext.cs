using CocShop.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocShop.Data
{
    public class CocShopDBContext : IdentityDbContext<MyUser>
    {
        public CocShopDBContext() : base((new DbContextOptionsBuilder())
        .UseLazyLoadingProxies()
        .UseSqlServer(@"Server=.;Database=CocShop;user id=sa;password=1;Trusted_Connection=True;Integrated Security=false;")
        .Options)
        {
        }

        public DbSet<HubUserConnection> HubUserConnections { get; set; }
        public DbSet<Notification> Notifications { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public void Commit()
        {
            base.SaveChanges();
        }
    }
}
