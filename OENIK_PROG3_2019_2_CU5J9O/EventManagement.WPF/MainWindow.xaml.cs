namespace EventManagement.WPF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using EventManagement.WPF.VM;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel VM;

        /// <summary>
        /// This constructor is called when applications runs.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VM = FindResource("VM") as MainViewModel;
            Messenger.Default.Register<string>(this, "LogicResult", (msg) =>
             {
                 MessageBox.Show(msg);
             });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
        }
    }
}
