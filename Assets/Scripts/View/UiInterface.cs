using UnityEngine;


namespace View
{
    public sealed class UiInterface
    {
        #region Fields

        private LivesUiView _livesUiView;
        private CoinsUiView _coinsUiView;

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

        #endregion
    }
}