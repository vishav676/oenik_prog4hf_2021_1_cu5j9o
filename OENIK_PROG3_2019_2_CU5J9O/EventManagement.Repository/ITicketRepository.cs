using EventManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagement.Repository
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        void ChangeDiscount(int id, int newDiscount);
    }
}
