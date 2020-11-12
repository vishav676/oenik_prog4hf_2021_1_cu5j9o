namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EventManagement.Data.Models;

    public interface IFrontOffice
    {

        void Add(string expiry, int discount, string type, int price, string orderInfo, int guestId, int eventId);

        void Add(string name, string contact, string city, string email, string gender);

        IList<Guest> SearchGuest(string name);

        IList<Events> SearchEvent(string name);

        public IList<Guest> GetAllGuests();

        Ticket GetOneTicket(int id);

        IList<Ticket> GetAllTickets();

        /// <summary>
        /// This method gets all the events present in the Database.
        /// </summary>
        /// <returns>List of type Event.</returns>
        public IList<Events> GetAllEvent();

    }
}
