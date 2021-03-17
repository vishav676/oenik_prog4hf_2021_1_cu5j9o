namespace EventManagement.WPF.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EventManagement.Data.Models;
    using EventManagement.WPF.Data;

    /// <summary>
    /// This acts as sevice to edit the guest.
    /// </summary>
    public interface IEditorService
    {
        /// <summary>
        /// This functions edits the selected guest.
        /// </summary>
        /// <param name="guest">Guest type.</param>
        /// <returns>boolean value.</returns>
        public bool EditGuest(GuestModel guest);
    }
}
