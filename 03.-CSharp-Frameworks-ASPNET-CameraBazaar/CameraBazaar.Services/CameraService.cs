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

        public DetailsCameraVm RetrieveCamera(int id)
        {
            Camera cameraEntity = this.DbContext.Cameras.Find(id);
            DetailsCameraVm detailsCameraVm = Mapper.Map<DetailsCameraVm>(cameraEntity);

            return detailsCameraVm;
        }
    }
}
