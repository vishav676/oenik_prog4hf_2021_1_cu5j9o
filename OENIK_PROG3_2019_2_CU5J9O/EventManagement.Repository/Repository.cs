namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class store the implementation of Interface <see cref="IRepository{T}"/>.
    /// </summary>
    /// <typeparam name="T">Class Type.</typeparam>
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// ctx is protected object of the DbCntext.
        /// </summary>
        protected DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="ctx">DbContext object.</param>
        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// This method return all the entries of type T.
        /// </summary>
        /// <returns>IQueryable List.</returns>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <summary>
        /// This is an abstract method which will be overriden in child classes as needed.
        /// </summary>
        /// <param name="id">id of type int.</param>
        /// <returns>Instance of type T.</returns>
        public abstract T GetOne(int id);

        /// <summary>
        /// This method insert the type T into the specific table.
        /// </summary>
        /// <param name="entity">entity of Type T.</param>
        public void Insert(T entity)
        {
            this.ctx.Set<T>().Add(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// This method removes the entry with specific Id from the particular table.
        /// </summary>
        /// <param name="id">Entry Id of type int.</param>
        /// <returns>boolean value whether deletion is successful or not.</returns>
        public bool Remove(int id)
        {
            var q = this.GetOne(id);
            if (q != null)
            {
                this.Remove(q);
                return true;
            }

            return false;
        }

        /// <summary>
        /// This method removes the specific model from the particular table.
        /// </summary>
        /// <param name="entity">Entity to be removen.</param>
        /// <returns>boolean value whether deletion is successful or not.</returns>
        public bool Remove(T entity)
        {
            if (this.GetAll().Contains(entity))
            {
                this.ctx.Remove(entity);
                this.ctx.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
