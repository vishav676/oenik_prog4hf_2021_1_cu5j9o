namespace EventManagement.Logic
{
    using System;

    /// <summary>
    /// public class to store the total Event sale of the Event.
    /// </summary>
    public class TotalEventSale
    {
        /// <summary>
        /// Gets or sets event Name.
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets ticket price.
        /// </summary>
        public int TicketPrice { get; set; }

        /// <summary>
        /// Override toString to generate the string value from the object.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            return $"Event = {this.EventName} ; Total = {this.TicketPrice}";
        }

        /// <summary>
        /// Override equals method to check whether two objects are equal.
        /// </summary>
        /// <param name="obj">other Object.</param>
        /// <returns>Boolean Value.</returns>
        public override bool Equals(object obj)
        {
            if (obj is TotalEventSale)
            {
                TotalEventSale other = obj as TotalEventSale;
                return this.EventName == other.EventName && this.TicketPrice == other.TicketPrice;
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
            return (int)this.TicketPrice + this.EventName.GetHashCode();
        }
    }
}
