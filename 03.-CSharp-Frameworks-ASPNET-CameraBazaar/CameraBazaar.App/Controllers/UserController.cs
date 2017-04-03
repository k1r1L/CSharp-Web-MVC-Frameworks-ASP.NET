using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CameraBazaar.App.Controllers
{
    using Models.ViewModels.User;
    using Services;

    [Authorize]
    public class UserController : Controller
    {
        private UserService service;

        public UserController()
        {
            this.service = new UserService();
        }

        // GET: User
        [HttpGet]
        public ActionResult Profile(string name)
        {
            ProfileVm profileVm = this.service.RetrieveProfileVm(name);

            return View(profileVm);
        }

        [HttpGet]
        public ActionResult EditProfile(string username)
        {
            if (username != this.HttpContext.User.Identity.Name)
            {
                return this.Redirect("/Home/Index");
            }

            EditProfileVm editProfileVm = this.service.RetrieveEditProfileVm(username);

            return this.View(editProfileVm);
        }
    }
}