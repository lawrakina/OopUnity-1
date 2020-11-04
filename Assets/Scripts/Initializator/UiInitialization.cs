using Data;
using Interface;
using UnityEngine;
using View;


namespace Initializator
{
    public sealed class UiInitialization : IInitialization
    {
        #region Fields

        private readonly UiInterface _uiInterface;
        private UiReference _uiReference;

        #endregion


        #region ClassLiveCycles

        public UiInitialization(UiReference uiReference)
        {
            _uiInterface = new UiInterface();
            _uiReference = uiReference;
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

        public GameObject GetMenuScreen()
        {
            return _uiReference.Menu;
        }

        public GameObject GetPauseScreen()
        {
            return _uiReference.PauseGame;
        }

        public GameObject GetEndScreen()
        {
            return _uiReference.EndGame;
        }
    }
}