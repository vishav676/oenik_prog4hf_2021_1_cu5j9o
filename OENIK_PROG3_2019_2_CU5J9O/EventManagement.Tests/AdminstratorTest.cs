namespace EventManagement.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using EventManagement.Data.Models;
    using EventManagement.Logic;
    using EventManagement.Repository;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class AdminstratorTest
    {
        [Test]
        public void TestEventAdd()
        {
            Mock<IEventRepository> eventRepo = new Mock<IEventRepository>();
            Mock<ITicketRepository> ticketRepo = new Mock<ITicketRepository>();
            Mock<IGuestRepository> guestRepo = new Mock<IGuestRepository>();

            eventRepo.Setup(m => m.Insert(It.IsAny<Events>()));

            Events testEvent = new Events()
            {
                Name = "DanceParty", OganizarName = "Sonika", StartDate = "12-12-2020", EndDate = "13-12-2020", Place = "India",
            };

            AdminstratorLogic logic = new AdminstratorLogic(ticketRepo.Object, eventRepo.Object, guestRepo.Object);
            logic.Add(testEvent.Name, testEvent.OganizarName, testEvent.EndDate, testEvent.StartDate, testEvent.Place);
            eventRepo.Verify(repo => repo.Insert(It.IsAny<Events>()));
        }

        [Test]
        [Sequential]
        public void TestGuestGetOne([Values(3)] int id)
        {
            Mock<IEventRepository> eventRepo = new Mock<IEventRepository>();
            Mock<ITicketRepository> ticketRepo = new Mock<ITicketRepository>();
            Mock<IGuestRepository> guestRepo = new Mock<IGuestRepository>();
            ticketRepo.Setup(m => m.GetAll()).Returns(new List<Ticket>()
            {
                new Ticket
                {
                    Id = 1, Type = "Sance",
                },
                new Ticket
                {
                    Id = 2, Type = "Sance1",
                },
                new Ticket
                {
                    Id = 3, Type = "Sance2",
                },
            }.AsQueryable());

            IFrontOffice li = new FrontOfficeLogic(ticketRepo.Object, eventRepo.Object, guestRepo.Object);

            object temp = li.GetOneTicket(id);
            ticketRepo.Verify(x => x.GetOne(id));
        }

        [Test]
        public void TestGetAllTickets()
        {
            Mock<IEventRepository> eventRepo = new Mock<IEventRepository>();
            Mock<ITicketRepository> ticketRepo = new Mock<ITicketRepository>();
            Mock<IGuestRepository> guestRepo = new Mock<IGuestRepository>();

            List<Ticket> tickets = new List<Ticket>()
            {
                new Ticket(){ Id = 1, Type = "Vip"},
                new Ticket(){ Id = 2, Type = "Vip1"},
                new Ticket(){ Id = 3, Type = "Vip2"},
            };

            List<Ticket> expectedResult = new List<Ticket>() { tickets[0], tickets[1], tickets[2] };
            ticketRepo.Setup(repo => repo.GetAll()).Returns(tickets.AsQueryable());

            FrontOfficeLogic frontOffice = new FrontOfficeLogic(ticketRepo.Object, eventRepo.Object, guestRepo.Object);

            var result = frontOffice.GetAllTickets();

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Is.EquivalentTo(expectedResult));

        }

        [Test]
        [Sequential]
        public void TestRemove([Values(3)] int id)
        {
            Mock<IEventRepository> eventRepo = new Mock<IEventRepository>();
            Mock<ITicketRepository> ticketRepo = new Mock<ITicketRepository>();
            Mock<IGuestRepository> guestRepo = new Mock<IGuestRepository>();


            guestRepo.Setup(repo => repo.Remove(It.IsAny<int>())).Returns(true);
            bool expectedTrue = true;
            AdminstratorLogic logic = new AdminstratorLogic(ticketRepo.Object, eventRepo.Object, guestRepo.Object);
            bool result = logic.RemoveGuest(id);
            Assert.That(result, Is.EqualTo(expectedTrue));

            guestRepo.Verify(repo => repo.Remove(id), Times.Once);

        }

        [Test]
        public void TestUpdate()
        {
            Mock<IEventRepository> eventRepo = new Mock<IEventRepository>();
            Mock<ITicketRepository> ticketRepo = new Mock<ITicketRepository>();
            Mock<IGuestRepository> guestRepo = new Mock<IGuestRepository>();

            guestRepo.Setup(repo => repo.ChangeName(It.IsAny<int>(), It.IsAny<string>()));
            AdminstratorLogic logic = new AdminstratorLogic(ticketRepo.Object, eventRepo.Object, guestRepo.Object);
            logic.ChangeName(1, "Vishav");
            guestRepo.Verify(repo => repo.ChangeName(1, "Vishav"), Times.Once);
        }

        Mock<IEventRepository> eventRepo;
        Mock<ITicketRepository> ticketRepo;
        Mock<IGuestRepository> guestRepo;
        List<TotalEventSale> expectedSales;
        List<TicketsByGuest> expectedTickets;
        List<NoOfMalesFemalesInEvent> expectedMales;
        
        private AdminstratorLogic CreateLogic()
        {
            guestRepo = new Mock<IGuestRepository>();
            ticketRepo = new Mock<ITicketRepository>();
            eventRepo = new Mock<IEventRepository>();


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
            Events boatParty = new Events()
            {
                Id = 1,
                Name = "Boat Party",
                StartDate = "5 Oct 2020",
                EndDate = "7 Oct 2020",
                OganizarName = "Vishav",
                EntryFee = 500,
                Place = "Chain Bridge",
                Tickets = { ticket1 },
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
                Tickets = { ticket2 },
            };
            ticket1.Events = boatParty;
            ticket2.Events = morisonParty;
            
            Guest piyush = new Guest()
            {
                ID = 1,
                Name = "Piyush",
                City = "Dhuri",
                Contact = "264446658",
                Email = "piyush@GMAIL.COM",
                Gender = "Male",
                Tickets = { ticket1},
            };
            Guest vishav = new Guest()
            {
                ID = 2,
                Name = "Vishav",
                City = "Dhuri",
                Contact = "684323565",
                Email = "vishav@GMAIL.COM",
                Gender = "Male",
                Tickets = { ticket2},
            };
            
            List<Guest> guests = new List<Guest> {piyush, vishav };
            List<Events> events = new List<Events> { morisonParty, boatParty };
            List<Ticket> tickets = new List<Ticket> { ticket1, ticket2 };

            this.expectedSales = new List<TotalEventSale>()
            {
                new TotalEventSale() { EventName = "Boat Party", TicketPrice = 500 },
                new TotalEventSale() { EventName = "Morison Party", TicketPrice = 500 },
            };

            this.expectedTickets = new List<TicketsByGuest>()
            {
                new TicketsByGuest() { GuestName = "Piyush", Tickets = new List<Ticket>()
                {
                    new Ticket()
                    {
                        Id = 1,
                        Expiry = "7 Oct 2020",
                        Discount = 0,
                        OrderInfo = "No discount",
                        PricePaid = 500,
                        Type = "VIP",
                        EventId = 1,
                        GuestId = 1,
                    },
                },
                },
                new TicketsByGuest() { GuestName = "Vishav", Tickets = new List<Ticket>() { new Ticket()
                    {
                        Id = 2,
                        Expiry = "7 Oct 2020",
                        Discount = 0,
                        OrderInfo = "No discount",
                        PricePaid = 500,
                        Type = "VIP",
                        EventId = 2,
                        GuestId = 2,
                    },
                },
                },
            };

            this.expectedMales = new List<NoOfMalesFemalesInEvent>() { new NoOfMalesFemalesInEvent() { EventName = "Morison Party", NoOfFemales = 0, NoOfMales = 0},
            new NoOfMalesFemalesInEvent() { EventName = "Boat Party", NoOfFemales = 0, NoOfMales = 0},};

            this.ticketRepo.Setup(repo => repo.GetAll()).Returns(tickets.AsQueryable());
            this.guestRepo.Setup(repo => repo.GetAll()).Returns(guests.AsQueryable());
            this.eventRepo.Setup(repo => repo.GetAll()).Returns(events.AsQueryable());

            return new AdminstratorLogic(this.ticketRepo.Object, this.eventRepo.Object, this.guestRepo.Object);

        }

       [Test]
        public void TestEventSale()
        {
            var logic = this.CreateLogic();

            var actualEventSales = logic.GetEventSale();

            Assert.That(actualEventSales, Is.EquivalentTo(expectedSales));
        }

        [Test]
        public void TicketsBySingleGuestTest()
        {
            var logic = this.CreateLogic();

            var actualResult = logic.TicketsBySingleGuest();

            for (int i = 0; i < actualResult.ToList().Count; i++)
            {
                Assert.That(actualResult.ToList()[i].GuestName == expectedTickets[i].GuestName);
            }
        }

        [Test]
        public void TestNoOfMalesAndFemales()
        {
            var logic = CreateLogic();

            var actualResult = logic.GetNoOfMalesFemalesList();

            for(int i = 0;i<actualResult.ToList().Count; i++)
            {
                Assert.That(actualResult.ToList()[i].EventName == expectedMales[i].EventName);
                Assert.That(actualResult.ToList()[1].NoOfMales == expectedMales[i].NoOfMales);
                Assert.That(actualResult.ToList()[1].NoOfFemales == expectedMales[i].NoOfFemales);
            }
        }
    }
}
