using System;
using Controller.TimeRemaining;
using Enum;
using Healper;
using Interface;
using Model;
using Units.Player;
using UnityEngine;


namespace Controller
{
    public sealed class PlayerBehaviorController : IInitialization, ICleanup
    {
        #region Fields

        private IPlayerView                    _playerView;
        private StatsModel                     _statsModel;
        private PlayerModel                    _playerModel;
        private IGameStateNotifyPropertyChange _gameState;

        private TimeRemaining.TimeRemaining _timerPainting;
        private TimeRemaining.TimeRemaining _timerSpeedUp;
        private TimeRemaining.TimeRemaining _timerImmunity;

        private float _cashStartSpeedPlayer;
        private float _standardTime = 5.0f;
        private bool  _playerImmunity;

        #endregion


        #region ClassLiveCycles

        public PlayerBehaviorController(
            PlayerModel                    playerModel,
            StatsModel                     statsModel,
            IGameStateNotifyPropertyChange gameState)
        {
            _playerView = playerModel.PlayerView;
            _gameState = gameState;
            _statsModel = statsModel;
            _playerModel = playerModel;
        }

        #endregion


        #region IInitialization

        public void Initialization()
        {
            _cashStartSpeedPlayer = _playerModel.PlayerSpeed.Value;

            _timerPainting = TimerPainting(_standardTime);
            _timerSpeedUp = TimerSpeedUp(_standardTime);
            _timerImmunity = TimerImmunity(_standardTime);
        }

        #endregion


        #region ICollision

        private void PlayerViewBonusUp(InfoCollision info)
        {
            Dbg.Log($"PlayerBonusUp(InfoCollision obj){info.ObjectType}, {info.Value}, {info.OtherName}");
            switch (info.ObjectType)
            {
                case InteractiveObjectType.Coin:
                    _statsModel.CoinCount.Value += info.Value;
                    break;
                case InteractiveObjectType.ExtraLive:
                    _statsModel.LiveCount.Value += info.Value;
                    break;
                case InteractiveObjectType.Bomb:
                    if (_playerImmunity) break;
                    _statsModel.LiveCount.Value -= info.Value;
                    if (_statsModel.LiveCount.Value <= 0)
                        _gameState.SetValue(GameState.Fail, $"{StringManager.MESSAGE_FAIL}: {info.OtherName}");
                    break;
                case InteractiveObjectType.Finish:
                    _gameState.SetValue(GameState.Win, StringManager.MESSAGE_WIN);
                    break;
                case InteractiveObjectType.SpeedUp:
                    _playerModel.PlayerSpeed.Value *= info.Value;
                    _timerSpeedUp.AddTimeRemainingExecute();
                    PaintToColor(Color.green);
                    break;
                case InteractiveObjectType.Immunitet:
                    _playerImmunity = true;
                    _timerImmunity = TimerImmunity(info.Value);
                    _timerImmunity.AddTimeRemainingExecute();
                    PaintToColor(Color.yellow);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(info), info, null);
            }
        }

        #endregion


        #region ICleanup

        public void Cleanup()
        {
            _playerView.OnBonusUp -= PlayerViewBonusUp;
        }

        #endregion


        #region Methods

        private TimeRemaining.TimeRemaining TimerPainting(float time)
        {
            return new TimeRemaining.TimeRemaining(() => { _playerView.MeshRenderer().material.color = Color.white; },
                time);
        }

        private TimeRemaining.TimeRemaining TimerSpeedUp(float time)
        {
            return new TimeRemaining.TimeRemaining(() =>
            {
                Dbg.Log($"_model.NormalSpeed:{_playerModel.PlayerSpeed.Value}");
                _playerModel.PlayerSpeed.Value = _cashStartSpeedPlayer;
            }, time);
        }

        private TimeRemaining.TimeRemaining TimerImmunity(float time)
        {
            return new TimeRemaining.TimeRemaining(() => { _playerImmunity = false; }, time);
        }

        private void PaintToColor(Color color)
        {
            _playerView.MeshRenderer().material.color = color;
            _timerPainting.AddTimeRemainingExecute();
        }

        #endregion
    }
}