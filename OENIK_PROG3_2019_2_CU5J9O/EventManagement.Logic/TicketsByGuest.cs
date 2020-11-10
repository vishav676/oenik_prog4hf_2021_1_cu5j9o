namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;

    public class TicketsByGuest
    {
        public string GuestName { get; set; }

        public IList<Ticket> Tickets { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is TotalEventSale)
            {
                TicketsByGuest other = obj as TicketsByGuest;
                return this.GuestName == other.GuestName &&
                    this.Tickets == other.Tickets;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (int)this.Tickets.Count() + this.GuestName.GetHashCode();
        }

        public override string ToString()
        {
            string s = this.GuestName + "\n";
            foreach (Ticket ticket in this.Tickets)
            {
                s += ticket.Id + " " + ticket.Event + " " + ticket.Expiry + " " + ticket.OrderInfo + "\n";
            }

            return s;
        }
    }
}
