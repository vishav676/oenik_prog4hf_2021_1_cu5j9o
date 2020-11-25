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

            eventRepo.Setup(m => m.GetAll()).Returns(new List<Events>()
            {
                new Events
                {
                    Id = 1, Name = "Dance Party",
                },
                new Events
                {
                    Id = 1, Name = "Indian Party",
                },
                new Events
                {
                    Id = 1, Name = "Spain Party",
                },
            }.AsQueryable());

            Events testEvent = new Events()
            {
                Name = "DanceParty", OganizarName = "Sonika", StartDate = "12-12-2020", EndDate = "13-12-2020", Place = "India",
            };

            IAdminstratorLogic li = new AdminstratorLogic(ticketRepo.Object, eventRepo.Object, guestRepo.Object);
            li.Add(testEvent.Name, testEvent.OganizarName, testEvent.EndDate, testEvent.StartDate, testEvent.Place);
            eventRepo.Verify(repo => repo.Insert(testEvent));
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
    }
}
