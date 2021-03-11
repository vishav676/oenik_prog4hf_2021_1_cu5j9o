namespace EventManagement.WPF.UI
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
    using System.Windows.Shapes;
    using EventManagement.Data.Models;
    using EventManagement.WPF.VM;

    /// <summary>
    /// Interaction logic for EditorWindow.xaml.
    /// </summary>
    public partial class EditorWindow : Window
    {
        EditViewModel VM;

        public Guest guest { get => this.VM.Guest; }

        public EditorWindow()
        {
            this.InitializeComponent();
            this.VM = this.FindResource("VM") as EditViewModel;
        }

        public EditorWindow(Guest oldGuest)
            : this()
        {
            this.VM.Guest = oldGuest;
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
