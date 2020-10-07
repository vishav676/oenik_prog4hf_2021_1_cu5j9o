using EventManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagement.Repository
{
    class EventRepository : Repository<Event>, IEventRepository
    {

        public EventRepository(DbContext ctx) : base(ctx) { }

        public override Event GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
