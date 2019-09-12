using CocShop.Data.Infrastructure;
using CocShop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocShop.Data.Repositories
{
    public interface INotificationRepository : IRepository<Notification>
    {

    }

    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
