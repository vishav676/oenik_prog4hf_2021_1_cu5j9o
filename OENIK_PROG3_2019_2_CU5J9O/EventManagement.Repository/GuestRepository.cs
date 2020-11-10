namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        public GuestRepository(DbContext ctx)
            : base(ctx)
        {
        }

        public void ChangeName(int id, string newName)
        {
            var guest = this.GetOne(id);
            if (guest == null)
            {
                throw new InvalidOperationException();
            }

            guest.Name = newName;
            this.ctx.SaveChanges();
        }

        public override Guest GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.ID == id);
        }


        public IQueryable<Guest> Search(string name)
        {
            var q = from item in this.GetAll()
                    where item.Name == name
                    select item;
            return q;
        }
    }
}
