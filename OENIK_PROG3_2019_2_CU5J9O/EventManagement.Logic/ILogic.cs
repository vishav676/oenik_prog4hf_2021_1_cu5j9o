namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EventManagement.Data.Models;

    public interface ILogic
    {
        void Add(Ticket ticket);

        void Add(Guest guest);

        IList<Guest> Search(string name);

        IList<Event> SearchEvent(string name);

        bool RemoveTicket(int id);

        // IList<Ticket> searchTickets(int guestId);
    }
}
