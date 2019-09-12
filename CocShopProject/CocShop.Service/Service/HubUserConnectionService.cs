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
    public interface IHubUserConnectionService
    {
        IQueryable<HubUserConnection> GetHubUserConnections();
        IQueryable<HubUserConnection> GetHubUserConnections(Expression<Func<HubUserConnection, bool>> where);
        HubUserConnection GetHubUserConnection(Guid Id);
        void CreateHubUserConnection(HubUserConnection HubUserConnection);
        void UpdateHubUserConnection(HubUserConnection HubUserConnection);
        void DeleteHubUserConnection(HubUserConnection HubUserConnection);
        void DeleteHubUserConnection(Expression<Func<HubUserConnection, bool>> where);
        void Save();
    }
    public class HubUserConnectionService : IHubUserConnectionService
    {
        private readonly IHubUserConnectionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public HubUserConnectionService(IHubUserConnectionRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void CreateHubUserConnection(HubUserConnection HubUserConnection)
        {
            _repository.Add(HubUserConnection);
        }

        public void DeleteHubUserConnection(HubUserConnection HubUserConnection)
        {
            _repository.Delete(HubUserConnection);
        }

        public void DeleteHubUserConnection(Expression<Func<HubUserConnection, bool>> where)
        {
            var HubUserConnections = _repository.GetMany(where);
            HubUserConnections.ToList().ForEach(e =>
            {
                _repository.Delete(e);
            });
        }

        public HubUserConnection GetHubUserConnection(Guid id)
        {
            return _repository.GetById(id);
        }

        public IQueryable<HubUserConnection> GetHubUserConnections()
        {
            return _repository.GetAll();
        }

        public IQueryable<HubUserConnection> GetHubUserConnections(Expression<Func<HubUserConnection, bool>> where)
        {
            return _repository.GetMany(where);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void UpdateHubUserConnection(HubUserConnection HubUserConnection)
        {
            _repository.Update(HubUserConnection);
        }
    }
}
