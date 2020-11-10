namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EventManagement.Data.Models;

    public interface IEventRepository : IRepository<Event>
    {
        void ChangePlace(int id, string newPlace);

        IList<Event> Search(string name);
    }
}
