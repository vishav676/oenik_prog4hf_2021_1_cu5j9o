using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EventManagement.Client
{
    class MainVM : ViewModelBase
    {
        MainLogic logic;
        private GuestVM selectedGuest;

        private ObservableCollection<GuestVM> allGuests;

        public ObservableCollection<GuestVM> AllGuests
        {
            get { return allGuests; }
            set { Set(ref allGuests, value); }
        }

        public GuestVM SelectedGuest
        {
            get { return selectedGuest; }
            set { Set(ref selectedGuest, value); }
        }

        public ICommand AddCmd { get; private set; }
        public ICommand DelCmd { get; private set; }
        public ICommand ModCmd { get; private set; }
        public ICommand LoadCmd { get; private set; }

        public Func<GuestVM, bool> EditorFunc { get; set; }

        public MainVM()
        {
            logic = new MainLogic();

            LoadCmd = new RelayCommand(() => AllGuests = new ObservableCollection<GuestVM>(logic.ApiGetGuests()));
            DelCmd = new RelayCommand(() => logic.ApiDelGuest(selectedGuest));
            AddCmd = new RelayCommand(() => logic.EditGuest(null, EditorFunc));
            ModCmd = new RelayCommand(() => logic.EditGuest(selectedGuest, EditorFunc)); 
        }
    }
}
