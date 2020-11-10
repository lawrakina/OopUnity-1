using Data;
using Interface;
using Model;


namespace Initializator
{
    public sealed class StatisticsInitialization : IInitialization
    {
        #region fields

        private readonly GameData                 _gameData;
        private          IIntNotifyPropertyChange _maxCoinCount;
        private          IIntNotifyPropertyChange _coinCount;
        private          IIntNotifyPropertyChange _liveCount;

        #endregion


        #region ClassLiveCycles

        public StatisticsInitialization(GameData gameData)
        {
            _gameData = gameData;
            _maxCoinCount = new CountNeedCoinsProxy(_gameData.GameStruct.countNeedCoins);
            _coinCount = new CountCoinsProxy(_gameData.GameStruct.countCoins);
            _liveCount = new CountLivesProxy(_gameData.GameStruct.countLive);
        }

        #endregion

        
        public void Initialization()
        {
        }


        #region Methods

        public IIntNotifyPropertyChange GetCoinCount()
        {
            return _coinCount;
        }

        public IIntNotifyPropertyChange GetMaxCoinCount()
        {
            return _maxCoinCount;
        }

        public IIntNotifyPropertyChange GetLiveCount()
        {
            return _liveCount;
        }

        #endregion
    }
}