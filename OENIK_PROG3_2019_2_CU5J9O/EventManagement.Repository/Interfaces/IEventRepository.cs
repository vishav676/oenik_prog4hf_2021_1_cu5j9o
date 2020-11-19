namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;

    /// <summary>
    /// This interface store the queries related to Event Table
    /// It extends IRepository interface.
    /// </summary>
    public interface IEventRepository : IRepository<Events>
    {
        /// <summary>
        /// This method is used to change the event place for an Event.
        /// </summary>
        /// <param name="id">Id of the Event.</param>
        /// <param name="newPlace">Updated Place Name.</param>
        void ChangePlace(int id, string newPlace);

        /// <summary>
        /// Search method is used to find particular Event from the Database.
        /// </summary>
        /// <param name="name">Event Name to be searched.</param>
        /// <returns>IQueryable list of Events whose name matched with given input.</returns>
        IQueryable<Events> Search(string name);
    }
}
