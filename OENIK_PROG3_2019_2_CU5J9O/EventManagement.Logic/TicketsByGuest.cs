namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;

    /// <summary>
    /// public class to store the tickets brought by single User.
    /// </summary>
    public class TicketsByGuest
    {
        /// <summary>
        /// Gets or sets guest Name.
        /// </summary>
        public string GuestName { get; set; }

        /// <summary>
        /// Gets or sets tickets List.
        /// </summary>
        public IList<Ticket> Tickets { get; set; }

        /// <summary>
        /// Override equals method to check whether two objects are equal.
        /// </summary>
        /// <param name="obj">other Object.</param>
        /// <returns>Boolean Value.</returns>
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

        /// <summary>
        /// Override GetHashCode method to generate the hash code based on object.
        /// </summary>
        /// <returns>int value (HashCode).</returns>
        public override int GetHashCode()
        {
            return (int)this.Tickets.Count + this.GuestName.GetHashCode();
        }

        /// <summary>
        /// Override toString to generate the string value from the object.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            string s = this.GuestName + "\n";
            foreach (Ticket ticket in this.Tickets)
            {
                s += ticket + "\n";
            }

            return s;
        }
    }
}
