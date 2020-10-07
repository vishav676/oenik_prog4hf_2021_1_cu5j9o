namespace OENIK_PROG3_2020_2_CU5J9O
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EventManagement.Data.Models;
    using EventManagement.Logic;
    using EventManagement.Repository;

    public class Program
    {
        public static void Main(string[] args)
        {
            EventDbContext eventDb = new EventDbContext();
            TicketRepository ticketRepository = new TicketRepository(eventDb);
            BusinessLogic logic = new BusinessLogic(ticketRepository);


            foreach (var item in logic.GetEventSale())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
