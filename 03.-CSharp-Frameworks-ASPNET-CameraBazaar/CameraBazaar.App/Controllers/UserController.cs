using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CameraBazaar.App.Controllers
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Models.EntityModels;
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

        [HttpPost]
        public ActionResult EditProfile([Bind(Include = "Email,Password,PhoneNumber,NewPassword,UserName")]EditProfileVm vm)
        {
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            if (this.ModelState.IsValid)
            {
                ApplicationUser appUser = this.service.GetCurrentUser(this.User.Identity.Name);
                userManager.ChangePassword(appUser.Id, vm.Password, vm.NewPassword);
                this.service.ChangeEmailAndNumber(vm, appUser);

                return this.Redirect("/Home/Index");
            }

            return this.View();
        }
    }
}