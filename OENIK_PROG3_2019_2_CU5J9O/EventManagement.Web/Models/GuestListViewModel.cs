namespace EventManagement.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// This class is the viewmodel for the Guest model.
    /// </summary>
    public class GuestListViewModel
    {
        /// <summary>
        /// Gets or sets the edited Guest.
        /// </summary>
        public Guest EditedGuest { get; set; }

        /// <summary>
        /// Gets or sets the list of the guests.
        /// </summary>
        public List<Guest> ListOfGuests { get; set; }
    }
}
