namespace EventManagement.WPF.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EventManagement.Data.Models;
    using EventManagement.Logic.Interfaces;

    /// <summary>
    /// This class acts as editing service for the editing window.
    /// </summary>
    public class EditorSeviceViaWin : IEditorService
    {
        /// <summary>
        /// This initiate the editing window and display message accordingly.
        /// </summary>
        /// <param name="guest">Guest object.</param>
        /// <returns>Boolean value.</returns>
        public bool EditGuest(Guest guest)
        {
            EditorWindow win = new EditorWindow(guest);
            return win.ShowDialog() ?? false;
        }
    }
}
