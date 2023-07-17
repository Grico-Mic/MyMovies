using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class 
    {
        public T GetById(int entityId);
         List<T> GetAll();
        void Create(T newEntity);
        void Delete(T entity);
        void Update(T entity);
    }
}
