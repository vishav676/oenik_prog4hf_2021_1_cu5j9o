namespace EventManagement.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// This class represents a table of name guests in the Database..
    /// </summary>
    [Table("guests")]
    public class Guest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Guest"/> class.
        /// </summary>
        public Guest()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        /// <summary>
        /// Gets or sets Id.
        /// this property of Class represents Id for table guests.
        /// It is unique for every instance and is automatically generated.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// Gets or Sets Name attribute of the class.
        /// This field stores the Guest Name for the Event.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Contact attribute of the class.
        /// This field stores the Contact Info of the Guest.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Contact { get; set; }

        /// <summary>
        /// Gets or Sets City attribute of the class.
        /// This field stores the City Name where the Guest is from.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string City { get; set; }

        /// <summary>
        /// Gets or Sets Email attribute of the class.
        /// This field stores the Email Id of the Guest.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Gender attribute of the class.
        /// This field stores the Gender of the Guest.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Gender { get; set; }

        /// <summary>
        /// Gets Tickets attribute of the class.
        /// This virtual field stores the collection of tickets purchased by Guest.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Ticket> Tickets { get; }

        /// <summary>
        /// Override public function to generate string from object data.
        /// </summary>
        /// <returns> String.</returns>
        public override string ToString()
        {
            string s = $"Guest Id: {this.ID} \nGuest Name: {this.Name}\nCity: {this.City} \nContact: {this.Contact} \nGender: {this.Gender}\n";
            return s;
        }

        /// <summary>
        /// Override equals method to check whether two objects are equal.
        /// </summary>
        /// <param name="obj">other Object.</param>
        /// <returns>Boolean Value.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Guest)
            {
                Guest other = obj as Guest;
                return this.Name == other.Name && this.City == other.City
                    && this.Gender == other.Gender && this.Email == other.Email;
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
            return this.ID + this.Gender.GetHashCode() + this.Email.GetHashCode();
        }
    }
}