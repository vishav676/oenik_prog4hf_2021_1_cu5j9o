namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class EventRepository : Repository<Events>, IEventRepository
    {
        public EventRepository(DbContext ctx)
            : base(ctx)
        {
        }

        public override Events GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }


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

        public IQueryable<Events> Search(string name)
        {
            var q = from item in this.GetAll()
                    where item.Name == name
                    select item;
            return q;
        }
    }
}
