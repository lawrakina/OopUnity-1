using Controller;
using Data;
using View;


namespace Initializator
{
    public class CameraInitializator
    {
        public CameraInitializator(Services services, GameContext context, CameraView mainCamera)
        {
            services.ThirdCameraController = new CameraController(mainCamera, context);
            services.MainController.AddUpdated(services.ThirdCameraController);
        }
    }
}