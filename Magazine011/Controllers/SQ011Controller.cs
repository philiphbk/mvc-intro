using System.Collections.Generic;
using Magazine011.Data;
using Magazine011.Services;
using Magazine011.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace Magazine011.Controllers
{
    public class SQ011Controller : Controller
    {
        private readonly IUserService _userService;

        //public List<string> ClassMembers { get; set; } = new List<string>
        //{
        //    "Ifunanya", "Kunle", "Emma I.", "Daniel", "Hope", "Aba", "Ifeanyi",
        //    "Ikechukwu", "Omolara", "Mary", "Tosin", "Akinkumi", "Chidozie", "Ikenna"
        //};

        #region Do not edit this area
        public SQ011Controller(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        public IActionResult Index(string id)
        {
            var users = _userService.Users;

            // map user to the view model

            var usersToList = new List<UserForListViewModel>();

            foreach(var user in users)
            {
                usersToList.Add(
                    new UserForListViewModel
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email
                    }
                );
            }

            return View(usersToList);
        }

    }
}
