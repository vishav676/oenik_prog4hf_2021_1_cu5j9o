namespace OENIK_PROG3_2020_2_CU5J9O
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
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
            GuestRepository guestRepository = new GuestRepository(eventDb);
            TicketRepository ticketRepository = new TicketRepository(eventDb);
            EventRepository eventRepository = new EventRepository(eventDb);
            BusinessLogic logic = new BusinessLogic(ticketRepository, eventRepository, guestRepository);

            var menu = new ConsoleMenu().
                Add("Tickets", () => TicketMenu(logic)).
                Add("Guests", () => GuestMenu(logic)).
                Add("Events", () => EventMenu(logic)).
                Add("Quit", ConsoleMenu.Close);

            menu.Show();
        }

        public static void TicketMenu(BusinessLogic logic)
        {
            var menu = new ConsoleMenu().
                Add("Sell Tickets", () => SellTicket(logic)).
                Add("Sold Tickets", () => GetAllTickets(logic)).
                Add("Remove Ticket", () => RemoveTicket(logic)).
                Add("Update Ticket", () =>
                {
                    Console.WriteLine("Not Ready");
                    Console.ReadKey();
                }).
                Add("Get Ticket Info", () => GetTicketInfo(logic))
                .Add("Quit", ConsoleMenu.Close);
            menu.Show();
        }

        public static void EventMenu(BusinessLogic logic)
        {
            var menu = new ConsoleMenu()
                .Add("Add new Event", () => AddEvent(logic))
                .Add("Get Event Info", () => AllEvent(logic))
                .Add("Delete Event", () => RemoveEvent(logic))
                .Add("Update Event Place", () => UpdatePlace(logic))
                .Add("Quit", ConsoleMenu.Close);
            menu.Show();
        }

        public static void GuestMenu(BusinessLogic logic)
        {
            var menu = new ConsoleMenu().
                Add("All Guests", () => GetAllGuests(logic)).
                Add("Add Guest", () => addGuest(logic)).
                Add("Guest Info", () => GetGuestInfo(logic)).
                Add("Remove Guest", () => RemoveGuest(logic)).
                Add("Update Guest", () => UpdateName(logic))
                .Add("Quit", ConsoleMenu.Close);
            menu.Show();
        }

        public static void GetTicketInfo(IGuestLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            Console.WriteLine("Enter Ticket Id: ");
            int id = int.Parse(Console.ReadLine());
            Ticket item = logic.GetOneTicket(id);
            if (item != null)
                Console.WriteLine(item.Id + "\t" + item.Guest.Name + "\t" + item.OrderInfo);
            else
                Console.WriteLine("No ticket found with this ID");
            Console.ReadKey();
        }

        public static void ListSale(IGuestLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            foreach (var item in logic.GetEventSale())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public static void addGuest(ILogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

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
            logic.Add(guest);

        }
 
        public static void AddEvent(IGuestLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

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
            logic.Add(g);
        }

        public static void SellTicket(ILogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            bool done = false;
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
                var q1 = logic.Search(name);
                if (q1.Count() == 0)
                {
                    Console.WriteLine("Guest profile doesn't exits");
                    var menu = new ConsoleMenu()
                    .Add("Add new Guest", () => { addGuest(logic); done = true; })
                    .Add("Quit", ConsoleMenu.Close);

                    menu.Show();
                }
                else if (q1.Count == 1)
                {
                    guestId = q1.FirstOrDefault().ID;
                    done = true;
                }
                else if (q1.Count > 1)
                {
                    q1.ToConsole();
                    Console.WriteLine("Enter Guest ID");
                    int id = int.Parse(Console.ReadLine());
                    done = true;
                }
            }

            Console.WriteLine("Event Name: ");
            string eventName = Console.ReadLine();
            var q = logic.SearchEvent(eventName);
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

            logic.Add(ticket);
        }

        public static void AllEvent(IGuestLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            var events = logic.GetAllEvent();
           events.ToConsole();
        }

        public static void RemoveEvent(IGuestLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            Console.WriteLine("Enter Event Id: ");
            int id = int.Parse(Console.ReadLine());

            if (logic.Remove(id))
            {
                Console.WriteLine("Event has been Deleted");
            }
            else
            {
                Console.WriteLine("No such event exists");
            }

            Console.ReadKey();
        }

        public static void RemoveGuest(IGuestLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            Console.WriteLine("Enter Guest Id: ");
            int id = int.Parse(Console.ReadLine());

            if (logic.RemoveGuest(id))
            {
                Console.WriteLine("Guest has been removed.");
            }
            else
            {
                Console.WriteLine("Guest Doesn't exits.");
            }

            Console.ReadKey();
        }

        public static void UpdatePlace(IGuestLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            Console.WriteLine("Enter Event Id");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Event Place");
            string place = Console.ReadLine();

            logic.UpdatePlace(id, place);
        }

        public static void GetAllTickets(IGuestLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            var q = logic.GetAllTickets();
            q.ToConsole();
        }

        public static void GetAllGuests(IGuestLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            var q = logic.GetAllGuests();
            q.ToConsole();
        }

        public static void GetGuestInfo(ILogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            Console.WriteLine("Enter Guest Name to Search: ");
            string name = Console.ReadLine();
            var q = logic.Search(name);
            q.ToConsole();
        }

        public static void UpdateName(IGuestLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            Console.WriteLine("Enter Guest Id:  ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter New Guest Name: ");
            string name = Console.ReadLine();

            logic.ChangeName(id, name);
        }

        public static void RemoveTicket(ILogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            Console.WriteLine("Enter Ticket Id: ");
            int id = int.Parse(Console.ReadLine());

            if (logic.RemoveTicket(id))
            {
                Console.WriteLine("Ticket has been Deleted");
            }
            else
            {
                Console.WriteLine("Ticket Doesn't exits.");
            }

            Console.ReadKey();
        }
    }
}