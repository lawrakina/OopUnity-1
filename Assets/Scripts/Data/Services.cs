using Controller;


namespace Data
{
    public sealed class Services
    {
        public MainController MainController { get; }
        public InputController InputController { get; set; }
        public PlayerController PlayerController { get; set; }
        public CameraController ThirdCameraController { get; set; }

        public Services(MainController mainController)
        {
            MainController = mainController;
        }
    }
}