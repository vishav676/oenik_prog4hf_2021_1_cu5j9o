namespace OENIK_PROG3_2020_2_CU5J9O
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ConsoleTools;
    using EventManagement.Data.Models;
    using EventManagement.Logic;
    using EventManagement.Repository;

    public class Program
    {
        public static void Main(string[] args)
        {
            EventDbContext eventDb = new EventDbContext();
            TicketRepository ticketRepository = new TicketRepository(eventDb);
            EventRepository eventRepository = new EventRepository(eventDb);
            BusinessLogic logic = new BusinessLogic(ticketRepository,eventRepository);

            var menu = new ConsoleMenu().
                Add("Tickets", () => TicketMenu(logic)).
                Add("Guests", () => GuestMenu(logic)).
                Add("Events", () => EventMenu(logic)).
                Add("Quit", ConsoleMenu.Close);

            menu.Show();
        }


        static void TicketMenu(ILogic logic)
        {
            var menu = new ConsoleMenu()
                .Add("Add new Ticket", () => getTicketInfo(logic))
                .Add("Get Ticket Info", () => getTicketInfo(logic))
                .Add("Quit", ConsoleMenu.Close);
            menu.Show();
        }

        static void EventMenu(IEventLogic logic)
        {
            var menu = new ConsoleMenu()
                .Add("Add new Event", () => addEvent(logic))
                .Add("Get Event Info", () => AllEvent(logic))
                .Add("Delete Event", () => RemoveEvent(logic))
                .Add("Quit", ConsoleMenu.Close);
            menu.Show();
        }

        static void GuestMenu(ILogic logic)
        {
            var menu = new ConsoleMenu()
                .Add("Add new Guest", () => getTicketInfo(logic))
                .Add("Get Guest Info", () => getTicketInfo(logic))
                .Add("Quit", ConsoleMenu.Close);
            menu.Show();
        }

        static void getTicketInfo(ILogic logic)
        {
            Console.WriteLine("Enter Ticket Id: ");
            int id = int.Parse(Console.ReadLine());
            var item = logic.GetOneTicket(id);
            Console.WriteLine(item.Id + "\t" + item.Guest.Name + "\t" + item.OrderInfo);
            Console.ReadKey();
        }

        static void ListSale(ILogic logic)
        {
            foreach (var item in logic.GetEventSale())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        static void addEvent(IEventLogic logic)
        {
            Console.WriteLine("Enter Event Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Place Name: ");
            string place = Console.ReadLine();

            Console.WriteLine("Enter Organizer Name: ");
            string OrganizerName = Console.ReadLine();

            Console.WriteLine("Enter Start Date: ");
            string StartDate = Console.ReadLine();

            Console.WriteLine("Enter End Date: ");
            string EndDate = Console.ReadLine();

            Event g = new Event()
            {
                Name = name,
                OganizarName = OrganizerName,
                EndDate = EndDate,
                StartDate = StartDate,
                Place = place,
            };
            logic.add(g);
        }

        static void AllEvent(IEventLogic logic)
        {
           var events = logic.getAllEvent();
           foreach(var item in events)
           {
                Console.WriteLine(item.Id + " "+ item.Name);
           }

           Console.ReadKey();
        }

        static void RemoveEvent(IEventLogic logic)
        {
            Console.WriteLine("Enter Event Id: ");
            int id = int.Parse(Console.ReadLine());

            if(logic.remove(id))
            {
                Console.WriteLine("Event has been Deleted");
            }
            else
            {
                Console.WriteLine("No such event exists");
            }
        }
    }
}