using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using CarModelExt.Repository.Interfaces;

namespace CarModelExt.Repository.Interfaces
{
    public interface IAbstractRepository<T> where T : class, IBasicEntity
    {
        void Create(T entity);
        [Authorize]
        void Delete(T entity);
        void Edit(T entity);
        List<T> GetWhere(Expression<Func<T, bool>> expression);
    }
}