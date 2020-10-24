using Controller;
using Data;
using View;


namespace Initializator
{
    public class CameraInitializator
    {
        public CameraInitializator(MainController mainController, PlayerData playerData, CameraView mainCamera)
        {
            var controller = new CameraController(playerData.PlayerStruct.Player, mainCamera);
            mainController.AddUpdated(controller);
        }
    }
}