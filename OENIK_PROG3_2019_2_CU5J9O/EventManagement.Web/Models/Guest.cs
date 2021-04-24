namespace EventManagement.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Guest
    {
        [Display(Name = "Guest ID")]
        [Required]
        public int ID { get; set; }

        [Display(Name = "Guest Name")]
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [StringLength(10, MinimumLength = 5)]
        public string Contact { get; set; }

        [Display(Name = "Guest Email")]
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Email { get; set; }

        [Display(Name = "Guest City")]
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string City { get; set; }

        [Display(Name = "Guest Gender")]
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Gender { get; set; }
    }
}
