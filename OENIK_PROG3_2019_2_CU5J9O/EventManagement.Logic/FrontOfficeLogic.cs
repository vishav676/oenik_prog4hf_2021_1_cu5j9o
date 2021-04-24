namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;
    using EventManagement.Repository;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// Public class implementing <see cref="IFrontOffice"/> interface.
    /// </summary>
    public class FrontOfficeLogic : IFrontOffice
    {
        private ITicketRepository ticketRepo;
        private IEventRepository eventRepository;
        private IGuestRepository guestRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrontOfficeLogic"/> class.
        /// </summary>
        /// <param name="ticketRepo">Ticket Repo.</param>
        /// <param name="eventRepository">Event Repo.</param>
        /// <param name="guestRepository">Guest Repo.</param>
        public FrontOfficeLogic(ITicketRepository ticketRepo, IEventRepository eventRepository, IGuestRepository guestRepository)
        {
            this.ticketRepo = ticketRepo;
            this.eventRepository = eventRepository;
            this.guestRepository = guestRepository;
        }

        /// <summary>
        /// Implementation of Add method for Ticket from <see cref="IFrontOffice"/> interface.
        /// </summary>
        /// <param name="expiry">Expiry of ticket.</param>
        /// <param name="discount">Discount Value.</param>
        /// <param name="type">Type of the ticket.</param>
        /// <param name="price">Price Paid for the ticekt.</param>
        /// <param name="orderInfo">Order Info.</param>
        /// <param name="guestId">Guest Id.</param>
        /// <param name="eventId">Event Id.</param>
        public void Add(string expiry, int discount, string type, int price, string orderInfo, int guestId, int eventId)
        {
            Ticket ticket = new Ticket()
            {
                Expiry = expiry,
                Discount = discount,
                Type = type,
                PricePaid = price,
                OrderInfo = orderInfo,
                GuestId = guestId,
                EventId = eventId,
            };
            this.ticketRepo.Insert(ticket);
        }

        /// <summary>
        /// Implementation of Add method for Guest from <see cref="IFrontOffice"/> interface.
        /// </summary>
        /// <param name="name">Guest Name.</param>
        /// <param name="contact">Contact No.</param>
        /// <param name="city">City of Guest.</param>
        /// <param name="email">Email Id.</param>
        /// <param name="gender">Gender.</param>
        public void Add(string name, string contact, string city, string email, string gender)
        {
            Guest guest = new Guest()
            {
                Name = name,
                Contact = contact,
                City = city,
                Email = email,
                Gender = gender,
            };
            this.guestRepository.Insert(guest);
        }

        /// <summary>
        /// Method will return the list of the all Events in the Database.
        /// </summary>
        /// <returns>Ilist.</returns>
        public IList<Events> GetAllEvent()
        {
            return this.eventRepository.GetAll().ToList();
        }

        /// <summary>
        /// Method will return the list of the all Guests. in the Database.
        /// </summary>
        /// <returns>Ilist.</returns>
        public IList<Guest> GetAllGuests()
        {
            return this.guestRepository.GetAll().ToList();
        }

        /// <summary>
        /// Method will return the list of the all Tickets in the Database.
        /// </summary>
        /// <returns>Ilist.</returns>
        public IList<Ticket> GetAllTickets()
        {
            return this.ticketRepo.GetAll().ToList();
        }

        /// <summary>
        /// This mehtod will return the Ticket with specific ticket id.
        /// </summary>
        /// <param name="id">Ticket ID.</param>
        /// <returns>instance of <see cref="Ticket"/>.</returns>
        public Ticket GetOneTicket(int id)
        {
            return this.ticketRepo.GetOne(id);
        }

        /// <summary>
        /// This mehtod will return the guest with specific id.
        /// </summary>
        /// <param name="id">Guest Id.</param>
        /// <returns>instance of <see cref="Guest"/>.</returns>
        public Guest GetOneGuest(int id)
        {
            return this.guestRepository.GetOne(id);
        }

        /// <summary>
        /// This method will search the Guest with the given name.
        /// </summary>
        /// <param name="name">Guest Name.</param>
        /// <returns>Ilist of Guests.</returns>
        public IList<Guest> SearchGuest(string name)
        {
            return this.guestRepository.Search(name).ToList();
        }

        /// <summary>
        /// This method will search the Event with the given name.
        /// </summary>
        /// <param name="name">Event Name.</param>
        /// <returns>Ilist of Events.</returns>
        public IList<Events> SearchEvent(string name)
        {
            return this.eventRepository.Search(name).ToList();
        }

        /// <summary>
        /// This method will calculate the Price paid for the ticket after the discount.
        /// </summary>
        /// <param name="eventId">Event Id.</param>
        /// <param name="discount">Discount Value.</param>
        /// <returns>Price to be Paid.</returns>
        public int CalculatePricePaid(int eventId, int discount)
        {
            int price = this.eventRepository.GetOne(eventId).EntryFee;
            return price - ((discount * price) / 100);
        }
    }
}
