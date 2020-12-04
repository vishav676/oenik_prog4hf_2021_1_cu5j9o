namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EventManagement.Data.Models;

    /// <summary>
    /// This interface stores functions related to Ticket table.
    /// </summary>
    public interface ITicketRepository : IRepository<Ticket>
    {
        /// <summary>
        /// This method is used to update the discount value in the table of specific ticket.
        /// </summary>
        /// <param name="id">ID of the ticket.</param>
        /// <param name="newDiscount">new discount value.</param>
        /// <returns>bool value if ticket is updated or not.</returns>
        bool ChangeDiscount(int id, int newDiscount);
    }
}
