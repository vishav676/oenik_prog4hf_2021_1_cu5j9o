namespace EventManagement.WPF.VM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EventManagement.Data.Models;
    using EventManagement.WPF.Data;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// This class acts as view Model for editting window.
    /// </summary>
    public class EditViewModel : ViewModelBase
    {
        private GuestModel guest;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditViewModel"/> class.
        /// </summary>
        public EditViewModel()
        {
            this.guest = new GuestModel();

            if (this.IsInDesignMode)
            {
                this.guest.Name = "Vishav";
                this.guest.Gender = "Male";
            }
        }

        /// <summary>
        /// Gets or sets Guest.
        /// </summary>
        public GuestModel Guest
        {
            get { return this.guest; }
            set { this.Set(ref this.guest, value); }
        }
    }
}
