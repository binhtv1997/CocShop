using System;
using System.Collections.Generic;
using System.Text;

namespace CocShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        CocShopDBContext Init();
    }
}
