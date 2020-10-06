namespace EventManagement.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    [Table("events")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Ticket> Tickets { get; set; }

        [MaxLength(50)]
        [Required]
        public string Place { get; set; }

        [MaxLength(50)]
        [Required]
        public string OganizarName { get; set; }

        [MaxLength(50)]
        [Required]
        public string StartDate { get; set; }

        [MaxLength(50)]
        [Required]
        public string EndDate { get; set; }

        public Event()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    }
}
