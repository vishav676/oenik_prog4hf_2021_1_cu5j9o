using CommonServiceLocator;
using EventManagement.Data.Models;
using EventManagement.Logic;
using EventManagement.Logic.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EventManagement.WPF.VM
{

    /// <summary>
    /// 
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        IGuestLogic logic;

        Guest guestSelected;

        /// <summary>
        /// This is a getter / setter for the object guestSelected. 
        /// </summary>
        public Guest GuestSelected
        {
            get => guestSelected;
            set => Set(ref guestSelected, value);
        }

        /// <summary>
        /// This contains the list of guests which will shown to user.
        /// </summary>
        public ObservableCollection<Guest> Guests
        {
            get; private set;
        }

        /// <summary>
        /// This command will add new guest to database.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// This command will delete guest from database.
        /// </summary>
        public ICommand DelCmd { get; private set; }

        /// <summary>
        /// This command will edit guest from database.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// This constructor takes a parameter of interface IGuestLogic.
        /// </summary>
        /// <param name="logic">IGuestLogic object.</param>
        public MainViewModel(IGuestLogic logic)
        {
            this.logic = logic;

            Guests = new ObservableCollection<Guest>(this.logic.GetAllGuests());

            if (IsInDesignMode)
            {
                Guest g = new Guest() {Name = "Bill Gates" };
                Guest g1 = new Guest() {Name = "Elon Musk" };

                Guests.Add(g);
                Guests.Add(g1);
            }

            AddCmd = new RelayCommand(() => this.logic.Add(GuestSelected));
            ModCmd = new RelayCommand(() => this.logic.Edit(GuestSelected));
            DelCmd = new RelayCommand(() => this.logic.Delete(GuestSelected));
        }

        /// <summary>
        /// This constructor will be called when it is design mode.
        /// </summary>
        public MainViewModel() 
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IGuestLogic>())
        {

        }
    }
}
