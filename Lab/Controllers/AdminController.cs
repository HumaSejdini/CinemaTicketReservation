using Lab.Domain.DomainModels;
using Lab.Domain.Identity;
using Lab.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public readonly IReservationService _reservationService;
        private readonly UserManager<ShopApplicationUser> userManager;
        public AdminController(IReservationService service, UserManager<ShopApplicationUser> _userManager)
        {
            _reservationService = service;
            this.userManager = _userManager;
        }
        [HttpGet("[action]")]
        public List<Reservation> GetAllActiveReservations()
        {
            return _reservationService.getAllReservations();
        }
        [HttpPost("[action]")]
        public Reservation GetReservationDetails(BaseEntity model)
        {
            return _reservationService.getReservationDetails(model);
        }
        [HttpPost("[action]")]
        public bool ImportAllUsers(List<UserRegistrationDTO> model)
        {
            var status = true;

            foreach (var user in model)
            {
                var userCheck=userManager.FindByEmailAsync(user.Email).Result;
                if (userCheck == null)
                {
                    var newUser = new ShopApplicationUser
                    {
                        UserName = user.Email,
                        NormalizedEmail = user.Email,
                        Email = user.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        UserShoppingCart = new ShoppingCart()
                    };
                    var result = userManager.CreateAsync(newUser, user.Password).Result;
                    status = status && result.Succeeded;
                }
                else
                {
                    continue;
                }
            }

            return status;
        }

    }
}
