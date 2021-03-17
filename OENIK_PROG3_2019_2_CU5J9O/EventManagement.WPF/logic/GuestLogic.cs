namespace EventManagement.WPF.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using EventManagement.Data.Models;
    using EventManagement.Logic;
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
        private IFactoryLogic factoryLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuestLogic"/> class.
        /// </summary>
        /// <param name="editorService">EditorService Type.</param>
        /// <param name="messengerService">IMessenger Type.</param>
        /// <param name="guestRepository">IGuestRepository Type.</param>
        /// <param name="factoryLogic">IFactory type.</param>
        public GuestLogic(IEditorService editorService, IMessenger messengerService, IGuestRepository guestRepository, IFactoryLogic factoryLogic)
        {
            this.editorService = editorService;
            this.messengerService = messengerService;
            this.guestRepository = guestRepository;
            this.factoryLogic = factoryLogic;
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
                    this.factoryLogic.GetFrontOfficeLogic().Add(newGuest.Name, newGuest.Contact, newGuest.City, newGuest.Email, newGuest.Gender.ToString());
                    this.messengerService.Send("Add Ok", "LogicResult");
                }
                else
                {
                    this.messengerService.Send("Add Canceled", "LogicResult");
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
                this.factoryLogic.GetAdminstratorLogic().RemoveGuest(guest.ID);
                guests.Remove(guest);
                this.messengerService.Send("Successfuly Deleted", "LogicResult");
            }
            else
            {
                this.messengerService.Send("Delete Failed", "LogicResult");
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
                this.messengerService.Send("Edit failed", "LogicResult");
                return;
            }

            GuestModel clone = new GuestModel();
            clone.CopyFrom(guest);

            if (this.editorService.EditGuest(clone) == true)
            {
                guest.CopyFrom(clone);
                Guest guestModified = new Guest()
                {
                    City = guest.City,
                    Name = guest.Name,
                    Contact = guest.Contact,
                    Email = guest.Email,
                    Gender = guest.Gender.ToString(),
                };
                this.guestRepository.EditGuest(guest.ID, guestModified);
                this.messengerService.Send("Edit Ok", "LogicResult");
            }
            else
            {
                this.messengerService.Send("Edit failed", "LogicResult");
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
                guestModel.Gender = Gender.Male;

                guestModels.Add(guestModel);
            }

            return guestModels;
        }
    }
}
