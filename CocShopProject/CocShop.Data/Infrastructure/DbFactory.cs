using System;
using System.Collections.Generic;
using System.Text;

namespace CocShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        CocShopDBContext dbContext;

        public CocShopDBContext Init()
        {
            return dbContext ?? (dbContext = new CocShopDBContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
