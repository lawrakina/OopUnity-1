using Interface;
using View;


namespace Controller
{
    public sealed class UiController : IInitialization, ICleanup
    {
        #region Fields

        private UiInterface _ui;
        private IIntNotifyPropertyChange _coinCount;
        private IIntNotifyPropertyChange _maxCoinCount;
        private IIntNotifyPropertyChange _liveCount;

        #endregion


        #region ClassLiveCycles

        public UiController(
            UiInterface ui, 
            IIntNotifyPropertyChange coinCount, 
            IIntNotifyPropertyChange maxCoinCount, 
            IIntNotifyPropertyChange liveCount)
        {
            _ui = ui;
            _coinCount = coinCount;
            _maxCoinCount = maxCoinCount;
            _liveCount = liveCount;
            
            _coinCount.OnValueChange += CoinCountOnValueChange;
            _maxCoinCount.OnValueChange += MaxCoinCountOnValueChange;
            _liveCount.OnValueChange += LiveCountOnValueChange;
        }

        #endregion


        #region IInitialization

        public void Initialization()
        {
            
        }

        #endregion

        
        #region ICleanup

        public void Cleanup()
        {
            _coinCount.OnValueChange -= CoinCountOnValueChange;
            _maxCoinCount.OnValueChange -= MaxCoinCountOnValueChange;
            _liveCount.OnValueChange -= LiveCountOnValueChange;
        }

        #endregion


        #region Methods
        
        private void LiveCountOnValueChange(int value)
        {
            _ui.LivesUiView.Text = $"Live: {value}";
        }

        private void MaxCoinCountOnValueChange(int value)
        {
            _ui.MaxCoinsUiView.Text = $"/{value}";
        }

        private void CoinCountOnValueChange(int value)
        {
            _ui.CoinsUiView.Text = $"{value}";
        }

        #endregion
    }
}