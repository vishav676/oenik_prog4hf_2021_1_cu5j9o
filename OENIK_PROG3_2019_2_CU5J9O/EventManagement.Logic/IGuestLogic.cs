using EventManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagement.Logic
{
    public interface IGuestLogic
    {
        public IList<Guest> GetAllGuests();
    }
}
