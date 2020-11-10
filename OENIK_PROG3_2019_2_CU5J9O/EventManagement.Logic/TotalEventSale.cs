namespace EventManagement.Logic
{
    using System;

    public class TotalEventSale
    {
        public string EventName { get; set; }

        public int TicketPrice { get; set; }

        public override string ToString()
        {
            return $"Event = {this.EventName} ; Total = {rhis.TicketPrice}";
        }

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

        public override int GetHashCode()
        {
            return (int)this.TicketPrice + this.EventName.GetHashCode();
        }
    }
}
