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
            var ticket = this.GetOne(id);
            if (ticket == null)
            {
                throw new InvalidOperationException();
            }

            ticket.Discount = newDiscount;
            this.ctx.SaveChanges();
        }

        public override Ticket GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override bool Remove(int id)
        {
            var ticket = this.GetOne(id);
            return this.Remove(ticket);
        }
    }
}
