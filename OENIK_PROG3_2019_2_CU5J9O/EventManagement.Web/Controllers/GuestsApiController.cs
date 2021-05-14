namespace EventManagement.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using EventManagement.Logic;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This class is used to apply the CRUD operations on Guest table through the api.
    /// </summary>
    public class GuestsApiController : Controller
    {
        private IFactoryLogic logic;
        private IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuestsApiController"/> class.
        /// </summary>
        /// <param name="logic">Factory logic.</param>
        /// <param name="mapper">IMapper.</param>
        public GuestsApiController(IFactoryLogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;
        }

        /// <summary>
        /// This method fetch all the guest from the database.
        /// </summary>
        /// <returns>IEnumerable.</returns>
        [ActionName("all")]
        [HttpGet]
        public IEnumerable<Models.Guest> GetAll()
        {
            var guests = this.logic.GetFrontOfficeLogic().GetAllGuests();
            return this.mapper.Map<IList<Data.Models.Guest>, List<Models.Guest>>(guests);
        }

        /// <summary>
        /// This method deletes the Guest from database.
        /// </summary>
        /// <param name="id">Guest Id.</param>
        /// <returns>Api result.</returns>
        [ActionName("del")]
        [HttpGet]
        public ApiResult DelOneGuest(int id)
        {
            return new ApiResult() { OperationResult = this.logic.GetAdminstratorLogic().RemoveGuest(id) };
        }

        /// <summary>
        /// This method adds the guest to database.
        /// </summary>
        /// <param name="guest">Guest.</param>
        /// <returns>ApiResult.</returns>
        [HttpPost]
        [ActionName("add")]
        public ApiResult AddOneGuest(Models.Guest guest)
        {
            if (guest == null)
            {
                throw new ArgumentNullException(nameof(guest));
            }

            bool success = true;
            try
            {
                this.logic.GetFrontOfficeLogic().Add(guest.Name, guest.Contact, guest.City, guest.Email, guest.Gender);
            }
            catch (ArgumentException)
            {
                success = false;
            }

            return new ApiResult() { OperationResult = success };
        }

        /// <summary>
        /// This method is used to modify the guest.
        /// </summary>
        /// <param name="guest">Guest.</param>
        /// <returns>Api result.</returns>
        [HttpPost]
        [ActionName("mod")]
        public ApiResult ModOneGuest(Models.Guest guest)
        {
            if (guest == null)
            {
                throw new ArgumentNullException(nameof(guest));
            }

            return new ApiResult()
            {
                OperationResult = this.logic.GetAdminstratorLogic().EditGuest(guest.ID, guest.Name, guest.Email, guest.Contact, guest.Gender, guest.City),
            };
        }

        /// <summary>
        /// Class to store the result of the query.
        /// </summary>
        public class ApiResult
        {
            /// <summary>
            /// Gets or sets a value indicating whether query was succesful.
            /// </summary>
            public bool OperationResult { get; set; }
        }
    }
}
