using CocShop.Data.Infrastructure;
using CocShop.Data.Repositories;
using CocShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CocShop.Service.Service
{
    public interface INotificationService
    {
        IQueryable<Notification> GetNotifications();
        IQueryable<Notification> GetNotifications(Expression<Func<Notification, bool>> where);
        Notification GetNotification(Guid Id);
        void CreateNotification(Notification Notification);
        void UpdateNotification(Notification Notification);
        void DeleteNotification(Notification Notification);
        void DeleteNotification(Expression<Func<Notification, bool>> where);
        void Save();
    }
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(INotificationRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void CreateNotification(Notification Notification)
        {
            _repository.Add(Notification);
        }

        public void DeleteNotification(Notification Notification)
        {
            _repository.Delete(Notification);
        }

        public void DeleteNotification(Expression<Func<Notification, bool>> where)
        {
            _repository.Delete(where);
        }

        public Notification GetNotification(Guid id)
        {
            return _repository.GetById(id);
        }

        public IQueryable<Notification> GetNotifications()
        {
            return _repository.GetAll();
        }

        public IQueryable<Notification> GetNotifications(Expression<Func<Notification, bool>> where)
        {
            return _repository.GetMany(where);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void UpdateNotification(Notification Notification)
        {
            _repository.Update(Notification);
        }
    }
}
