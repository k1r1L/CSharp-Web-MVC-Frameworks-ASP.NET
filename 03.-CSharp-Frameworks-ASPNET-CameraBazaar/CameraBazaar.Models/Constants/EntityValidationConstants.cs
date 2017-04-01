namespace CameraBazaar.Models.Constants
{
    public class EntityValidationConstants
    {
        public const int CameraMinQuantity = 0;
        public const int CameraMaxQuantity = 100;
        public const int CameraMinShutterSpeedLowest = 1;
        public const int CameraMinShutterSpeedHighest = 30;
        public const int CameraMaxShutterSpeedLowest = 2000;
        public const int CameraMaxShutterSpeedHighest = 8000;
        public const int CameraMinIsoFirstValue = 50;
        public const int CameraMinIsoSecondValue = 100;
        public const int CameraMaxIsoLowest = 200;
        public const int CameraMaxIsoHighest = 409600;
        public const int VideoResolutionTextLength = 15;
        public const int DescriptionMaxLength = 6000;
    }
}
