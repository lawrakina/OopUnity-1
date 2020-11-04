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
    public sealed class GameBehaviorController : IInitialization, ICleanup
    {
        private IPlayerView                _playerView;
        private IIntNotifyPropertyChange   _coinCount;
        private IIntNotifyPropertyChange   _maxCoinCount;
        private IIntNotifyPropertyChange   _liveCount;
        private IFloatNotifyPropertyChange _speedPlayer;

        private TimeRemaining.TimeRemaining _timerPainting;
        private TimeRemaining.TimeRemaining _timerSpeedUp;
        private TimeRemaining.TimeRemaining _timerImmunity;

        private float _cashStartSpeedPlayer;
        private float _standardTime = 5.0f;
        private bool  _playerImmunity;

        public GameBehaviorController(IPlayerView playerView,
            IIntNotifyPropertyChange              coinCount,
            IIntNotifyPropertyChange              maxCoinCount,
            IIntNotifyPropertyChange              liveCount,
            IFloatNotifyPropertyChange            playerSpeed)
        {
            _playerView = playerView;
            _playerView.OnBonusUp += PlayerViewBonusUp;
            _coinCount = coinCount;
            _maxCoinCount = maxCoinCount;
            _liveCount = liveCount;
            _speedPlayer = playerSpeed;
        }


        public void Initialization()
        {
            _cashStartSpeedPlayer = _speedPlayer.Value;

            _timerPainting = TimerPainting(_standardTime);
            _timerSpeedUp = TimerSpeedUp(_standardTime);
            _timerImmunity = TimerImmunity(_standardTime);
        }

        private void PlayerViewBonusUp(InfoCollision info)
        {
            Dbg.Log($"PlayerBonusUp(InfoCollision obj){info.ObjectType}, {info.Value}, {info.OtherName}");
            switch (info.ObjectType)
            {
                case InteractiveObjectType.Coin:
                    _coinCount.Value += info.Value;
                    break;
                case InteractiveObjectType.ExtraLive:
                    _liveCount.Value += info.Value;
                    break;
                case InteractiveObjectType.Bomb:
                    if (_playerImmunity) break;
                    _liveCount.Value -= info.Value;
                    if (_liveCount.Value <= 0)
                    {
                        //todo реализовать смерть, бу-га-га (ఠ益ఠ)
                    }

                    break;
                case InteractiveObjectType.Finish:
                    //todo реализовать обработку конца игры
                    break;
                case InteractiveObjectType.SpeedUp:
                    _speedPlayer.Value *= info.Value;
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

        public void Cleanup()
        {
            _playerView.OnBonusUp -= PlayerViewBonusUp;
        }

        private TimeRemaining.TimeRemaining TimerPainting(float time)
        {
            return new TimeRemaining.TimeRemaining(() => { _playerView.MeshRenderer().material.color = Color.white; },
                time);
        }

        private TimeRemaining.TimeRemaining TimerSpeedUp(float time)
        {
            return new TimeRemaining.TimeRemaining(() =>
            {
                Dbg.Log($"_model.NormalSpeed:{_speedPlayer.Value}");
                _speedPlayer.Value = _cashStartSpeedPlayer;
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
    }
}