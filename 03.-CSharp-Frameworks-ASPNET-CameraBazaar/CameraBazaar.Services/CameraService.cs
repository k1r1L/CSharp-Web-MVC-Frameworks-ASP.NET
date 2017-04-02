namespace CameraBazaar.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Models.EntityModels;
    using Models.ViewModels.Camera;

    public class CameraService : Service
    {
        public void AddCamera(AddCameraVm bindingModel, string username)
        {
            Camera cameraEntity = Mapper.Map<Camera>(bindingModel);
            cameraEntity.Owner = this.RetrieveCurrentUser(username);
            this.DbContext.Cameras.Add(cameraEntity);
            this.DbContext.SaveChanges();
        }

        public IEnumerable<AllCameraVm> RetrieveAllCameras()
        {
            IEnumerable<Camera> cameraEntities = this.DbContext.Cameras;
            IEnumerable<AllCameraVm> cameraVms =
                Mapper.Map<IEnumerable<Camera>, IEnumerable<AllCameraVm>>(cameraEntities);

            return cameraVms;
        }

        public DetailsCameraVm RetrieveDetailsCamera(int id)
        {
            Camera cameraEntity = this.DbContext.Cameras.Find(id);
            DetailsCameraVm detailsCameraVm = Mapper.Map<DetailsCameraVm>(cameraEntity);

            return detailsCameraVm;
        }

        public Camera RetreiveCameraById(int id)
        {
            return this.DbContext.Cameras.Find(id);
        }

        public EditCameraVm RetrieveEditCamera(Camera cameraEntity)
        {
            EditCameraVm vm = Mapper.Map<EditCameraVm>(cameraEntity);

            return vm;
        }

        public void EditCamera(EditCameraVm vm)
        {
            Camera cameraEntity = this.RetreiveCameraById(vm.Id);
            cameraEntity.Model = vm.Model;
            cameraEntity.Make = vm.Make;
            cameraEntity.Price = vm.Price;
            cameraEntity.Quantity = vm.Quantity;
            this.DbContext.SaveChanges();
        }

        public DeleteCameraVm RetrieveDeleteCamera(Camera cameraEntity)
        {
            DeleteCameraVm deleteCameraVm = Mapper.Map<DeleteCameraVm>(cameraEntity);

            return deleteCameraVm;
        }

        public void DeleteCamera(Camera cameraEntity)
        {
            this.DbContext.Cameras.Remove(cameraEntity);
            this.DbContext.SaveChanges();
        }
    }
}
