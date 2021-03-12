namespace EventManagement.Logic.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EventManagement.Data.Models;

    /// <summary>
    /// This interface contains methods for logic specified for guest table.
    /// </summary>
    public interface IGuestLogic
    {
        /// <summary>
        /// This function gets the list of guests from the database.
        /// </summary>
        /// <returns>IList of Guest type.</returns>
        public IList<Guest> GetAllGuests();

        /// <summary>
        /// This function inserts the new guest to the database.
        /// </summary>
        /// <param name="guest">Guest type parameter.</param>
        void Add();

        /// <summary>
        /// This function is used to delete the selected guest from the database.
        /// </summary>
        /// <param name="guest">Guest type parameter.</param>
        void Delete(Guest guest);

        /// <summary>
        /// This function is used to edit the detail of selected Guest.
        /// </summary>
        /// <param name="guest">Guest type parameter.</param>
        void Edit(Guest guest);
    }
}
