namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(DbContext ctx)
            : base(ctx)
        {
        }

        public override Event GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override bool Remove(int id)
        {
            var removeEvent = this.GetOne(id);
            return this.Remove(removeEvent);

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

        public IList<Event> Search(string name)
        {
            var q = from item in this.GetAll()
                    where item.Name == name
                    select item;
            return q.ToList();
        }
    }
}
