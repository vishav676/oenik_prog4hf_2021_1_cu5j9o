namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EventManagement.Data.Models;
    using EventManagement.Repository;

    /// <summary>
    /// This logic class will generate the specific logic as required.
    /// </summary>
    public class FactoryLogic : IFactoryLogic
    {
        private EventDbContext eventDb = new EventDbContext();
        private GuestRepository guestRepository;
        private TicketRepository ticketRepository;
        private EventRepository eventRepository;
        private AdminUserRepository adminUserRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryLogic"/> class.
        /// </summary>
        public FactoryLogic()
        {
            this.eventRepository = new EventRepository(this.eventDb);
            this.ticketRepository = new TicketRepository(this.eventDb);
            this.guestRepository = new GuestRepository(this.eventDb);
            this.adminUserRepository = new AdminUserRepository(this.eventDb);
        }

        /// <summary>
        /// This method generate the logic instance of type <see cref="AdminstratorLogic"/>.
        /// </summary>
        /// <returns>Instance of <see cref="AdminstratorLogic"/>.</returns>
        public AdminstratorLogic GetAdminstratorLogic()
        {
            return new AdminstratorLogic(this.ticketRepository, this.eventRepository, this.guestRepository, this.adminUserRepository);
        }

        /// <summary>
        /// This method generate the logic instance of type <see cref="FrontOfficeLogic"/>.
        /// </summary>
        /// <returns>Instance of <see cref="FrontOfficeLogic"/>.</returns>
        public FrontOfficeLogic GetFrontOfficeLogic()
        {
            return new FrontOfficeLogic(this.ticketRepository, this.eventRepository, this.guestRepository);
        }
    }
}
