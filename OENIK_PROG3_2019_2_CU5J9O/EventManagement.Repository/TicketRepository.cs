namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using EventManagement.Data.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class store the implementation of Interface <see cref="ITicketRepository"/> and extends class Repository of type Events.
    /// </summary>
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TicketRepository"/> class.
        /// </summary>
        /// <param name="ctx">Database context as parameter of super class.</param>
        public TicketRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// This is the implementation of the method from the <see cref="ITicketRepository"/>.
        /// </summary>
        /// <param name="id">Ticket Id.</param>
        /// <param name="newDiscount">New Discount Value.</param>
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

        /// <summary>
        /// This is overriden method from <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="id">Get the Ticket Id.</param>
        /// <returns>Return Event corresponding to particular id.</returns>
        public override Ticket GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
