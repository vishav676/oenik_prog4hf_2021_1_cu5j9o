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

        public EventRepository(DbContext ctx) : base(ctx) { }

        public override Event GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override bool Remove(int id)
        {
            var removeEvent = GetOne(id);
            return Remove(removeEvent);

        }

        public void ChangePlace(int id, string newPlace)
        {
            var myEvent = GetOne(id);
            if (myEvent == null) throw new InvalidOperationException();
            myEvent.Place = newPlace;
            ctx.SaveChanges();
        }
    }
}
