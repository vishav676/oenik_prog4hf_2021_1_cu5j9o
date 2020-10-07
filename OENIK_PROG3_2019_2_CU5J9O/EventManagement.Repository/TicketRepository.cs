namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using EventManagement.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(DbContext ctx)
            : base(ctx)
        {
        }

        // TODO : make new exception
        public void ChangeDiscount(int id, int newDiscount)
        {
            var ticket = GetOne(id);
            if (ticket == null) throw new InvalidOperationException();
            ticket.Discount = newDiscount;
            ctx.SaveChanges();
        }

        public override Ticket GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override bool Remove(int id)
        {
            var ticket = GetOne(id);
            throw new NotImplementedException();
        }
    }
}
