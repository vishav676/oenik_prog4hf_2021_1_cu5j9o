namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using EventManagement.Data.Models;
    using EventManagement.Repository;

    /// <summary>
    /// Public class implementing <see cref="IAdminstratorLogic"/> interface.
    /// </summary>
    public class AdminstratorLogic : IAdminstratorLogic
    {
        private ITicketRepository ticketRepo;
        private IEventRepository eventRepository;
        private IGuestRepository guestRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminstratorLogic"/> class.
        /// </summary>
        /// <param name="ticketRepo">Ticket Repo.</param>
        /// <param name="eventRepository">Event Repo.</param>
        /// <param name="guestRepository">Guest Repo.</param>
        public AdminstratorLogic(ITicketRepository ticketRepo, IEventRepository eventRepository, IGuestRepository guestRepository)
        {
            this.ticketRepo = ticketRepo;
            this.eventRepository = eventRepository;
            this.guestRepository = guestRepository;
        }

        /// <summary>
        /// Implementation of Add method for Event from <see cref="IAdminstratorLogic"/> interface.
        /// </summary>
        /// <param name="name">Event Name.</param>
        /// <param name="organizerName">Organizer Name.</param>
        /// <param name="endDate">End Date.</param>
        /// <param name="startDate">Start Date.</param>
        /// <param name="place">Venue.</param>
        public void Add(string name, string organizerName, string endDate, string startDate, string place)
        {
            Events g = new Events()
            {
                Name = name,
                OganizarName = organizerName,
                EndDate = endDate,
                StartDate = startDate,
                Place = place,
            };
            this.eventRepository.Insert(g);
        }

        /// <summary>
        /// method to change the name of the Guest.
        /// </summary>
        /// <param name="id">Guest Id.</param>
        /// <param name="newName">Updated Name.</param>
        public void ChangeName(int id, string newName)
        {
            this.guestRepository.ChangeName(id, newName);
        }

        /// <summary>
        /// method to change the discount on the ticket.
        /// </summary>
        /// <param name="id">Ticket ID.</param>
        /// <param name="newDiscount">New Discount Value.</param>
        public void ChangeTicketDiscount(int id, int newDiscount)
        {
            this.ticketRepo.ChangeDiscount(id, newDiscount);
        }

        /// <summary>
        /// Method to get the number of males and females in the Event.
        /// </summary>
        /// <returns>Ilist of <see cref="NoOfMalesFemalesInEvent"/>.</returns>
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
                            NoOfFemales = item.Tickets.Count(x => x.Guest.Gender == "Female"),
                            NoOfMales = item.Tickets.Count(x => x.Guest.Gender == "Male"),
                        };
            return test1.ToList();
        }

        /// <summary>
        /// Method to get the total sale of the Event.
        /// </summary>
        /// <returns>Ilist of <see cref="TotalEventSale"/>.</returns>
        public IList<TotalEventSale> GetEventSale()
        {
            var q1 = from ticket in this.ticketRepo.GetAll().ToList()
                     group ticket by new
                     {
                         ticket.Events.Id,
                         ticket.Events.Name,
                     }
                    into grp
                     select new TotalEventSale
                     {
                         EventName = grp.Key.Name,
                         TicketPrice = grp.Sum(x => x.PricePaid),
                     };
            return q1.ToList();
        }

        /// <summary>
        /// Method to get the tickets brought by single guest.
        /// </summary>
        /// <returns>Ilist of <see cref="TicketsByGuest"/>.</returns>
        public IList<TicketsByGuest> TicketsBySingleGuest()
        {
            var q1 = from guest in this.guestRepository.GetAll().ToList()
                     select new TicketsByGuest
                     {
                         GuestName = guest.Name,
                         Tickets = guest.Tickets.ToList(),
                     };

            return q1.ToList();
        }

        /// <summary>
        /// Mehtod to remove the event from the database.
        /// </summary>
        /// <param name="id">Event Id.</param>
        /// <returns>Boolean Value.</returns>
        public bool RemoveEvent(int id)
        {
            return this.eventRepository.Remove(id);
        }

        /// <summary>
        /// Mehtod to remove the guest from the database.
        /// </summary>
        /// <param name="id">Guest Id.</param>
        /// <returns>Boolean Value.</returns>
        public bool RemoveGuest(int id)
        {
            return this.guestRepository.Remove(id);
        }

        /// <summary>
        /// Mehtod to remove the ticket from the database.
        /// </summary>
        /// <param name="id">ticket Id.</param>
        /// <returns>Boolean Value.</returns>
        public bool RemoveTicket(int id)
        {
            return this.ticketRepo.Remove(id);
        }

        /// <summary>
        /// method to change the venue of the Event.
        /// </summary>
        /// <param name="id">Event ID.</param>
        /// <param name="newPlace">New Place.</param>
        public void UpdatePlace(int id, string newPlace)
        {
            this.eventRepository.ChangePlace(id, newPlace);
        }
    }
}
