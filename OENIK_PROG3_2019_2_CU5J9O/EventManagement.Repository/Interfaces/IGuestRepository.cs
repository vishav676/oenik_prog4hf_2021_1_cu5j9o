namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EventManagement.Data.Models;

    public interface IGuestRepository : IRepository<Guest>
    {
        IList<Guest> Search(string name);

        void ChangeName(int id, string newName);
    }
}
