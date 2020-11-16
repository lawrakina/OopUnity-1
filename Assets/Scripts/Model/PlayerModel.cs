using Interface;
using Units.Player;


namespace Model
{
    public sealed class PlayerModel
    {
        #region fields

        private IPlayerView                _playerView;
        private IFloatNotifyPropertyChange _playerSpeed;

        #endregion


        #region Properties

        public IPlayerView PlayerView => _playerView;

        public IFloatNotifyPropertyChange PlayerSpeed
        {
            get => _playerSpeed;
            set => _playerSpeed = value;
        }

        #endregion


        #region ClassLiveCycles

        public PlayerModel(IPlayerView playerView, IFloatNotifyPropertyChange playerSpeed)
        {
            _playerView = playerView;
            _playerSpeed = playerSpeed;
        }

        #endregion
    }
}