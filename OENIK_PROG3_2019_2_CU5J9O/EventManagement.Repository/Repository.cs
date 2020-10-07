using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventManagement.Repository
{
    public abstract class Repository<T> : IRepository<T> where T: class
    {
        protected DbContext ctx;

        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        public abstract T GetOne(int id);

        public void Insert(T entity)
        {
            this.ctx.Set<T>().Add(entity);
        }

        public abstract bool Remove(int id);

        public bool Remove(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
