namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Castle.Components.DictionaryAdapter;
    using EventManagement.Data.Models;


    /// <summary>
    /// This is interface which store the methods related the Events table.
    /// </summary>
    public interface IEventLogic
    {

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
    }
}
