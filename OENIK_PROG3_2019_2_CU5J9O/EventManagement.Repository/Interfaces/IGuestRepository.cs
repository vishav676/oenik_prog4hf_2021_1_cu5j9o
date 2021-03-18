namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;

    /// <summary>
    /// This interface store the queries related to Guest Table
    /// It extends IRepository interface.
    /// </summary>
    public interface IGuestRepository : IRepository<Guest>
    {
        /// <summary>
        /// Search method is used to find particular Guest from the Database.
        /// </summary>
        /// <param name="name">Guest Name to be searched.</param>
        /// <returns>IQueryable list of Guest whose name matched with given input.</returns>
        IQueryable<Guest> Search(string name);

        /// <summary>
        /// This method is used to change the Guest name.
        /// </summary>
        /// <param name="id">Id of the Guest.</param>
        /// <param name="newName">Updated Guest Name.</param>
        /// <returns>bool value if Guest is updated or not.</returns>
        bool ChangeName(int id, string newName);

        /// <summary>
        /// This method is used to edit the details of the Guest.
        /// </summary>
        /// <param name="id">Guest ID.</param>
        /// <param name="guest">Guest Type.</param>
        /// <returns>Boolean return value.</returns>
        bool EditGuest(int id, Guest guest);
    }
}
