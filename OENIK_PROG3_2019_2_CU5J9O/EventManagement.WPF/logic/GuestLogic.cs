namespace EventManagement.WPF.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using EventManagement.Data.Models;
    using EventManagement.Repository;
    using EventManagement.WPF.Data;
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
        /// <param name="guests">List of guests.</param>
        public void Add(IList<GuestModel> guests)
        {
            if (guests != null)
            {
                GuestModel newGuest = new GuestModel();
                if (this.editorService.EditGuest(newGuest) == true)
                {
                    guests.Add(newGuest);
                    Guest guest = new Guest()
                    {
                        Name = newGuest.Name,
                        ID = newGuest.ID,
                        City = newGuest.City,
                        Email = newGuest.Email,
                        Gender = newGuest.Gender,
                        Contact = newGuest.Contact,
                    };
                    this.guestRepository.Insert(guest);
                    this.messengerService.Send("Add Ok");
                }
            }
        }

        /// <summary>
        /// This function is used to delete the selected guest from the database.
        /// </summary>
        /// <param name="guests">List of guests.</param>
        /// <param name="guest">Guest Object.</param>
        public void Delete(IList<GuestModel> guests, GuestModel guest)
        {
            if (guests != null && guest != null)
            {
                this.guestRepository.Remove(guest.ID);
                guests.Remove(guest);
            }
        }

        /// <summary>
        /// This function is used to edit the detail of selected Guest.
        /// </summary>
        /// <param name="guest">Guest type parameter.</param>
        public void Edit(GuestModel guest)
        {
            if (guest == null)
            {
                this.messengerService.Send("Edit failed", "Logic Result");
                return;
            }

            GuestModel clone = new GuestModel();
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
        public IList<GuestModel> GetAllGuests()
        {
            IList<Guest> entityList = this.guestRepository.GetAll().ToList();
            IList<GuestModel> guestModels = new List<GuestModel>();

            foreach (var item in entityList)
            {
                GuestModel guestModel = new GuestModel();
                guestModel.ID = item.ID;
                guestModel.Name = item.Name;
                guestModel.City = item.City;
                guestModel.Contact = item.Contact;
                guestModel.Email = item.Email;
                guestModel.Gender = item.Gender;

                guestModels.Add(guestModel);
            }

            return guestModels;
        }
    }
}
