using EventManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagement.Logic
{
    public interface ILogic
    {
        void add(Ticket ticket);
        
        void add(Guest guest);
        IList<Guest> search(String name);

        IList<Event> searchEvent(String name);
    }
}
