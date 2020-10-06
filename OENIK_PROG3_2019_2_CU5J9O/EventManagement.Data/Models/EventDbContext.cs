namespace EventManagement.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    public partial class EventDbContext : DbContext
    {
        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }

        public virtual DbSet<Guest> Guest { get; set; }

        public EventDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\EventDb.mdf;Integrated Security=True; MultipleActiveResultSets = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasOne(ticket => ticket.Event).WithMany(Event => Event.Tickets)
                .HasForeignKey(ticket => ticket.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasOne(ticket => ticket.Guest).WithMany(guest => guest.Tickets)
                .HasForeignKey(ticket => ticket.GuestId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            Event boatParty = new Event()
            {
                Id = 1,
                Name = "Boat Party",
                StartDate = "5 Oct 2020",
                EndDate = "7 Oct 2020",
                OganizarName = "Vishav",
                Place = "Chain Bridge",
            };
            Event morisonParty = new Event()
            {
                Id = 2,
                Name = "Boat Party",
                StartDate = "5 Oct 2020",
                EndDate = "7 Oct 2020",
                OganizarName = "Vishav",
                Place = "Morisson 2",
            };

            Ticket ticket1 = new Ticket()
            {
                Id = 1,
                Expiry = "7 Oct 2020",
                Discount = 0,
                OrderInfo = "No discount",
                Price = 500,
                Type = "VIP",
                EventId = 1,
                GuestId = 1,
            };
            Ticket ticket2 = new Ticket()
            {
                Id = 2,
                Expiry = "7 Oct 2020",
                Discount = 0,
                OrderInfo = "No discount",
                Price = 1000,
                Type = "VIP",
                EventId = 2,
                GuestId = 2,
            };
            Guest sanam = new Guest()
            {
                ID = 1,
                Name = "Sanam",
                City = "Dhuri",
                Contact = "XXXXXXXXXXX",
                Email = "XXX@GMAIL.COM",
                Gender = "Male",
            };
            Guest vishav = new Guest()
            {
                ID = 2,
                Name = "Vishav",
                City = "Dhuri",
                Contact = "XXXXXXXXXXX",
                Email = "XXX@GMAIL.COM",
                Gender = "Male",
            };

            modelBuilder.Entity<Guest>().HasData(sanam, vishav);
            modelBuilder.Entity<Ticket>().HasData(ticket1, ticket2);
            modelBuilder.Entity<Event>().HasData(boatParty, morisonParty);
        }
    }
}
