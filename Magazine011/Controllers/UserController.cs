using System;
using AutoMapper;
using Magazine011.Services;
using Magazine011.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Magazine011.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Profile(string userId)
        {
            var user = _userService.GetUserById(userId);

            // map to user details view model
            var userDetails = _mapper.Map<UserDetailViewModel>(user);

            return View(userDetails);
        }
    }
}
