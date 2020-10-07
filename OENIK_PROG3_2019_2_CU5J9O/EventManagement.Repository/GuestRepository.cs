using EventManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagement.Repository
{
    class GuestRepository : Repository<Guest>, IGuestRepository
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
            throw new NotImplementedException();
        }
    }
}
