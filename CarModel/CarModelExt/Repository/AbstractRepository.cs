using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq.Expressions;
using CarModelExt.Models;
using CarModelExt.Repository.Interfaces;

namespace CarModelExt.Repository
{
    public abstract class AbstractRepository<T> : IAbstractRepository<T> where T: class, IBasicEntity
    {

        public virtual void Create(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                entity.DateCreate = DateTime.Now;
                entity.DateMod = DateTime.Now;
                entity.IsActive = true;
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public virtual void Edit(T entity)
        {
            
            using (var context = new ApplicationDbContext())
            {
                entity.DateMod = DateTime.Now;
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual void Delete(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                entity.IsActive = false;
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual List<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context.Set<T>().Where(expression);
                return query.ToList();
            }
        }
    }
}