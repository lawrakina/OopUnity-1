using Controller;
using Data;
using Model;
using View;


namespace Initializator
{
    public sealed class UiInitializator
    {
        public UiInitializator(MainController mainController, GameData gameData, PlayerData playerData)
        {
            var uiInterface = new UiInterface();
            var uiModel = new UiModel()
            {
                Lives = gameData.GameStruct.CountLive,
                Coins = gameData.GameStruct.CountCoins,
                NeedCoins = gameData.GameStruct.CountNeedCoins
            };
            var controller = new UiController(uiInterface, uiModel);
            mainController.AddUpdated(controller);
        }
    }
}