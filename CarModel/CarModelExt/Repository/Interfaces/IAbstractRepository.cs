using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CarModelExt.Repository.Interfaces;

namespace CarModelExt.Repository.Interfaces
{
    public interface IAbstractRepository<T> where T : class, IBasicEntity
    {
        void Create(T entity);
        void Delete(T entity);
        void Edit(T entity);
        List<T> GetWhere(Expression<Func<T, bool>> expression);
    }
}