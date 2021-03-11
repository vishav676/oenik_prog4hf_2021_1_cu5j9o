namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EventManagement.Data.Models;
    using EventManagement.Logic.Interfaces;
    using EventManagement.Repository;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// This class connects the repository layer with wpf windows.
    /// </summary>
    public class GuestLogic : IGuestLogic
    {
        private IGuestRepository guestRepository;
        private IEditorService editorService;
        private IMessenger messengerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuestLogic"/> class.
        /// </summary>
        /// <param name="editorService">EditorService Type.</param>
        /// <param name="messengerService">IMessenger Type.</param>
        /// <param name="guestRepository">IGuestRepository Type.</param>
        public GuestLogic(IEditorService editorService, IMessenger messengerService, IGuestRepository guestRepository)
        {
            this.editorService = editorService;
            this.messengerService = messengerService;
            this.guestRepository = guestRepository;
        }

        /// <summary>
        /// This function inserts the new guest to the database.
        /// </summary>
        /// <param name="guest">Guest type parameter.</param>
        public void Add(Guest guest)
        {
            if (this.editorService.EditGuest(guest) == true)
            {
                this.guestRepository.Insert(guest);
                this.messengerService.Send("Add Ok");
            }
        }

        /// <summary>
        /// This function is used to delete the selected guest from the database.
        /// </summary>
        /// <param name="guest">Guest type parameter.</param>
        public void Delete(Guest guest)
        {
            this.guestRepository.Remove(guest);
        }

        /// <summary>
        /// This function is used to edit the detail of selected Guest.
        /// </summary>
        /// <param name="guest">Guest type parameter.</param>
        public void Edit(Guest guest)
        {
            if (guest == null)
            {
                this.messengerService.Send("Edit failed", "Logic Result");
                return;
            }

            Guest clone = new Guest();
            clone.CopyFrom(guest);

            if (this.editorService.EditGuest(clone) == true)
            {
                guest.CopyFrom(clone);
                this.messengerService.Send("Edit Ok", "Logic Result");
            }
            else
            {
                this.messengerService.Send("Edit failed", "Logic Result");
            }
        }

        /// <summary>
        /// This function gets the list of guests from the database.
        /// </summary>
        /// <returns>IList of Guest type.</returns>
        public IList<Guest> GetAllGuests()
        {
            return this.guestRepository.GetAll().ToList();
        }
    }
}
