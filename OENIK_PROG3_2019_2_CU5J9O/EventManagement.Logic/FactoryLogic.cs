namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EventManagement.Data.Models;
    using EventManagement.Repository;

    public class FactoryLogic : IFactoryLogic
    {
        EventDbContext eventDb = new EventDbContext();
        GuestRepository guestRepository;
        TicketRepository ticketRepository;
        EventRepository eventRepository;

        public FactoryLogic()
        {
            this.eventRepository = new EventRepository(this.eventDb);
            this.ticketRepository = new TicketRepository(this.eventDb);
            this.guestRepository = new GuestRepository(this.eventDb);
        }

        public AdminstratorLogic GetAdminstratorLogic()
        {
            return new AdminstratorLogic(this.ticketRepository, this.eventRepository, this.guestRepository);
        }

        public FrontOfficeLogic GetFrontOfficeLogic()
        {
            return new FrontOfficeLogic(this.ticketRepository, this.eventRepository, this.guestRepository);
        }

    }
}
