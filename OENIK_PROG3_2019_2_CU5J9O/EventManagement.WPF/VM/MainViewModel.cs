namespace EventManagement.WPF.VM
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using CommonServiceLocator;
    using EventManagement.WPF.Data;
    using EventManagement.WPF.Logic;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// This class act as viewmodel for the main window.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IGuestLogic logic;

        private GuestModel guestSelected;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// This constructor takes a parameter of interface IGuestLogic.
        /// </summary>
        /// <param name="logic">IGuestLogic object.</param>
        public MainViewModel(IGuestLogic logic)
        {
            this.logic = logic;

            this.Guests = new ObservableCollection<GuestModel>();

            if (this.IsInDesignMode)
            {
                GuestModel g = new GuestModel() { Name = "Bill Gates" };
                GuestModel g1 = new GuestModel() { Name = "Elon Musk" };

                this.Guests.Add(g);
                this.Guests.Add(g1);
            }

            this.AddCmd = new RelayCommand(() => this.logic.Add(this.Guests));
            this.ModCmd = new RelayCommand(() => this.logic.Edit(this.GuestSelected));
            this.DelCmd = new RelayCommand(() => this.logic.Delete(this.Guests, this.GuestSelected));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// This constructor will be called when it is design mode.
        /// </summary>
        public MainViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IGuestLogic>())
        {
        }

        /// <summary>
        /// Gets or sets this is a getter / setter for the object guestSelected.
        /// </summary>
        public GuestModel GuestSelected
        {
            get => this.guestSelected;
            set => this.Set(ref this.guestSelected, value);
        }

        /// <summary>
        /// Gets this contains the list of guests which will shown to user.
        /// </summary>
        public ObservableCollection<GuestModel> Guests
        {
            get; private set;
        }

        /// <summary>
        /// Gets this command will add new guest to database.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets this command will delete guest from database.
        /// </summary>
        public ICommand DelCmd { get; private set; }

        /// <summary>
        /// Gets this command will edit guest from database.
        /// </summary>
        public ICommand ModCmd { get; private set; }
    }
}
