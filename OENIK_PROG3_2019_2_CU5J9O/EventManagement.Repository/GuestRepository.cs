using EventManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventManagement.Repository
{
    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        public GuestRepository(DbContext ctx)
            : base(ctx)
        {
        }

        public override Guest GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(int id)
        {
            var removeGuest = GetOne(id);
            return Remove(removeGuest);
        }
        public IList<Guest> search(String name)
        {
            var q = from item in GetAll()
                    where item.Name == name
                    select item;
            return q.ToList();
        }
    }
}
