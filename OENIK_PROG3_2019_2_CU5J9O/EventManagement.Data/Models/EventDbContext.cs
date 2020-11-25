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
        /// <param name="optionsBuilder">It is of <see cref="DbContextOptionsBuilder"/> type.</param>
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
        /// <param name="modelBuilder">It is of <see cref="ModelBuilder"/> type.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasOne(ticket => ticket.Events).WithMany(events => events.Tickets)
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
                EntryFee = 500,
                Place = "Chain Bridge",
            };
            Events morisonParty = new Events()
            {
                Id = 2,
                Name = "Morison Party",
                StartDate = "5 Oct 2020",
                EndDate = "7 Oct 2020",
                EntryFee = 500,
                OganizarName = "Vishav",
                Place = "Morisson 2",
            };
            Events pragueTrip = new Events()
            {
                Id = 3,
                Name = "Prague Party",
                StartDate = "11 Nov 2020",
                EndDate = "16 Nov 2020",
                EntryFee = 45000,
                OganizarName = "John",
                Place = "Praque",
            };
            Events lakeBalaton = new Events()
            {
                Id = 4,
                Name = "Trip to Balaton",
                StartDate = "25 Nov 2020",
                EndDate = "26 Nov 2020",
                EntryFee = 6000,
                OganizarName = "Obuda",
                Place = "Batalon, Siofok",
            };
            Events unoChampionShip = new Events()
            {
                Id = 5,
                Name = "Uno Championship",
                StartDate = "15 Oct 2020",
                EndDate = "15 Oct 2020",
                EntryFee = 3000,
                OganizarName = "Agi Biro",
                Place = "Vibe Rooms",
            };
            Events wineTasting = new Events()
            {
                Id = 6,
                Name = "Wine Tasting",
                StartDate = "5 Nov 2020",
                EndDate = "5 Nov 2020",
                EntryFee = 5000,
                OganizarName = "Erasmus",
                Place = "Budapest",
            };
            Events pubCrawl = new Events()
            {
                Id = 7,
                Name = "Pub Crawl",
                StartDate = "1 Dec 2020",
                EndDate = "1 Dec 2020",
                EntryFee = 1000,
                OganizarName = "Student Team",
                Place = "Stiffler Bar",
            };
            Events poolParty = new Events()
            {
                Id = 8,
                Name = "Pool Party",
                StartDate = "20 Dec 2020",
                EndDate = "21 Dec 2020",
                EntryFee = 4500,
                OganizarName = "Aqua Team",
                Place = "Aqua World",
            };
            Events egerTrip = new Events()
            {
                Id = 9,
                Name = "Trip to Eger",
                StartDate = "5 Dec 2020",
                EndDate = "7 Dec 2020",
                EntryFee = 1000,
                OganizarName = "Buda Travellers",
                Place = "Eger",
            };
            Events finlandTrip = new Events()
            {
                Id = 10,
                Name = "Trip to Finland",
                StartDate = "11 Dec 2020",
                EndDate = "16 Dec 2020",
                EntryFee = 50000,
                OganizarName = "Student Team",
                Place = "Finland",
            };

            Ticket ticket1 = new Ticket()
            {
                Id = 1,
                Expiry = "7 Oct 2020",
                Discount = 0,
                OrderInfo = "No discount",
                PricePaid = 500,
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
                PricePaid = 500,
                Type = "VIP",
                EventId = 2,
                GuestId = 2,
            };
            Ticket ticket3 = new Ticket()
            {
                Id = 3,
                Expiry = "7 Oct 2020",
                Discount = 0,
                OrderInfo = "No discount",
                PricePaid = 500,
                Type = "Pre Sale",
                EventId = 3,
                GuestId = 3,
            };
            Ticket ticket4 = new Ticket()
            {
                Id = 4,
                Expiry = "7 Oct 2020",
                Discount = 0,
                OrderInfo = "No discount",
                PricePaid = 500,
                Type = "VIP",
                EventId = 4,
                GuestId = 4,
            };
            Ticket ticket5 = new Ticket()
            {
                Id = 5,
                Expiry = "7 Oct 2020",
                Discount = 0,
                OrderInfo = "No discount",
                PricePaid = 500,
                Type = "VIP",
                EventId = 5,
                GuestId = 5,
            };
            Ticket ticket6 = new Ticket()
            {
                Id = 6,
                Expiry = "7 Oct 2020",
                Discount = 0,
                OrderInfo = "No discount",
                PricePaid = 500,
                Type = "VIP",
                EventId = 6,
                GuestId = 6,
            };
            Ticket ticket7 = new Ticket()
            {
                Id = 7,
                Expiry = "7 Oct 2020",
                Discount = 0,
                OrderInfo = "No discount",
                PricePaid = 500,
                Type = "VIP",
                EventId = 7,
                GuestId = 7,
            };
            Ticket ticket8 = new Ticket()
            {
                Id = 8,
                Expiry = "7 Oct 2020",
                Discount = 0,
                OrderInfo = "No discount",
                PricePaid = 500,
                Type = "VIP",
                EventId = 8,
                GuestId = 8,
            };
            Ticket ticket9 = new Ticket()
            {
                Id = 9,
                Expiry = "7 Oct 2020",
                Discount = 0,
                OrderInfo = "No discount",
                PricePaid = 500,
                Type = "VIP",
                EventId = 9,
                GuestId = 9,
            };
            Ticket ticket10 = new Ticket()
            {
                Id = 10,
                Expiry = "7 Oct 2020",
                Discount = 0,
                OrderInfo = "No discount",
                PricePaid = 500,
                Type = "VIP",
                EventId = 10,
                GuestId = 10,
            };
            Ticket ticket11 = new Ticket()
            {
                Id = 11,
                Expiry = "7 Oct 2020",
                Discount = 0,
                OrderInfo = "No discount",
                PricePaid = 500,
                Type = "VIP",
                EventId = 1,
                GuestId = 11,
            };
            Ticket ticket12 = new Ticket()
            {
                Id = 12,
                Expiry = "7 Oct 2020",
                Discount = 0,
                OrderInfo = "No discount",
                PricePaid = 500,
                Type = "VIP",
                EventId = 2,
                GuestId = 12,
            };
            Ticket ticket13 = new Ticket()
            {
                Id = 13,
                Expiry = "7 Oct 2020",
                Discount = 0,
                OrderInfo = "No discount",
                PricePaid = 500,
                Type = "VIP",
                EventId = 3,
                GuestId = 13,
            };
            Ticket ticket14 = new Ticket()
            {
                Id = 14,
                Expiry = "7 Oct 2020",
                Discount = 0,
                OrderInfo = "No discount",
                PricePaid = 500,
                Type = "VIP",
                EventId = 4,
                GuestId = 14,
            };

            Guest piyush = new Guest()
            {
                ID = 1,
                Name = "Piyush",
                City = "Dhuri",
                Contact = "264446658",
                Email = "piyush@GMAIL.COM",
                Gender = "Male",
            };
            Guest vishav = new Guest()
            {
                ID = 2,
                Name = "Vishav",
                City = "Dhuri",
                Contact = "684323565",
                Email = "vishav@GMAIL.COM",
                Gender = "Male",
            };
            Guest adam = new Guest()
            {
                ID = 3,
                Name = "Adam",
                City = "Pecs",
                Contact = "71656123",
                Email = "adam@gmail.com",
                Gender = "Male",
            };
            Guest tom = new Guest()
            {
                ID = 4,
                Name = "Tom",
                City = "Budapest",
                Contact = "89651613",
                Email = "tom@gmail.com",
                Gender = "Male",
            };
            Guest john = new Guest()
            {
                ID = 5,
                Name = "John",
                City = "Budaros",
                Contact = "20254878",
                Email = "john@gmail.com",
                Gender = "Male",
            };
            Guest ben = new Guest()
            {
                ID = 6,
                Name = "Ben",
                City = "Siofok",
                Contact = "781121215",
                Email = "ben@gmail.com",
                Gender = "Male",
            };
            Guest bill = new Guest()
            {
                ID = 7,
                Name = "Bill",
                City = "Eger",
                Contact = "202541589",
                Email = "bill@gmail.com",
                Gender = "Male",
            };
            Guest salman = new Guest()
            {
                ID = 8,
                Name = "Salman",
                City = "Szeged",
                Contact = "9855484112",
                Email = "salman@gmail.com",
                Gender = "Male",
            };
            Guest akshay = new Guest()
            {
                ID = 9,
                Name = "Akshay",
                City = "Pest",
                Contact = "203174735",
                Email = "aki@gmail.com",
                Gender = "Male",
            };
            Guest mark = new Guest()
            {
                ID = 10,
                Name = "Mark",
                City = "Buda",
                Contact = "78751221211",
                Email = "mark@gmail.com",
                Gender = "Male",
            };
            Guest olivia = new Guest()
            {
                ID = 11,
                Name = "Olivia",
                City = "Siofok",
                Contact = "458451121",
                Email = "olivia@gmail.com",
                Gender = "Female",
            };
            Guest emma = new Guest()
            {
                ID = 12,
                Name = "Emma",
                City = "Pest",
                Contact = "362399435",
                Email = "emma@gmail.com",
                Gender = "Female",
            };
            Guest ava = new Guest()
            {
                ID = 13,
                Name = "Ava",
                City = "Eger",
                Contact = "78573208",
                Email = "eger@gmail.com",
                Gender = "Female",
            };
            Guest isabella = new Guest()
            {
                ID = 14,
                Name = "Isabella",
                City = "Miskolc",
                Contact = "787121548",
                Email = "isabella@gmail.com",
                Gender = "Female",
            };
            Guest evelyn = new Guest()
            {
                ID = 15,
                Name = "Evelyn",
                City = "Pecs",
                Contact = "784115151",
                Email = "evelyn@gmail.com",
                Gender = "Female",
            };
            Guest mia = new Guest()
            {
                ID = 16,
                Name = "Mia",
                City = "Dhuri",
                Contact = "57823489",
                Email = "mia@gmail.com",
                Gender = "Female",
            };
            Guest emily = new Guest()
            {
                ID = 17,
                Name = "Emily",
                City = "Budapest",
                Contact = "248923049",
                Email = "emily@GMAIL.COM",
                Gender = "Female",
            };
            Guest aria = new Guest()
            {
                ID = 18,
                Name = "Aria",
                City = "Budaros",
                Contact = "684323565",
                Email = "aria@gmail.com",
                Gender = "Female",
            };
            Guest layla = new Guest()
            {
                ID = 19,
                Name = "Layla",
                City = "Szeged",
                Contact = "737567332",
                Email = "layla@gmail.com",
                Gender = "Female",
            };
            Guest grace = new Guest()
            {
                ID = 20,
                Name = "Grace",
                City = "Budapest",
                Contact = "7257345",
                Email = "grace@gmail.com",
                Gender = "Female",
            };
            Guest natalie = new Guest()
            {
                ID = 21,
                Name = "Natalie",
                City = "Siofok",
                Contact = "375738498",
                Email = "natalie@gmail.com",
                Gender = "Female",
            };

            modelBuilder.Entity<Guest>().HasData(
                piyush,
                vishav,
                salman,
                akshay,
                mark,
                ben,
                bill,
                tom,
                john,
                adam,
                olivia,
                layla,
                natalie,
                emily,
                emma,
                grace,
                ava,
                aria,
                mia,
                evelyn,
                isabella);
            modelBuilder.Entity<Ticket>().HasData(
                ticket1,
                ticket2,
                ticket3,
                ticket4,
                ticket5,
                ticket6,
                ticket7,
                ticket8,
                ticket9,
                ticket10,
                ticket11,
                ticket12,
                ticket13,
                ticket14);
            modelBuilder.Entity<Events>().HasData(
                boatParty,
                morisonParty,
                egerTrip,
                pragueTrip,
                finlandTrip,
                poolParty,
                wineTasting,
                pubCrawl,
                unoChampionShip,
                lakeBalaton);
        }
    }
}
