namespace EventManagement.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    [Table("guests")]
    public class Guest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Contact { get; set; }

        [MaxLength(50)]
        [Required]
        public string City { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        [MaxLength(50)]
        [Required]
        public string Gender { get; set; }

        [NotMapped]
        public virtual ICollection<Ticket> Tickets { get; set; }

        public Guest()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    }
}
