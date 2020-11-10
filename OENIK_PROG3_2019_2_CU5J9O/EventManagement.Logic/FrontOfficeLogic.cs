using EventManagement.Data.Models;
using EventManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventManagement.Logic
{
    public class FrontOfficeLogic : IFrontOffice
    {
        private ITicketRepository ticketRepo;
        private IEventRepository eventRepository;
        private IGuestRepository guestRepository;

        public FrontOfficeLogic(ITicketRepository ticketRepo, IEventRepository eventRepository, IGuestRepository guestRepository)
        {
            this.ticketRepo = ticketRepo;
            this.eventRepository = eventRepository;
            this.guestRepository = guestRepository;
        }
        public void Add(Ticket ticket)
        {
            this.ticketRepo.Insert(ticket);
        }

        public void Add(Guest guest)
        {
            this.guestRepository.Insert(guest);
        }

        public IList<Events> GetAllEvent()
        {
            return this.eventRepository.GetAll().ToList();
        }

        public IList<Guest> GetAllGuests()
        {
            return this.guestRepository.GetAll().ToList();
        }

        public IList<Ticket> GetAllTickets()
        {
            return this.ticketRepo.GetAll().ToList();
        }

        public Ticket GetOneTicket(int id)
        {
            return this.ticketRepo.GetOne(id);
        }

        public IList<Guest> SearchGuest(string name)
        {
            return this.guestRepository.Search(name).ToList();
        }

        public IList<Events> SearchEvent(string name)
        {
            return this.eventRepository.Search(name).ToList();
        }
    }
}
