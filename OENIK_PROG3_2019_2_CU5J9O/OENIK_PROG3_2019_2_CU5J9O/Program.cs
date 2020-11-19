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
            FactoryLogic logicGenerator = new FactoryLogic();

            var menu = new ConsoleMenu().
                Add("Front Office", () => FrontOfficeMenu(logicGenerator.GetFrontOfficeLogic())).
                Add("Adminstration Office", () => AdmistartionMenu(logicGenerator.GetAdminstratorLogic())).
                Add("Quit", ConsoleMenu.Close);

            menu.Show();
        }

        public static void AdmistartionMenu(AdminstratorLogic logic)
        {
            var menu = new ConsoleMenu().
                Add("Add Event", () => AddEvent(logic)).
                Add("Remove Event", () => RemoveEvent(logic)).
                Add("Update Event Place", () => UpdatePlace(logic)).
                Add("Update Ticket Discount", () => ChangeDiscount(logic)).
                Add("Change Guest Name", () => UpdateName(logic)).
                Add("Remove Guest", () => RemoveGuest(logic)).
                Add("Remove Ticket", () => RemoveTicket(logic))
                .Add("Get Event Sale", () => ListSale(logic))
                .Add("Get No Sale", () => NoOfMalesFemales(logic))
                .Add("Tickets by Guest", () => TicketsByGuest(logic))
                .Add("Quit", ConsoleMenu.Close);
            menu.Show();
        }

        public static void FrontOfficeMenu(FrontOfficeLogic logic)
        {
            var menu = new ConsoleMenu().
                Add("Sell Ticket", () => SellTicket(logic)).
                Add("Add Guest", () => addGuest(logic)).
                Add("Search Guest", () => GetGuestInfo(logic)).
                Add("Search Event", () => { Console.WriteLine("Not Ready"); }).
                Add("List of Guests", () => GetAllGuests(logic)).
                Add("Get Ticket Info", () => GetTicketInfo(logic)).
                Add("Sold Tickets", () => GetAllTickets(logic)).
                Add("List Of All Events", () => AllEvent(logic)).
                Add("Quit", ConsoleMenu.Close);
            menu.Show();
        }


        public static void ChangeDiscount(IAdminstratorLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            Console.WriteLine("Enter ticket ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new Discount Value: ");
            int value = int.Parse(Console.ReadLine());

            logic.ChangeTicketDiscount(id, value);
        }

        public static void GetTicketInfo(IFrontOffice logic)
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

        public static void ListSale(IAdminstratorLogic logic)
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

        public static void NoOfMalesFemales(IAdminstratorLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            foreach (var item in logic.GetNoOfMalesFemalesList())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public static void TicketsByGuest(IAdminstratorLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            foreach (var item in logic.TicketsBySingleGuest())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public static void addGuest(IFrontOffice logic)
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
            logic.Add(name, contact, city, email, gender);
        }

        public static void AddEvent(IAdminstratorLogic logic)
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
            string organizerName = Console.ReadLine();

            Console.WriteLine("Enter Start Date: ");
            string startDate = Console.ReadLine();

            Console.WriteLine("Enter End Date: ");
            string endDate = Console.ReadLine();

            logic.Add(name, organizerName, endDate, startDate, place);
        }

        public static void SellTicket(IFrontOffice logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            bool done = false;
            int guestId = 0, eventId = 0;
            Console.WriteLine("Enter Ticket Type ");
            string type = Console.ReadLine();

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
                var q1 = logic.SearchGuest(name);
                if (q1.Count == 0)
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
            int price = logic.CalculatePricePaid(eventId, discount);

            logic.Add(expiry, discount, type, price, orderInfo, guestId, eventId);
        }

        public static void AllEvent(IFrontOffice logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            var events = logic.GetAllEvent();
            events.ToConsole();
        }

        public static void RemoveEvent(IAdminstratorLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            Console.WriteLine("Enter Event Id: ");
            int id = int.Parse(Console.ReadLine());

            if (logic.RemoveEvent(id))
            {
                Console.WriteLine("Event has been Deleted");
            }
            else
            {
                Console.WriteLine("No such event exists");
            }

            Console.ReadKey();
        }

        public static void RemoveGuest(IAdminstratorLogic logic)
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

        public static void UpdatePlace(IAdminstratorLogic logic)
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

        public static void GetAllTickets(IFrontOffice logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            var q = logic.GetAllTickets();
            q.ToConsole();
        }

        public static void GetAllGuests(IFrontOffice logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            var q = logic.GetAllGuests();
            q.ToConsole();
        }

        public static void GetGuestInfo(IFrontOffice logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            Console.WriteLine("Enter Guest Name to Search: ");
            string name = Console.ReadLine();
            var q = logic.SearchGuest(name);
            q.ToConsole();
        }

        public static void UpdateName(IAdminstratorLogic logic)
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

        public static void RemoveTicket(IAdminstratorLogic logic)
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