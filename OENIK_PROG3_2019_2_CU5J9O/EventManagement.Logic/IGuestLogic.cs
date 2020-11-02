using EventManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagement.Logic
{
    public interface IGuestLogic
    {
        public IList<Guest> GetAllGuests();

        Ticket GetOneTicket(int id);

        void ChangeTicketDiscount(int id, int newDiscount);

        IList<Ticket> GetAllTickets();

        IList<TotalEventSale> GetEventSale();

        /// <summary>
        /// This method will add the new Event to the table.
        /// </summary>
        /// <param name="enitity">parameter of type <see cref="Event"/></param>
        void add(Event enitity);


        /// <summary>
        /// This method gets all the events present in the Database.
        /// </summary>
        /// <returns>List of type Event</returns>
        public IList<Event> getAllEvent();

        /// <summary>
        /// This method gets the Event Id which needs to be remove.
        /// </summary>
        /// <param name="id">Event Id</param>
        /// <returns>bool value if event is deleted or not.</returns>
        bool remove(int id);


        /// <summary>
        /// This method will update the Place of the Event.
        /// </summary>
        /// <param name="id">Event Id.</param>
        /// <param name="newPlace">New place name.</param>
        void updatePlace(int id, string newPlace);

        bool removeGuest(int id);
    }
}
