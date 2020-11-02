namespace OENIK_PROG3_2020_2_CU5J9O
{
    using ConsoleTools;
    using EventManagement.Data.Models;
    using EventManagement.Logic;
    using EventManagement.Repository;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            EventDbContext eventDb = new EventDbContext();
            GuestRepository guestRepository = new GuestRepository(eventDb);
            TicketRepository ticketRepository = new TicketRepository(eventDb);
            EventRepository eventRepository = new EventRepository(eventDb);
            BusinessLogic logic = new BusinessLogic(ticketRepository,eventRepository, guestRepository);

            var menu = new ConsoleMenu().
                Add("Sell Tickets", () => sellTicket(logic)).
                Add("Sold Tickets", () => GetAllTickets(logic)).
                Add("Remove Ticket", () => GetAllTickets(logic)).
                Add("Update Ticket", () => GetAllTickets(logic)).
                Add("Get Ticket Info", () => getTicketInfo(logic)).
                Add("View Events", () => AllEvent(logic)).
                Add("Remove Event", () => RemoveEvent(logic)).
                Add("Update Event", () => UpdatePlace(logic)).
                Add("Add New Event", () => addEvent(logic)).
                Add("All Guests", () => getAllGuests(logic)).
                Add("Guest Info", () => getGuestInfo(logic)).
                Add("Remove Guest", () => RemoveGuest(logic)).
                Add("Update Guest", () => RemoveGuest(logic)).
                Add("Quit", ConsoleMenu.Close);

            menu.Show();
        }

        /*static void TicketMenu(ILogic logic)
        {
            var menu = new ConsoleMenu()
                .Add("Add new Ticket", () => getTicketInfo(logic))
                .Add("Get Ticket Info", () => getTicketInfo(logic))
                .Add("Get All Tickets", () => GetAllTickets(logic))
                .Add("Quit", ConsoleMenu.Close);
            menu.Show();
        }

        static void EventMenu(IEventLogic logic)
        {
            var menu = new ConsoleMenu()
                .Add("Add new Event", () => addEvent(logic))
                .Add("Get Event Info", () => AllEvent(logic))
                .Add("Delete Event", () => RemoveEvent(logic))
                .Add("Update Event Place", () => UpdatePlace(logic))
                .Add("Quit", ConsoleMenu.Close);
            menu.Show();
        }

        static void GuestMenu(IGuestLogic logic)
        {
            var menu = new ConsoleMenu()
                .Add("Add new Guest", () => addGuest(logic))
                .Add("Get Guest Info", () => getGuestInfo(logic))
                .Add("Get All Guests", () => getAllGuests(logic))
                .Add("Quit", ConsoleMenu.Close);
            menu.Show();
        }*/

        static void getTicketInfo(IGuestLogic logic)
        {
            Console.WriteLine("Enter Ticket Id: ");
            int id = int.Parse(Console.ReadLine());
            var item = logic.GetOneTicket(id);
            Console.WriteLine(item.Id + "\t" + item.Guest.Name + "\t" + item.OrderInfo);
            Console.ReadKey();
        }

        static void ListSale(IGuestLogic logic)
        {
            foreach (var item in logic.GetEventSale())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
        static void addGuest(ILogic logic)
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Mobile Number: ");
            string contact = Console.ReadLine();

            Console.WriteLine("Enter City: ");
            string city = Console.ReadLine();

            Console.WriteLine("Enter Email Address: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Gender: ");
            string gender = Console.ReadLine();

            Guest guest = new Guest()
            {
                Name = name,
                Contact = contact,
                City = city,
                Email = email,
                Gender = gender,
            };
            logic.add(guest);

        }
 
        static void addEvent(IGuestLogic logic)
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

        static void sellTicket(ILogic logic)
        {
            Boolean done = false;
            int guestId = 0, eventId = 0;
            Console.WriteLine("Enter Ticket Type ");
            string type = Console.ReadLine();

            Console.WriteLine("Enter ticket price ");
            int price = int.Parse(Console.ReadLine());

            Console.WriteLine("Ticket Expiry ");
            string expiry = Console.ReadLine();

            Console.WriteLine("Discount ");
            int discount = int.Parse(Console.ReadLine());

            Console.WriteLine("Order Info ");
            string orderInfo = Console.ReadLine();

            while (!done)
            {
                Console.WriteLine("Guest Name: ");
                string name = Console.ReadLine();
                var q1 = logic.search(name);
                if (q1.Count() == 0)
                {
                    Console.WriteLine("Guest profile doesn't exits");
                    var menu = new ConsoleMenu()
                    .Add("Add new Guest", () => { addGuest(logic); done = true; })
                    .Add("Quit", ConsoleMenu.Close);

                    menu.Show();
                }
                else if(q1.Count == 1)
                {
                    guestId = q1.FirstOrDefault().ID;
                    done = true;
                }
                else if (q1.Count > 1)
                {
                    q1.ToConsole("Guests");
                    Console.WriteLine("Enter Guest ID");
                    int id = int.Parse(Console.ReadLine());
                    done = true;
                }
            }

            Console.WriteLine("Event Name: ");
            string EventName = Console.ReadLine();
            var q = logic.searchEvent(EventName);
            if (q.Count == 1)
            {
                eventId = q.FirstOrDefault().Id;
            }
            else
            {
                Console.WriteLine("Event Doesn't Exists");
                Console.ReadKey();
                return;
            }

            Ticket ticket = new Ticket()
            {
                Expiry = expiry,
                Discount = discount,
                Type = type,
                Price = price,
                OrderInfo = orderInfo,
                GuestId = guestId,
                EventId = eventId,
            };

            logic.add(ticket);
        }

        static void AllEvent(IGuestLogic logic)
        {
           var events = logic.getAllEvent();
           events.ToConsole("All Events");
        }

        static void RemoveEvent(IGuestLogic logic)
        {
            Console.WriteLine("Enter Event Id: ");
            int id = int.Parse(Console.ReadLine());

            if (logic.remove(id))
            {
                Console.WriteLine("Event has been Deleted");
            }
            else
            {
                Console.WriteLine("No such event exists");
            }

            Console.ReadKey();
        }

        static void RemoveGuest(IGuestLogic logic)
        {
            Console.WriteLine("Enter Guest Id: ");
            int id = int.Parse(Console.ReadLine());

            if (logic.removeGuest(id))
            {
                Console.WriteLine("Guest has been removed.");
            }
            else
            {
                Console.WriteLine("Guest Doesn't exits.");
            }

            Console.ReadKey();
        }

        static void UpdatePlace(IGuestLogic logic)
        {
            Console.WriteLine("Enter Event Id");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Event Place");
            string place = Console.ReadLine();

            logic.updatePlace(id, place);
        }

        static void GetAllTickets(IGuestLogic logic)
        {
            var q = logic.GetAllTickets();
            q.ToConsole("Tickets");
        }

        static void getAllGuests(IGuestLogic logic)
        {
            var q = logic.GetAllGuests();
            q.ToConsole("All guests");
        }

        static void getGuestInfo(ILogic logic)
        {
            Console.WriteLine("Enter Guest Name to Search: ");
            String name = Console.ReadLine();
            var q = logic.search(name);
            q.ToConsole("Guests");
        }
    }
}