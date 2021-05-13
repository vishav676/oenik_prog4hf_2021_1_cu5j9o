namespace EventManagement.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using EventManagement.Logic;
    using Microsoft.AspNetCore.Mvc;

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

        [ActionName("all")]
        [HttpGet]
        // GET CarsApi/all
        public IEnumerable<Models.Guest> GetAll()
        {
            var guests = logic.GetFrontOfficeLogic().GetAllGuests();
            return mapper.Map<IList<Data.Models.Guest>, List<Models.Guest>>(guests);
        }

        [ActionName("del")]
        [HttpGet]
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
                logic.GetFrontOfficeLogic().Add(guest.Name,guest.Contact, guest.City, guest.Email, guest.Gender);
            }
            catch (ArgumentException ex)
            {
                success = false;
            }

            return new ApiResult() { OperationResult = success };
        }

        [HttpPost]
        [ActionName("mod")]
        public ApiResult ModOneCar(Models.Guest guest)
        {
            return new ApiResult()
            {
                OperationResult = logic.GetAdminstratorLogic().EditGuest(guest.ID, guest.Name, guest.Email, guest.Contact, guest.Gender, guest.City)
            };
        }
    }
}
