namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EventManagement.Data.Models;

    public interface IFrontOffice
    {

        void Add(Ticket ticket);

        void Add(Guest guest);

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
