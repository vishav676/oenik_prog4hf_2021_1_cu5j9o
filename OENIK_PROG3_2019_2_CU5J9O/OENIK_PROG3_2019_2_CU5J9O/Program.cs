namespace OENIK_PROG3_2020_2_CU5J9O
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using ConsoleTools;
    using EventManagement.Data.Models;
    using EventManagement.Logic;
    using EventManagement.Repository;

    /// <summary>
    /// This class contains the main function which will initiate the program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// This is the main method. This will show the menu to user and wait for the choice.
        /// </summary>
        public static void Main()
        {
            FactoryLogic logicGenerator = new FactoryLogic();

            var menu = new ConsoleMenu().
                Add("Front Office", () => FrontOfficeMenu(logicGenerator.GetFrontOfficeLogic())).
                Add("Adminstration Office", () => AdmistartionMenu(logicGenerator.GetAdminstratorLogic())).
                Add("Quit", ConsoleMenu.Close);

            menu.Show();
        }

        /// <summary>
        /// This mehtod will generate the administrator menu to be shown to user.
        /// </summary>
        /// <param name="logic">Adminstrator logic.</param>
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
                .Add("Get No. Of Males and Females in Event", () => NoOfMalesFemales(logic))
                .Add("Tickets by Guest", () => TicketsByGuest(logic))
                .Add("Quit", ConsoleMenu.Close);
            menu.Show();
        }

        /// <summary>
        /// This mehtod will generate the Front Office menu to be shown to user.
        /// </summary>
        /// <param name="logic">Front Office Menu logic.</param>
        public static void FrontOfficeMenu(FrontOfficeLogic logic)
        {
            var menu = new ConsoleMenu().
                Add("Sell Ticket", () => SellTicket(logic)).
                Add("Add Guest", () => AddGuest(logic)).
                Add("Search Guest", () => GetGuestInfo(logic)).
                Add("Search Event", () => GetEventInfo(logic)).
                Add("List of Guests", () => GetAllGuests(logic)).
                Add("Get Ticket Info", () => GetTicketInfo(logic)).
                Add("Sold Tickets", () => GetAllTickets(logic)).
                Add("List Of All Events", () => AllEvent(logic)).
                Add("Quit", ConsoleMenu.Close);
            menu.Show();
        }

        /// <summary>
        /// This method will ask for the input to change the discount on the ticket.
        /// </summary>
        /// <param name="logic"><see cref="IAdminstratorLogic"/>.</param>
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

            if (logic.ChangeTicketDiscount(id, value))
            {
                Console.WriteLine("Updated Successfully");
            }
            else
            {
                Console.WriteLine("No ticket found with this ID.");
            }
        }

        /// <summary>
        /// This method will ask the user for the ticket id and will show the result.
        /// </summary>
        /// <param name="logic"><see cref="IFrontOffice"/>.</param>
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
            {
                Console.WriteLine(item.Id + "\t" + item.Guest.Name + "\t" + item.OrderInfo);
            }
            else
            {
                Console.WriteLine("No ticket found with this ID");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This function will list the total event sales to console.
        /// </summary>
        /// <param name="logic"><see cref="IAdminstratorLogic"/>.</param>
        public static void ListSale(IAdminstratorLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            var result = Task.Run(() => logic.GetEventSale()).Result;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// This method will list the no of males and females in the event.
        /// </summary>
        /// <param name="logic"><see cref="IAdminstratorLogic"/>.</param>
        public static void NoOfMalesFemales(IAdminstratorLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            // var result = Task.Run(() => logic.GetNoOfMalesFemalesList()).Result;
            var result = logic.createTask();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// This method will generate the result with list of tickets brought by single guest.
        /// </summary>
        /// <param name="logic"><see cref="IAdminstratorLogic"/>.</param>
        public static void TicketsByGuest(IAdminstratorLogic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            var result = Task.Run(() => logic.TicketsBySingleGuest()).Result;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// This method will ask the Guest info from the user.
        /// </summary>
        /// <param name="logic"><see cref="IFrontOffice"/>.</param>
        public static void AddGuest(IFrontOffice logic)
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

        /// <summary>
        /// This method will ask the event info from the user.
        /// </summary>
        /// <param name="logic"><see cref="IAdminstratorLogic"/>.</param>
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

            Console.WriteLine("Enter the Entry Fee: ");
            int entryFee = int.Parse(Console.ReadLine());

            logic.Add(name, organizerName, endDate, startDate, place, entryFee);
        }

        /// <summary>
        /// This method will allow user to sell the ticket to guest for particular event.
        /// </summary>
        /// <param name="logic"><see cref="IFrontOffice"/>.</param>
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
                    .Add("Add new Guest", () =>
                    {
                        AddGuest(logic);
                    })
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

        /// <summary>
        /// This method will list all the events in the database to the console.
        /// </summary>
        /// <param name="logic"><see cref="IAdminstratorLogic"/>.</param>
        public static void AllEvent(IFrontOffice logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            var events = logic.GetAllEvent();
            events.ToConsole();
        }

        /// <summary>
        /// This method will ask the user Event Id which needs to be removed.
        /// </summary>
        /// <param name="logic"><see cref="IAdminstratorLogic"/>.</param>
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

        /// <summary>
        /// This method will ask the user Guest Id which needs to be removed.
        /// </summary>
        /// <param name="logic"><see cref="IAdminstratorLogic"/>.</param>
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

        /// <summary>
        /// This method will ask the user Event Id and Place name which needs to be updated..
        /// </summary>
        /// <param name="logic"><see cref="IAdminstratorLogic"/>.</param>
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

            if (logic.UpdatePlace(id, place))
            {
                Console.WriteLine("Updated Succesfully");
            }
            else
            {
                Console.WriteLine("No Event exits with this event Id.");
            }
        }

        /// <summary>
        /// This will show the all the sold tickets.
        /// </summary>
        /// <param name="logic"><see cref="IFrontOffice"/>.</param>
        public static void GetAllTickets(IFrontOffice logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            var q = logic.GetAllTickets();
            q.ToConsole();
        }

        /// <summary>
        /// This will list all the Guest present in the Database.
        /// </summary>
        /// <param name="logic"><see cref="IFrontOffice"/>.</param>
        public static void GetAllGuests(IFrontOffice logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            var q = logic.GetAllGuests();
            q.ToConsole();
        }

        /// <summary>
        /// This method will display the guest info with specfic name.
        /// </summary>
        /// <param name="logic"><see cref="IFrontOffice"/>.</param>
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

        /// <summary>
        /// This method will display the Event info with specfic name.
        /// </summary>
        /// <param name="logic"><see cref="IFrontOffice"/>.</param>
        public static void GetEventInfo(IFrontOffice logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException(nameof(logic));
            }

            Console.WriteLine("Enter Event Name to Search: ");
            string name = Console.ReadLine();
            var q = logic.SearchEvent(name);
            q.ToConsole();
        }

        /// <summary>
        /// This method will ask the user Guest Id and Guest name which needs to be updated..
        /// </summary>
        /// <param name="logic"><see cref="IAdminstratorLogic"/>.</param>
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

            if (logic.ChangeName(id, name))
            {
                Console.WriteLine("Updated Successfully");
            }
            else
            {
                Console.WriteLine("No Guest found with this ID");
            }
        }

        /// <summary>
        /// This method will ask the user Ticket Id which needs to be removed.
        /// </summary>
        /// <param name="logic"><see cref="IAdminstratorLogic"/>.</param>
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