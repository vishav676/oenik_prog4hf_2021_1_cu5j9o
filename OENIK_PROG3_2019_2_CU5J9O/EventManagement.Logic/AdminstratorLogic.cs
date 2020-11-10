namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using EventManagement.Data.Models;
    using EventManagement.Repository;

    public class AdminstratorLogic : IAdminstratorLogic
    {
        private ITicketRepository ticketRepo;
        private IEventRepository eventRepository;
        private IGuestRepository guestRepository;

        public AdminstratorLogic(ITicketRepository ticketRepo, IEventRepository eventRepository, IGuestRepository guestRepository)
        {
            this.ticketRepo = ticketRepo;
            this.eventRepository = eventRepository;
            this.guestRepository = guestRepository;
        }

        public void Add(Events enitity)
        {
            this.eventRepository.Insert(enitity);
        }

        public void ChangeName(int id, string newName)
        {
            this.guestRepository.ChangeName(id, newName);
        }

        public void ChangeTicketDiscount(int id, int newDiscount)
        {
            this.ticketRepo.ChangeDiscount(id, newDiscount);
        }

        public IList<NoOfMalesFemalesInEvent> GetNoOfMalesFemalesList()
        {
            var test = from item in this.eventRepository.GetAll().ToList()
                       select new
                       {
                           EventName = item.Name,
                           Tickets = item.Tickets,
                       };

            var test1 = from item in test
                        select new NoOfMalesFemalesInEvent
                        {
                            EventName = item.EventName,
                            noOfFemales = item.Tickets.Count(x => x.Guest.Gender == "Female"),
                            noOfMales = item.Tickets.Count(x => x.Guest.Gender == "Male"),
                        };
            return test1.ToList();
        }

        public IList<TotalEventSale> GetEventSale()
        {
            var q1 = from ticket in this.ticketRepo.GetAll().ToList()
                     group ticket by new
                     {
                         ticket.Event.Id,
                         ticket.Event.Name,
                     }
                    into grp
                     select new TotalEventSale
                     {
                         EventName = grp.Key.Name,
                         TicketPrice = grp.Sum(x => x.Price),
                     };
            return q1.ToList();
        }

        public IList<TicketsByGuest> TicketsBySingleGuest()
        {
            var q1 = from guest in this.guestRepository.GetAll().ToList()
                     select new TicketsByGuest
                     {
                         GuestName = guest.Name,
                         Tickets = guest.Tickets.ToList(),
                     };

            //var q2 = this.guestRepository.GetOne(id).Tickets;
            return q1.ToList();
        }

        public bool RemoveEvent(int id)
        {
            return this.eventRepository.Remove(id);
        }

        public bool RemoveGuest(int id)
        {
            return this.guestRepository.Remove(id);
        }

        public bool RemoveTicket(int id)
        {
            return this.ticketRepo.Remove(id);
        }

        public void UpdatePlace(int id, string newPlace)
        {
            this.eventRepository.ChangePlace(id, newPlace);
        }
    }
}
