using EventManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagement.Repository
{
    public interface IEventRepository : IRepository<Event>
    {
        void ChangePlace(int id, string newPlace);
        IList<Event> search(string name);
    }
}
