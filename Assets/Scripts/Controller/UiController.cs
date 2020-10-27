using Interface;
using Model;
using View;


namespace Controller
{
    public sealed class UiController: IUpdated
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


        #region UnityMethods

        public void UpdateTick()
        {
            _ui.LivesUiView.Count = _model.Lives.Value;
            _ui.CoinsUiView.Text = $" {_model.Coins.Value}/{ _model.NeedCoins.Value}";
        }

        #endregion
    }
}