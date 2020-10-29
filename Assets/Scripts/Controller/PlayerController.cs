using Data;
using Healper;
using Interface;
using Model;
using UnityEngine;
using View;


namespace Controller
{
    public sealed class PlayerController : IUpdated

    {
        #region Fields

        private PlayerView _playerView;
        private PlayerModel _model;

        private UserInput _userInputVector;
        private Vector3 _direction;
        private float _gravityForce;

        #endregion

        
        #region Properties

        private bool IsGrounded =>
            // RaycastHit hit;
            // Debug.DrawRay(_player.transform.position + new Vector3(0.0f, 0.5f, 0.0f), Vector3.down, Color.red,
            // _player.distanceToCheckGround);
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

        public void UpdateTick()
        {
            CheckGravity();
            Move(_userInputVector.InputVector);
        }

        private void Move(Vector3 inputVector)
        {
            _direction = Vector3.ClampMagnitude(inputVector, 1f);
            var movingVector = new Vector3(_direction.x, 0f, _direction.z);

            _playerView.Rigidbody.MovePosition(_playerView.Transform.position +
                                               movingVector * (_model.Speed * Time.fixedDeltaTime));
            _playerView.Rigidbody.AddForce(new Vector3(0f, _gravityForce * Time.fixedDeltaTime, 0f), ForceMode.Impulse);
        }

        #endregion


        #region PrivateMethods

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