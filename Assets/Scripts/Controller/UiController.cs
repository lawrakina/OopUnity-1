using Interface;
using Model;
using View;


namespace Controller
{
    public sealed class UiController : IEnabled
    {
        #region Fields

        private UiInterface _ui;
        private UiModel _model;

        #endregion


        #region ctor

        public UiController(UiInterface ui, UiModel model)
        {
            _ui = ui;
            _model = model;
        }

        #endregion

        public void On()
        {
            _model.Coins.EventChange += CoinsOnEventChange;
            _model.Lives.EventChange += LivesOnEventChange;
        }

        public void Off()
        {
            _model.Coins.EventChange -= CoinsOnEventChange;
            _model.Lives.EventChange -= LivesOnEventChange;
        }

        private void LivesOnEventChange()
        {
            _ui.LivesUiView.Count = _model.Lives.Value;
        }

        private void CoinsOnEventChange()
        {
            _ui.CoinsUiView.Text = $" {_model.Coins.Value}/{_model.NeedCoins.Value}";
        }
    }
}