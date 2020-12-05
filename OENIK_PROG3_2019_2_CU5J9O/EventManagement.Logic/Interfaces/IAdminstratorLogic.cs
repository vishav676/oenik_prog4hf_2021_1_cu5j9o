namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using EventManagement.Data.Models;

    /// <summary>
    /// This public interface contains all the methods that will be implemented for the Adminstrator office.
    /// </summary>
    public interface IAdminstratorLogic
    {
        /// <summary>
        /// This method will insert the ticket to the Ticket Table.
        /// </summary>
        /// <param name="name">Event Name.</param>
        /// <param name="organizerName">Organizer Name.</param>
        /// <param name="endDate">End Date.</param>
        /// <param name="startDate">Start Date.</param>
        /// <param name="place">Venue.</param>
        /// <param name="entryFee">Entry Fee.</param>
        void Add(string name, string organizerName, string endDate, string startDate, string place, int entryFee);

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
        /// <returns>bool value if event is updated or not.</returns>
        bool UpdatePlace(int id, string newPlace);

        /// <summary>
        /// This method will update Guest Name.
        /// </summary>
        /// <param name="id">Event Id.</param>
        /// <param name="newName">Updated Guest name.</param>
        /// <returns>bool value if guest is updated or not.</returns>
        bool ChangeName(int id, string newName);

        /// <summary>
        /// This method will remove the Guest of specific Id.
        /// </summary>
        /// <param name="id">Guest Id.</param>
        /// <returns>boolean value.</returns>
        bool RemoveGuest(int id);

        /// <summary>
        /// This method will remove the Ticket of specific Id.
        /// </summary>
        /// <param name="id">Ticket Id.</param>
        /// <returns>boolean value.</returns>
        bool RemoveTicket(int id);

        /// <summary>
        /// This mehtod will calculate total event sale.
        /// </summary>
        /// <returns>List of Event Sale.</returns>
        IList<TotalEventSale> GetEventSale();

        /// <summary>
        /// This method will return the tickets brought by single Guest.
        /// </summary>
        /// <returns>List of Tickets by Guest.</returns>
        IList<TicketsByGuest> TicketsBySingleGuest();

        /// <summary>
        /// This method will return the no of males and females in the Event.
        /// </summary>
        /// <returns>List containing the number of males and females..</returns>
        IList<NoOfMalesFemalesInEvent> GetNoOfMalesFemalesList();

        /// <summary>
        /// This is allow the administrator to change the discount for the specific Ticket.
        /// </summary>
        /// <param name="id">Ticket Id.</param>
        /// <param name="newDiscount">New Discount Value.</param>
        /// <returns>bool value if Ticket is updated or not.</returns>
        bool ChangeTicketDiscount(int id, int newDiscount);

        /// <summary>
        /// This is the Async version of <see cref="GetNoOfMalesFemalesList"/> method.
        /// </summary>
        /// <returns>It will return Task.</returns>
        Task<IList<NoOfMalesFemalesInEvent>> GetNoOfMalesAsync();

        /// <summary>
        /// This is the Async version of <see cref="TicketsBySingleGuest"/> method.
        /// </summary>
        /// <returns>It will return Task.</returns>
        Task<IList<TicketsByGuest>> GetTicketByGuestAsync();

        /// <summary>
        /// This is the Async version of <see cref="GetEventSale"/> method.
        /// </summary>
        /// <returns>It will return Task.</returns>
        Task<IList<TotalEventSale>> GetTotalSaleAsync();

        /// <summary>
        /// This method will check is the password and username and correct.
        /// </summary>
        /// <param name="name">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>Boolean Value.</returns>
        bool IsPasswordCorrect(string name, string password);
    }
}
