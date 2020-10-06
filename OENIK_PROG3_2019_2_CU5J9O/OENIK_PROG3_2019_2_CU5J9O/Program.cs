namespace OENIK_PROG3_2020_2_CU5J9O
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EventManagement.Data.Models;

    public class Program
    {
        public static void Main(string[] args)
        {
            EventDbContext eventDb = new EventDbContext();
            Console.WriteLine("Hello World!");
            eventDb.Tickets.Select(x => $"{x.Id} from {x.Guest.Name}").ToConsole("TICKETS");
        }
    }
}
