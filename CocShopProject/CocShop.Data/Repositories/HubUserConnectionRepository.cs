using CocShop.Data.Infrastructure;
using CocShop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocShop.Data.Repositories
{
    public interface IHubUserConnectionRepository : IRepository<HubUserConnection>
    {

    }

    public class HubUserConnectionRepository : RepositoryBase<HubUserConnection>, IHubUserConnectionRepository
    {
        public HubUserConnectionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
