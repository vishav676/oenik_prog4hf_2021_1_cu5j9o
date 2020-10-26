﻿namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

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
            this.ctx.SaveChanges();
        }

        public abstract bool Remove(int id);

        public bool Remove(T entity)
        {
            if (GetAll().Contains(entity))
            {
                this.ctx.Remove(entity);
                this.ctx.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
