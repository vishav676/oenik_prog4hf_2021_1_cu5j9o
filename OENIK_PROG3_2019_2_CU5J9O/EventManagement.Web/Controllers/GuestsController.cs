namespace EventManagement.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using EventManagement.Logic;
    using EventManagement.Web.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This class controll the view for the Guest.
    /// </summary>
    public class GuestsController : Controller
    {
        IFactoryLogic logic;
        IMapper mapper;
        GuestListViewModel vm;

        public GuestsController(IFactoryLogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;

            this.vm = new GuestListViewModel();
            this.vm.EditedGuest = new Models.Guest();

            var guests = logic.GetFrontOfficeLogic().GetAllGuests();
            this.vm.ListOfGuests = mapper.Map<IList<Data.Models.Guest>,
                List<Models.Guest>>(guests);
        }

        private Models.Guest GetGuestModel(int id)
        {
            Data.Models.Guest oneGuest = this.logic.GetFrontOfficeLogic().GetOneGuest(id);
            return this.mapper.Map<Data.Models.Guest, Models.Guest>(oneGuest);
        }

        public IActionResult Index()
        {
            this.ViewData["editAction"] = "AddNew";
            return this.View("GuestIndex", this.vm);
        }

        public IActionResult Details(int id)
        {
            return this.View("GuestsDetails", this.GetGuestModel(id));
        }

        public IActionResult Remove(int id)
        {
            this.TempData["editResult"] = "Delete Fail";

            if (this.logic.GetAdminstratorLogic().RemoveGuest(id))
            {
                this.TempData["editResult"] = "Delete OK";
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        public IActionResult Edit(int id)
        {
            this.ViewData["editAction"] = "Edit";
            this.vm.EditedGuest = this.GetGuestModel(id);
            return this.View("GuestIndex", this.vm);
        }

        [HttpPost]
        public IActionResult Edit(Models.Guest guest, string editAction)
        {
            if (this.ModelState.IsValid && guest != null)
            {
                this.TempData["editResult"] = "Edit Fail";
                if (editAction == "AddNew")
                {
                    this.logic.GetFrontOfficeLogic().Add(guest.Name, guest.Contact, guest.City, guest.Email, guest.Gender);
                    this.TempData["editResult"] = "Edit Ok";
                }
                else
                {
                    if (this.logic.GetAdminstratorLogic().EditGuest(guest.ID, guest.Name, guest.Email, guest.Contact, guest.Gender, guest.City))
                    {
                        this.TempData["editResult"] = "Edit Ok";
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }
            else
            {
                this.ViewData["editAction"] = "Edit";
                this.vm.EditedGuest = guest;
                return this.View("GuestIndex", this.vm);
            }

        }

    }
}
