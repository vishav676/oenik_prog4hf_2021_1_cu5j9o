namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class store the implementation of Interface <see cref="IEventRepository"/> and extends class Repository of type Events.
    /// </summary>
    public class EventRepository : Repository<Events>, IEventRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventRepository"/> class.
        /// </summary>
        /// <param name="ctx">Database context as parameter of super class.</param>
        public EventRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// This is overriden method from <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="id">Get the Event Id.</param>
        /// <returns>Return Event corresponding to particular id.</returns>
        public override Events GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// This is the implementation of the method from the <see cref="IEventRepository"/>.
        /// </summary>
        /// <param name="id">Event Id.</param>
        /// <param name="newPlace">New Place Name.</param>
        public void ChangePlace(int id, string newPlace)
        {
            var myEvent = this.GetOne(id);
            if (myEvent == null)
            {
                throw new InvalidOperationException();
            }

            myEvent.Place = newPlace;
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// This is the implementation of the method from <see cref="IEventRepository"/> interface.
        /// </summary>
        /// <param name="name">Event Name to be Searched.</param>
        /// <returns>Return IQueryable List.</returns>
        public IQueryable<Events> Search(string name)
        {
            var q = from item in this.GetAll()
                    where item.Name == name
                    select item;
            return q;
        }
    }
}
