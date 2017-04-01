namespace CameraBazaar.Models.ViewModels.Camera
{
    public class AllCameraVm
    {
        public int Id { get; set; }

        // Configure in Automapping
        public string Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        // Configure in Automapping
        public bool InStock { get; set; }

        public string ImageUrl { get; set; }
    }
}
