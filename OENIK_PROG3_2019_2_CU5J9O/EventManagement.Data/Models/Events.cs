namespace EventManagement.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// This class is marked as table in the Database.
    /// This represents events Table in local Database.
    /// </summary>
    [Table("events")]
    public class Events
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Events"/> class.
        /// </summary>
        public Events()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        /// <summary>
        /// Gets or sets Id.
        /// this property of Class represents Id for table events.
        /// It is unique for every instance and is automatically generated.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Name attribute of the class.
        /// This field stores the Name of the Event.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int EntryFee { get; set; }

        /// <summary>
        /// Gets Tickets attribute of the class.
        /// This virtual field stores the collection of tickets which relates to specific Event.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Ticket> Tickets { get; }

        /// <summary>
        /// Gets or Sets Place attribute of the class.
        /// This field stores the name of the Place where Event is going to be organized.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Place { get; set; }

        /// <summary>
        /// Gets or Sets OganizarName attribute of the class.
        /// This field stores the name of the Organizer who is responsible for organize the event.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string OganizarName { get; set; }

        /// <summary>
        /// Gets or Sets StartDate attribute of the class.
        /// This field stores the date when the event start.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or Sets EndDate attribute of the class.
        /// This field stores the date when the event will end.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string EndDate { get; set; }

        /// <summary>
        /// Override public function to generate string from object data.
        /// </summary>
        /// <returns> String.</returns>
        public override string ToString()
        {
            return $"{this.Name} {this.Place} {this.OganizarName}";
        }
    }
}
