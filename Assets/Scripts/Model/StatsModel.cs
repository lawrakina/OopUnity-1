using Interface;


namespace Model
{
    public sealed class StatsModel
    {
        #region fields

        private IIntNotifyPropertyChange _coinCount;
        private IIntNotifyPropertyChange _maxCoinCount;
        private IIntNotifyPropertyChange _liveCount;

        #endregion


        #region Properties

        public IIntNotifyPropertyChange CoinCount
        {
            get => _coinCount;
            set => _coinCount = value;
        }

        public IIntNotifyPropertyChange MaxCoinCount
        {
            get => _maxCoinCount;
            set => _maxCoinCount = value;
        }

        public IIntNotifyPropertyChange LiveCount
        {
            get => _liveCount;
            set => _liveCount = value;
        }

        #endregion


        #region ClassLiveCycles

        public StatsModel(IIntNotifyPropertyChange coinCount, IIntNotifyPropertyChange maxCoinCount,
            IIntNotifyPropertyChange               liveCount)
        {
            CoinCount = coinCount;
            MaxCoinCount = maxCoinCount;
            LiveCount = liveCount;
        }

        #endregion

    }
}