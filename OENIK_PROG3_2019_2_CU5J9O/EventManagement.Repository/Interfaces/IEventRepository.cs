namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;

    public interface IEventRepository : IRepository<Events>
    {
        void ChangePlace(int id, string newPlace);

        IQueryable<Events> Search(string name);
    }
}
