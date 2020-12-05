namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using EventManagement.Data.Models;
    using EventManagement.Repository;
    using EventManagement.Repository.Interfaces;

    /// <summary>
    /// Public class implementing <see cref="IAdminstratorLogic"/> interface.
    /// </summary>
    public class AdminstratorLogic : IAdminstratorLogic
    {
        private ITicketRepository ticketRepo;
        private IEventRepository eventRepository;
        private IGuestRepository guestRepository;
        private IAdminUserRepository adminRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminstratorLogic"/> class.
        /// </summary>
        /// <param name="ticketRepo">Ticket Repo.</param>
        /// <param name="eventRepository">Event Repo.</param>
        /// <param name="guestRepository">Guest Repo.</param>
        /// <param name="adminRepository">Admin Repo.</param>
        public AdminstratorLogic(ITicketRepository ticketRepo, IEventRepository eventRepository, IGuestRepository guestRepository, IAdminUserRepository adminRepository)
        {
            this.ticketRepo = ticketRepo;
            this.eventRepository = eventRepository;
            this.guestRepository = guestRepository;
            this.adminRepository = adminRepository;
        }

        /// <summary>
        /// Implementation of Add method for Event from <see cref="IAdminstratorLogic"/> interface.
        /// </summary>
        /// <param name="name">Event Name.</param>
        /// <param name="organizerName">Organizer Name.</param>
        /// <param name="endDate">End Date.</param>
        /// <param name="startDate">Start Date.</param>
        /// <param name="place">Venue.</param>
        /// <param name="fee">Entry Fee.</param>
        public void Add(string name, string organizerName, string endDate, string startDate, string place, int fee)
        {
            Events g = new Events()
            {
                Name = name,
                OganizarName = organizerName,
                EndDate = endDate,
                StartDate = startDate,
                Place = place,
                EntryFee = fee,
            };
            this.eventRepository.Insert(g);
        }

        /// <summary>
        /// method to change the name of the Guest.
        /// </summary>
        /// <param name="id">Guest Id.</param>
        /// <param name="newName">Updated Name.</param>
        /// <returns>bool value if guest is updated or not.</returns>
        public bool ChangeName(int id, string newName)
        {
            return this.guestRepository.ChangeName(id, newName);
        }

        /// <summary>
        /// method to change the discount on the ticket.
        /// </summary>
        /// <param name="id">Ticket ID.</param>
        /// <param name="newDiscount">New Discount Value.</param>
        /// <returns>bool value if Ticket is updated or not.</returns>
        public bool ChangeTicketDiscount(int id, int newDiscount)
        {
            return this.ticketRepo.ChangeDiscount(id, newDiscount);
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
        /// <returns>bool value if event is updated or not.</returns>
        public bool UpdatePlace(int id, string newPlace)
        {
            return this.eventRepository.ChangePlace(id, newPlace);
        }

        /// <summary>
        /// This is the Async version of <see cref="GetNoOfMalesFemalesList"/> method.
        /// </summary>
        /// <returns>It will return Task.</returns>
        public Task<IList<NoOfMalesFemalesInEvent>> GetNoOfMalesAsync()
        {
            var task = Task.Run(() => this.GetNoOfMalesFemalesList());
            return task;
        }

        /// <summary>
        /// This is the Async version of <see cref="TicketsBySingleGuest"/> method.
        /// </summary>
        /// <returns>It will return Task.</returns>
        public Task<IList<TicketsByGuest>> GetTicketByGuestAsync()
        {
            var task = Task.Run(() => this.TicketsBySingleGuest());
            return task;
        }

        /// <summary>
        /// This is the Async version of <see cref="GetEventSale"/> method.
        /// </summary>
        /// <returns>It will return Task.</returns>
        public Task<IList<TotalEventSale>> GetTotalSaleAsync()
        {
            var task = Task.Run(() => this.GetEventSale());
            return task;
        }

        /// <inheritdoc/>
        public bool IsPasswordCorrect(string name, string password)
        {
            return this.adminRepository.PasswordCorrect(name, password);
        }
    }
}
