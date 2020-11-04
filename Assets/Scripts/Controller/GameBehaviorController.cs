using System;
using Enum;
using Healper;
using Interface;
using Model;
using Units.Player;


namespace Controller
{
    public sealed class GameBehaviorController : IController, ICleanup
    {
        private IPlayerView              _player;
        private IIntNotifyPropertyChange _coinCount;
        private IIntNotifyPropertyChange _maxCoinCount;
        private IIntNotifyPropertyChange _liveCount;

        public GameBehaviorController(
            IPlayerView              player,
            IIntNotifyPropertyChange coinCount,
            IIntNotifyPropertyChange maxCoinCount,
            IIntNotifyPropertyChange liveCount)
        {
            _player = player;
            _player.OnBonusUp += PlayerBonusUp;
            _coinCount = coinCount;
            _maxCoinCount = maxCoinCount;
            _liveCount = liveCount;
        }

        private void PlayerBonusUp(InfoCollision info)
        {
            Dbg.Log($"PlayerBonusUp(InfoCollision obj){info.ObjectType}, {info.Value}, {info.OtherName}");
            // switch (info.ObjectType)
            // {
            //     case InteractiveObjectType.Coin:
            //         _coinCount.Value += info.Value;
            //         break;
            //     case InteractiveObjectType.ExtraLive:
            //         _liveCount.Value += info.Value;
            //         break;
            //     case InteractiveObjectType.Bomb:
            //         _liveCount.Value -= info.Value;
            //         if (_liveCount.Value <= 0)
            //         {
            //             //todo реализовать смерть, бу-га-га (ఠ益ఠ)
            //         }
            //         break;
            //     case InteractiveObjectType.Finish:
            //         //todo реализовать обработку конца игры
            //         break;
            //     case InteractiveObjectType.SpeedUp:
            //         _model.Speed.Value *= info.Value;
            //         _timerSpeedUp.AddTimeRemainingExecute();
            //         PaintToColor(Color.green);
            //         break;
            //     case InteractiveObjectType.Immunitet:
            //         _model.Immunity = true;
            //         _timerImmunity = TimerImmunity(info.Value);
            //         _timerImmunity.AddTimeRemainingExecute();
            //         PaintToColor(Color.yellow);
            //         break;
            //     default:
            //         throw new ArgumentOutOfRangeException(nameof(info), info, null);
            // }
        }

        public void Cleanup()
        {
            _player.OnBonusUp -= PlayerBonusUp;
        }
    }
}