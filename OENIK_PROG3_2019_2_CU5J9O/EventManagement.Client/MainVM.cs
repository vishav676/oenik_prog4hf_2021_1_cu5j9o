namespace EventManagement.Client
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// This is main viewmodel which handles call the logic to make changes to ui.
    /// </summary>
    public class MainVM : ViewModelBase
    {
        private MainLogic logic;
        private GuestVM selectedGuest;

        private ObservableCollection<GuestVM> allGuests;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVM"/> class.
        /// </summary>
        public MainVM()
        {
            this.logic = new MainLogic();

            this.LoadCmd = new RelayCommand(() => this.AllGuests = new ObservableCollection<GuestVM>(this.logic.ApiGetGuests()));
            this.DelCmd = new RelayCommand(() => this.logic.ApiDelGuest(this.selectedGuest));
            this.AddCmd = new RelayCommand(() => this.logic.EditGuest(null, this.EditorFunc));
            this.ModCmd = new RelayCommand(() => this.logic.EditGuest(this.selectedGuest, this.EditorFunc));
        }

        /// <summary>
        /// Gets or sets All Guests.
        /// </summary>
        public ObservableCollection<GuestVM> AllGuests
        {
            get { return this.allGuests; }
            set { this.Set(ref this.allGuests, value); }
        }

        /// <summary>
        /// Gets or sets Selected Guest.
        /// </summary>
        public GuestVM SelectedGuest
        {
            get { return this.selectedGuest; }
            set { this.Set(ref this.selectedGuest, value); }
        }

        /// <summary>
        /// Gets the AddCmd.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets the DelCmd.
        /// </summary>
        public ICommand DelCmd { get; private set; }

        /// <summary>
        /// Gets the ModCmd.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// Gets the LoadCmd.
        /// </summary>
        public ICommand LoadCmd { get; private set; }

        /// <summary>
        /// Gets or sets the EditorFunc.
        /// </summary>
        public Func<GuestVM, bool> EditorFunc { get; set; }
    }
}
