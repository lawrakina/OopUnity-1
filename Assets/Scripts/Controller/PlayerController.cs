using System;
using System.Collections.Generic;
using System.Linq;
using Controller.TimeRemaining;
using Data;
using Enum;
using Healper;
using Interface;
using Model;
using UnityEngine;
using View;


namespace Controller
{
    public sealed class PlayerController :IController, IExecute, IFixedExecute, IEnabled, ICleanup

    {
        #region Fields

        private PlayerView _playerView;
        private PlayerModel _model;

        private Data.UserInput _userInputVector;
        private Vector3 _direction;
        private float _gravityForce;
        private float _deltaImpulce;
        private float _standardTime = 5.0f;
        
        private TimeRemaining.TimeRemaining _timerPainting;
        private TimeRemaining.TimeRemaining _timerSpeedUp;
        private TimeRemaining.TimeRemaining _timerImmunity;

        #endregion


        #region Properties

        private bool IsGrounded =>
            Physics.Raycast(_playerView.transform.position + Vector3.up / 2, Vector3.down, out _,
                _model.DistanceToCheckGround, LayerManager.GroundLayer);

        #endregion


        #region ctor

        public PlayerController(PlayerView playerView, PlayerModel playerModel, Data.UserInput userInputVector)
        {
            _playerView = playerView;
            _model = playerModel;
            _userInputVector = userInputVector;

            _timerPainting = TimerPainting(_standardTime);
            _timerSpeedUp = TimerSpeedUp(_standardTime);
            _timerImmunity = TimerImmunity(_standardTime);
        }

        #endregion


        #region Methods

        public void On()
        {
            _playerView.OnBonusUp += BonusUp;
        }

        public void Off()
        {
            _playerView.OnBonusUp -= BonusUp;
        }

        public void Execute(float deltaTime)
        {
            CheckGravity();
        }

        public void Cleanup()
        {
            throw new NotImplementedException();
        }

        public void FixedExecute()
        {
            Move();
        }

        #endregion


        #region PrivateMethods

        private void BonusUp(InfoCollision info)
        {
            Dbg.Log($"BonusUp:{info.ObjectType}, value:{info.Value}, name:{info.OtherName}");
            switch (info.ObjectType)
            {
                case InteractiveObjectType.Coin:
                    _model.CountCoins.Value += info.Value;
                    break;
                case InteractiveObjectType.ExtraLive:
                    _model.Live.Value += info.Value;
                    break;
                case InteractiveObjectType.Bomb:
                    _model.Live.Value -= info.Value;
                    break;
                case InteractiveObjectType.Finish:
                    //todo реализовать обработку конца игры
                    break;
                case InteractiveObjectType.SpeedUp:
                    _model.Speed.Value *= info.Value;
                    _timerSpeedUp.AddTimeRemainingExecute();
                    PaintToColor(Color.green);
                    break;
                case InteractiveObjectType.Immunitet:
                    _model.Immunity = true;
                    _timerImmunity = TimerImmunity(info.Value);
                    _timerImmunity.AddTimeRemainingExecute();
                    PaintToColor(Color.yellow);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(info), info, null);
            }
        }

        private void PaintToColor(Color color)
        {
            _playerView.MeshRenderer.material.color = color;
            _timerPainting.AddTimeRemainingExecute();
        }

        private void Move()
        {
            //правильное скалярное умножение векторов
            _direction = Vector3.ClampMagnitude(_userInputVector.InputVector, 1f);
            var movingVector = new Vector3(_direction.x, 0f, _direction.z);
            _deltaImpulce = _model.Speed.Value * Time.fixedDeltaTime;

            _playerView.Rigidbody.AddForce(
                movingVector.x * _deltaImpulce,
                _gravityForce * Time.fixedDeltaTime,
                movingVector.z * _deltaImpulce,
                ForceMode.Impulse);
        }

        private void CheckGravity()
        {
            if (IsGrounded)
            {
                _gravityForce = -1.0f;
            }
            else
            {
                _gravityForce -= 2.0f;
            }

            _direction.y = _gravityForce;
        }
        

        private TimeRemaining.TimeRemaining TimerPainting(float time)
        {
            return new TimeRemaining.TimeRemaining(() => 
                { _playerView.MeshRenderer.material.color = Color.white;}, time);
        }

        private TimeRemaining.TimeRemaining TimerSpeedUp(float time)
        {
            return new TimeRemaining.TimeRemaining(() =>
            {
                Dbg.Log($"_model.NormalSpeed:{_model.NormalSpeed}");
                _model.Speed.Value = _model.NormalSpeed;
            }, time);
        }

        private TimeRemaining.TimeRemaining TimerImmunity(float time)
        {
            return new TimeRemaining.TimeRemaining(() => 
                { _model.Immunity = false; }, time);
        }

        #endregion

    }
}