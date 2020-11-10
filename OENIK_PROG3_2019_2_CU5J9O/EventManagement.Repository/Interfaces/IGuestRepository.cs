namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;

    public interface IGuestRepository : IRepository<Guest>
    {
        IQueryable<Guest> Search(string name);

        void ChangeName(int id, string newName);
    }
}
