using AutoMapper;
using EventManagement.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Web.Controllers
{
    public class GuestsApiController : Controller
    {
        public class ApiResult
        {
            public bool OperationResult { get; set; }
        }

        private IFactoryLogic logic;
        IMapper mapper;

        public GuestsApiController(IFactoryLogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;
        }

        [HttpGet]
        [ActionName("all")]
        public IEnumerable<Models.Guest> GetAll()
        {
            var guests = logic.GetFrontOfficeLogic().GetAllGuests();
            return mapper.Map<IList<Data.Models.Guest>, List<Models.Guest>>(guests);
        }

        [HttpGet]
        [ActionName("del")]
        public ApiResult DelOneGuest(int id)
        {
            return new ApiResult() { OperationResult = logic.GetAdminstratorLogic().RemoveGuest(id) };
        }

        [HttpPost]
        [ActionName("add")]
        public ApiResult AddOneCar(Models.Guest guest)
        {
            bool success = true;
            try
            {
                logic.GetFrontOfficeLogic().Add(guest.Name, guest.Contact, guest.City, guest.Email, guest.Gender);
            }
            catch(ArgumentException ex)
            {
                success = false;
            }

            logic.GetFrontOfficeLogic().Add(guest.Name, guest.Contact, guest.City, guest.Email, guest.Gender);
            return new ApiResult() { OperationResult = success };
        }

        [HttpPost]
        [ActionName("mod")]
        public ApiResult EditOneCar(Models.Guest guest)
        {
            return new ApiResult() { OperationResult = logic.GetAdminstratorLogic().EditGuest(guest.ID, guest.Name, guest.Email, guest.Contact, guest.Gender, guest.City) };
        }
    }
}
