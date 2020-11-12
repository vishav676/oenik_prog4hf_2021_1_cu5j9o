namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EventManagement.Data.Models;

    public interface IAdminstratorLogic
    {
        /// <summary>
        /// This method will add the new Event to the table.
        /// </summary>
        /// <param name="enitity">parameter of type <see cref="Events"/>.</param>
        void Add(string name, string organizerName, string endDate, string startDate, string place);

        /// <summary>
        /// This method gets the Event Id which needs to be remove.
        /// </summary>
        /// <param name="id">Event Id.</param>
        /// <returns>bool value if event is deleted or not.</returns>
        bool RemoveEvent(int id);

        /// <summary>
        /// This method will update the Place of the Event.
        /// </summary>
        /// <param name="id">Event Id.</param>
        /// <param name="newPlace">New place name.</param>
        void UpdatePlace(int id, string newPlace);

        void ChangeName(int id, string newName);

        bool RemoveGuest(int id);

        bool RemoveTicket(int id);

        IList<TotalEventSale> GetEventSale();
        IList<TicketsByGuest> TicketsBySingleGuest();

        IList<NoOfMalesFemalesInEvent> GetNoOfMalesFemalesList();
        void ChangeTicketDiscount(int id, int newDiscount);
    }
}
