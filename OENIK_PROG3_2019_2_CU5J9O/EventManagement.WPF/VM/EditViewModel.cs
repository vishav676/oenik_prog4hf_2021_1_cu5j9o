namespace EventManagement.WPF.VM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EventManagement.Data.Models;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// This class acts as view Model for editting window.
    /// </summary>
    class EditViewModel : ViewModelBase
    {
        Guest guest;

        public Guest Guest
        {
            get { return guest; }
            set { Set(ref guest, value); }
        }

        public EditViewModel()
        {
            guest = new Guest();

            if (IsInDesignMode)
            {
                guest.Name = "Vishav";
                guest.Gender = "Male";
            }
        }
    }
}
