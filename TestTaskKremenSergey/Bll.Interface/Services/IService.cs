using System;
using System.Collections.Generic;

namespace Bll.Interface.Services
{
    //abstract interface for service in business logic layer
    //here are represented CRUD operations without update as we dont need it in abstract service
    public interface IService<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int key);
        void Create(TEntity entity);
        void Delete(TEntity entity);
    }
}
