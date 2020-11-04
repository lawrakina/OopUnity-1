using Interface;
using View;


namespace Initializator
{
    public sealed class UiInitialization : IInitialization
    {
        #region Fields

        private readonly UiInterface _uiInterface;

        #endregion


        #region ClassLiveCycles

        public UiInitialization()
        {
            _uiInterface = new UiInterface();
        }

        #endregion


        #region IInitialization

        public void Initialization()
        {
            
        }

        #endregion


        #region Methods

        public UiInterface GetUi()
        {
            return _uiInterface;
        }

        #endregion
    }
}