﻿namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class store the implementation of Interface <see cref="IGuestRepository"/> and extends class Repo of type Events.
    /// </summary>
    public class GuestRepository : Repo<Guest>, IGuestRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestRepository"/> class.
        /// </summary>
        /// <param name="ctx">Database context as parameter of super class.</param>
        public GuestRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// This is the implementation of the method from the <see cref="IGuestRepository"/>.
        /// </summary>
        /// <param name="id">Guest Id.</param>
        /// <param name="newName">New Guest Name.</param>
        /// <returns>bool value if guest is updated or not.</returns>
        public bool ChangeName(int id, string newName)
        {
            var guest = this.GetOne(id);
            if (guest == null)
            {
                return false;
            }

            guest.Name = newName;
            this.ctx.SaveChanges();
            return true;
        }

        /// <summary>
        /// This is the implementation of the method from the <see cref="IGuestRepository"/>.
        /// </summary>
        /// <param name="id">Guest ID.</param>
        /// <param name="guest">New guest values.</param>
        /// <returns>boolean value.</returns>
        public bool EditGuest(int id, Guest guest)
        {
            var guestToModify = this.GetOne(id);
            if (guestToModify == null || guest == null)
            {
                return false;
            }

            guestToModify.Name = guest.Name;
            guestToModify.City = guest.City;
            guestToModify.Contact = guest.Contact;
            guestToModify.Email = guest.Email;
            guestToModify.Gender = guest.Gender;
            this.ctx.SaveChanges();
            return true;
        }

        /// <summary>
        /// This is overriden method from <see cref="Repo{T}"/> class.
        /// </summary>
        /// <param name="id">Get the Guest Id.</param>
        /// <returns>Return Guest corresponding to particular id.</returns>
        public override Guest GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.ID == id);
        }

        /// <summary>
        /// This is the implementation of the method from <see cref="IGuestRepository"/> interface.
        /// </summary>
        /// <param name="name">Guest Name to be Searched.</param>
        /// <returns>Return IQueryable List.</returns>
        public IQueryable<Guest> Search(string name)
        {
            var q = from item in this.GetAll()
                    where item.Name == name
                    select item;
            return q;
        }
    }
}
