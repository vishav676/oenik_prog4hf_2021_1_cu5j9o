namespace EventManagement.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Guest Model for web.
    /// </summary>
    public class Guest
    {
        /// <summary>
        /// Gets or sets ID.
        /// </summary>
        [Display(Name = "Guest ID")]
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [Display(Name = "Guest Name")]
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Contact.
        /// </summary>
        [Display(Name = "Phone Number")]
        [Required]
        [StringLength(10, MinimumLength = 5)]
        public string Contact { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        [Display(Name = "Guest Email")]
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets City.
        /// </summary>
        [Display(Name = "Guest City")]
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets Gender.
        /// </summary>
        [Display(Name = "Guest Gender")]
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Gender { get; set; }
    }
}
