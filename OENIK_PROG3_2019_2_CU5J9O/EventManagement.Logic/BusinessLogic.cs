namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;
    using EventManagement.Repository;

    public class BusinessLogic : ILogic
    {

        ITicketRepository ticketRepo;

        public BusinessLogic(ITicketRepository ticketRepo)
        {
            this.ticketRepo = ticketRepo;
        }

        public void ChangeTicketDiscount(int id, int newDiscount)
        {
            ticketRepo.ChangeDiscount(id, newDiscount);
        }

        public IList<Ticket> GetAllTickets()
        {
            return ticketRepo.GetAll().ToList();
        }

        public IList<TotalEventSale> GetEventSale()
        {
            var q1 = from ticket in ticketRepo.GetAll()
                     group ticket by new
                     {
                         ticket.Event.Id,
                         ticket.Event.Name,
                     } into grp
                     select new TotalEventSale
                     {
                         EventName = grp.Key.Name,
                         TicketPrice = grp.Sum(x => x.Price),
                     };
            return q1.ToList();
        }

        public Ticket GetOneTicket(int id)
        {
            return ticketRepo.GetOne(id);
        }
    }
}
