using UnityEngine;
using UnityEngine.UI;


namespace View
{
    public sealed class UiPlay
    {
        #region Fields

        private LivesUiView _livesUiView;
        private CoinsUiView _coinsUiView;
        private MaxCoinsUiView _maxCoinsUiView;
        private Button _pauseButton;

        #endregion


        #region Properties

        public LivesUiView LivesUiView
        {
            get
            {
                if (!_livesUiView)
                    _livesUiView = Object.FindObjectOfType<LivesUiView>();
                return _livesUiView;
            }
        }

        public CoinsUiView CoinsUiView
        {
            get
            {
                if (!_coinsUiView)
                {
                    _coinsUiView = Object.FindObjectOfType<CoinsUiView>();
                }
                return _coinsUiView;
            }
        }
        
        public MaxCoinsUiView MaxCoinsUiView
        {
            get
            {
                if (!_maxCoinsUiView)
                {
                    _maxCoinsUiView = Object.FindObjectOfType<MaxCoinsUiView>();
                }
                return _maxCoinsUiView;
            }
        }

        public Button PauseButton
        {
            get
            {
                if (!_pauseButton)
                {
                    _pauseButton = Object.FindObjectOfType<Button>();
                }

                return _pauseButton;
            }
        }

        #endregion
    }
}