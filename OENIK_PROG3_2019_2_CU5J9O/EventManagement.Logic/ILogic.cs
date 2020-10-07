using EventManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagement.Logic
{
    public interface ILogic
    {
        Ticket GetOneTicket(int id);

        void ChangeTicketDiscount(int id, int newDiscount);

        IList<Ticket> GetAllTickets();

        IList<TotalEventSale> GetEventSale();
    }
}
