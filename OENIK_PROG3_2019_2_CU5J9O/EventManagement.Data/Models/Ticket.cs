namespace EventManagement.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    [Table("tickets")]
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Type { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Expiry { get; set; }

        [Required]
        [MaxLength(50)]
        public string OrderInfo { get; set; }

        public int Discount { get; set; }

        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }

        [NotMapped]
        public virtual Event Event { get; set; }

        [ForeignKey(nameof(Guest))]
        public int GuestId { get; set; }

        [NotMapped]
        public virtual Guest Guest { get; set; }

        public Ticket()
        {
        }
    }
}
