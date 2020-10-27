using System;
using Data;
using Enum;
using Healper;
using Interface;
using Model;
using UnityEngine;
using View;


namespace Controller
{
    public sealed class PlayerController : IUpdated, IFixedUpdated, IEnabled

    {
        #region Fields

        private PlayerView _playerView;
        private PlayerModel _model;

        private UserInput _userInputVector;
        private Vector3 _direction;
        private float _gravityForce;
        private float _deltaImpulce;

        #endregion

        
        #region Properties

        private bool IsGrounded =>
            Physics.Raycast(_playerView.transform.position + Vector3.up / 2, Vector3.down, out _,
                _model.DistanceToCheckGround, LayerManager.GroundLayer);

        #endregion
        

        #region ctor

        public PlayerController(PlayerView playerView, PlayerModel playerModel, UserInput userInputVector)
        {
            _playerView = playerView;
            _model = playerModel;
            _userInputVector = userInputVector;
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
        
        public void UpdateTick()
        {
            CheckGravity();

            // CheckState();
        }

        // private void CheckState()
        // {
        //     switch (_model.StateUnit)
        //     {
        //         case StateUnit.Live:
        //             break;
        //         case StateUnit.Dead:
        //             break;
        //         case StateUnit.Finish:
        //             break;
        //         default:
        //             throw new ArgumentOutOfRangeException();
        //     }
        // }

        public void FixedUpdateTick()
        {
            Move();
        }

        #endregion
        

        #region PrivateMethods

        private void BonusUp(BonusType obj)
        {
            Dbg.Log($"BonusUp:{obj}");
            switch (obj)
            {
                case BonusType.Coin:
                    _model.CountCoins.Value += 1;
                    break;
                case BonusType.ExtraLive:
                    _model.Live.Value += 1;
                    break;
                case BonusType.Bomb:
                    _model.Live.Value -= 1;
                    break;
                case BonusType.Finish:
                    //todo реализовать обработку конца игры
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
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

        #endregion

    }
}