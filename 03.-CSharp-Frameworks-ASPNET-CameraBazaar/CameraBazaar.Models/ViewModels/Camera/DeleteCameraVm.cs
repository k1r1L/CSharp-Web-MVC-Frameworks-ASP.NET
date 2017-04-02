namespace CameraBazaar.Models.ViewModels.Camera
{
    using Enums;

    public class DeleteCameraVm
    {
        public int Id { get; set; }

        public Make Make { get; set; }

        public string Model { get; set; }
    }
}
