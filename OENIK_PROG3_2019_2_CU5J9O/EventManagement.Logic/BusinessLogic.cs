namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;
    using EventManagement.Repository;

    public class BusinessLogic : IEventLogic, ILogic
    {

        ITicketRepository ticketRepo;
        IGuestRepository guestRepo;
        IEventRepository eventRepository;

        public BusinessLogic(ITicketRepository ticketRepo, IEventRepository eventRepository)
        {
            this.ticketRepo = ticketRepo;
            this.eventRepository = eventRepository;
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

        public void add(Event entity)
        {
            eventRepository.Insert(entity);
        }

        public IList<Event> getAllEvent()
        {
            return eventRepository.GetAll().ToList();
        }

        public bool remove(int id)
        {
            return eventRepository.Remove(id);
        }
    }
}
