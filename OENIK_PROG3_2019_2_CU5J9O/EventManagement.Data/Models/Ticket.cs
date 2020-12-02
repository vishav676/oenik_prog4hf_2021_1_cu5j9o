namespace EventManagement.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// This class is represents table in the Database.
    /// Name of the table is tickets.
    /// which store the info related to tickets of the Events.
    /// </summary>
    [Table("tickets")]
    public class Ticket
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ticket"/> class.
        /// </summary>
        public Ticket()
        {
        }

        /// <summary>
        /// Gets or sets Id.
        /// this property of Class represents Id for table tickets.
        /// It is unique for every instance and is automatically generated.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Type attribute of the class.
        /// This field stores the type of the Ticket.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Price attribute of the class.
        /// This field stores the Price of the Ticket.
        /// </summary>
        [Required]
        public int PricePaid { get; set; }

        /// <summary>
        /// Gets or Sets Expiry attribute of the class.
        /// This field stores Expiration Date of the Ticket.
        /// This is manadatory property.
        /// </summary>
        [Required]
        public string Expiry { get; set; }

        /// <summary>
        /// Gets or Sets Order Info attribute of the class.
        /// This field stores any information related to Ticket Sold.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string OrderInfo { get; set; }

        /// <summary>
        /// Gets or Sets Discount attribute of the class.
        /// This field stores infomation about the discount given to Guest when Ticket was Sold.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        public int Discount { get; set; }

        /// <summary>
        /// Gets or Sets Event Id attribute of the class.
        /// This field is a foriegn key to the id of Event in events Table.
        /// This will store for which event the ticket was sold.
        /// </summary>
        [ForeignKey(nameof(Events))]
        public int EventId { get; set; }

        /// <summary>
        /// Gets or Sets Event attribute of the class.
        /// This field will act as navigaton property to get the infomation of the Event.
        /// </summary>
        [NotMapped]
        public virtual Events Events { get; set; }

        /// <summary>
        /// Gets or Sets Guest Id attribute of the class.
        /// This field is a foriegn key to the id of Guest in guestss Table.
        /// This will store to whom the ticket was sold.
        /// </summary>
        [ForeignKey(nameof(Guest))]
        public int GuestId { get; set; }

        /// <summary>
        /// Gets or Sets Guest attribute of the class.
        /// This field will act as navigaton property to get the infomation of the Guest.
        /// </summary>
        [NotMapped]
        public virtual Guest Guest { get; set; }

        /// <summary>
        /// Override public function to generate string from object data.
        /// </summary>
        /// <returns> String.</returns>
        public override string ToString()
        {
            return $"{this.Id} {this.Guest.Name} {this.Discount}";
        }

        /// <summary>
        /// Override equals method to check whether two objects are equal.
        /// </summary>
        /// <param name="obj">other Object.</param>
        /// <returns>Boolean Value.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Ticket)
            {
                Ticket other = obj as Ticket;
                return this.Type == other.Type && this.PricePaid == other.PricePaid
                    && this.GuestId == other.GuestId && this.EventId == other.EventId
                    && this.Discount == other.Discount && this.OrderInfo == other.OrderInfo;
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
            return this.Id + this.PricePaid + this.Discount;
        }
    }
}
