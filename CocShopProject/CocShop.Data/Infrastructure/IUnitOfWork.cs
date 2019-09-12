using System;
using System.Collections.Generic;
using System.Text;

namespace CocShop.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
