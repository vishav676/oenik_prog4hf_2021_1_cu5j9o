namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EventManagement.Data.Models;

    /// <summary>
    /// This public interface contains all the methods that will be implemented for the front office.
    /// </summary>
    public interface IFrontOffice
    {
        /// <summary>
        /// This method will insert the ticket to the Ticket Table.
        /// </summary>
        /// <param name="expiry">Expiry Date of Ticket.</param>
        /// <param name="discount">Discount applied.</param>
        /// <param name="type">Type.</param>
        /// <param name="price">Price.</param>
        /// <param name="orderInfo">Order Info.</param>
        /// <param name="guestId">Guest Id who is buying the ticket.</param>
        /// <param name="eventId">Event Id for which ticket is being sold.</param>
        void Add(string expiry, int discount, string type, int price, string orderInfo, int guestId, int eventId);

        /// <summary>
        /// This method will insert the guest to the Guest Table.
        /// </summary>
        /// <param name="name">Name of the Guest.</param>
        /// <param name="contact">Contact Number.</param>
        /// <param name="city">City from which Guest Belongs.</param>
        /// <param name="email">Email address.</param>
        /// <param name="gender">Gender.</param>
        void Add(string name, string contact, string city, string email, string gender);

        /// <summary>
        /// This method will search the Guest from the database.
        /// </summary>
        /// <param name="name">Guest Name.</param>
        /// <returns>List of Guests with Given Name.</returns>
        IList<Guest> SearchGuest(string name);

        /// <summary>
        /// This method will search the Event from the database.
        /// </summary>
        /// <param name="name">Event Name.</param>
        /// <returns>List of Events with Given Name.</returns>
        IList<Events> SearchEvent(string name);

        /// <summary>
        /// This mehtod will provide list of Guests in the Database.
        /// </summary>
        /// <returns>Ilist of Guests.</returns>
        public IList<Guest> GetAllGuests();

        /// <summary>
        /// This method will return ticket with specifc Id.
        /// </summary>
        /// <param name="id">Ticket Id.</param>
        /// <returns>Ticket.</returns>
        Ticket GetOneTicket(int id);

        /// <summary>
        /// This method will return guest with specifc Id.
        /// </summary>
        /// <param name="id">Guest Id.</param>
        /// <returns>Guest.</returns>
        Guest GetOneGuest(int id);

        /// <summary>
        /// This mehtod will provide list of Tickets in the Database.
        /// </summary>
        /// <returns>Ilist of Tickets.</returns>
        IList<Ticket> GetAllTickets();

        /// <summary>
        /// This method gets all the events present in the Database.
        /// </summary>
        /// <returns>List of type Event.</returns>
        public IList<Events> GetAllEvent();

        /// <summary>
        /// This method will apply discount on the ticket.
        /// </summary>
        /// <param name="eventId">Event ID.</param>
        /// <param name="discount">Discount Value.</param>
        /// <returns>Price Paid of type int.</returns>
        int CalculatePricePaid(int eventId, int discount);
    }
}
