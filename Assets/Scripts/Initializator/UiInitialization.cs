using Data;
using Interface;
using UnityEngine;
using UnityEngine.UI;
using View;


namespace Initializator
{
    public sealed class UiInitialization : IInitialization
    {
        #region Fields

        private readonly UiPlay _uiPlay;
        private UiReference _uiReference;

        #endregion


        #region ClassLiveCycles

        public UiInitialization(UiReference uiReference)
        {
            _uiPlay = new UiPlay();
            _uiReference = uiReference;
        }

        #endregion


        #region IInitialization

        public void Initialization()
        {
            
        }

        #endregion


        #region Methods

        public UiPlay GetUi()
        {
            return _uiPlay;
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