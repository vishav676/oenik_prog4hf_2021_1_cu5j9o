namespace EventManagement.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class will act as database Context for application.
    /// This class extends <see cref = "DbContext"/> class.
    /// </summary>
    public partial class EventDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventDbContext"/> class.
        /// This will ensure if Database is created.
        /// </summary>
        public EventDbContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or Sets the DbSet of the <see cref="Models.Events"/> class.
        /// This is a virtual property.
        /// </summary>
        public virtual DbSet<Events> Events { get; set; }

        /// <summary>
        /// Gets or Sets the DbSet of the <see cref="Ticket"/> class.
        /// This is a virtual property.
        /// </summary>
        public virtual DbSet<Ticket> Tickets { get; set; }

        /// <summary>
        /// Gets or Sets the DbSet of the <see cref="Guest"/> class.
        /// This is a virtual property.
        /// </summary>
        public virtual DbSet<Guest> Guest { get; set; }

        /// <summary>
        /// This method will configure the Database, using Data Source
        /// Data Source is of Relative path which ensure it will
        /// work in every computer.
        /// </summary>
        /// <param name="optionsBuilder">It of <see cref="DbContextOptionsBuilder"/> type.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\EventDb.mdf;Integrated Security=True; MultipleActiveResultSets = true");
            }
        }

        /// <summary>
        /// This method will create the models in the Database.
        /// And provide the connection between the tables of Database.
        /// </summary>
        /// <param name="modelBuilder">It of <see cref="ModelBuilder"/> type.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasOne(ticket => ticket.Event).WithMany(events => events.Tickets)
                .HasForeignKey(ticket => ticket.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasOne(ticket => ticket.Guest).WithMany(guest => guest.Tickets)
                .HasForeignKey(ticket => ticket.GuestId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            Events boatParty = new Events()
            {
                Id = 1,
                Name = "Boat Party",
                StartDate = "5 Oct 2020",
                EndDate = "7 Oct 2020",
                OganizarName = "Vishav",
                Place = "Chain Bridge",
            };
            Events morisonParty = new Events()
            {
                Id = 2,
                Name = "Morison Party",
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
                Name = "Piyush",
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
            modelBuilder.Entity<Events>().HasData(boatParty, morisonParty);
        }
    }
}
