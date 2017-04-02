namespace CameraBazaar.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Models.EntityModels;
    using Models.ViewModels.Camera;
    using Services;

    [Authorize]
    public class CameraController : Controller
    {
        private CameraService service;

        public CameraController()
        {
            this.service = new CameraService();
        }

        // GET: Camera
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddCameraVm bindingModel)
        {
            if (ModelState.IsValid)
            {
                string username = this.HttpContext.User.Identity.Name;
                this.service.AddCamera(bindingModel, username);
                return this.RedirectToAction("All");
            }

            return this.View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult All()
        {
            IEnumerable<AllCameraVm> allCameraVms = this.service.RetrieveAllCameras();

            return View(allCameraVms);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Details(int id)
        {
            DetailsCameraVm detailsCameraVm = this.service.RetrieveDetailsCamera(id);

            return this.View(detailsCameraVm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Camera cameraEntity = this.service.RetreiveCameraById(id);
            if (cameraEntity == null || cameraEntity.Owner.UserName != HttpContext.User.Identity.Name)
            {
                return RedirectToAction("All");
            }

            EditCameraVm editCameraVm = this.service.RetrieveEditCamera(cameraEntity);

            return View(editCameraVm);
        }

        [HttpPost]
        public ActionResult Edit(EditCameraVm vm)
        {
            if (ModelState.IsValid)
            {
                this.service.EditCamera(vm);
                return RedirectToAction("All");
            }

            return this.View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Camera cameraEntity = this.service.RetreiveCameraById(id);
            if (cameraEntity == null || cameraEntity.Owner.UserName != HttpContext.User.Identity.Name)
            {
                return RedirectToAction("All");
            }

            DeleteCameraVm deleteCameraVm = this.service.RetrieveDeleteCamera(cameraEntity);

            return this.View(deleteCameraVm);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Camera cameraEntity = this.service.RetreiveCameraById(id);
            if (cameraEntity == null || cameraEntity.Owner.UserName != HttpContext.User.Identity.Name)
            {
                return RedirectToAction("All");
            }

            this.service.DeleteCamera(cameraEntity);
            return this.RedirectToAction("All");
        }
    }
}