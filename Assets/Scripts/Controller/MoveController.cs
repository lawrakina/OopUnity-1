using Healper;
using Interface;
using Units;
using UnityEngine;


namespace Controller
{
    public sealed class MoveController : IController, IExecute, IFixedExecute, ICleanup
    {
        #region Fields

        private readonly IBaseUnitView _unitView;
        private readonly IUnit     _unitData;

        private Vector3         _inputVector;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;
        private Vector3         _direction;
        private float           _gravityForce;
        private float           _deltaImpulce;

        #endregion

        private bool IsGrounded =>
            Physics.Raycast(_unitView.Transform().position + Vector3.up / 2, Vector3.down, out _,
                1.0f, LayerManager.GroundLayer);
        
        #region ctor

        public MoveController(
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, IBaseUnitView unitView, IUnit unitData)
        {
            _unitView = unitView;
            _unitData = unitData;
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }

        #endregion


        #region Methods

        private void VerticalOnAxisOnChange(float value)
        {
            _inputVector.z = value;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _inputVector.x = value;
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }

        #endregion

        public void Execute(float deltaTime)
        {
            CheckGravity();
        }
        
        public void FixedExecute(float deltaTime)
        {
            Move(deltaTime);
        }

        private void Move(float deltaTime)
        {
            //правильное скалярное умножение векторов => скорость под углом 45` ~ 0.706
            _direction = Vector3.ClampMagnitude(_inputVector, 1f);
            var movingVector = new Vector3(_direction.x, 0f, _direction.z);
            _deltaImpulce = _unitData.Speed * deltaTime;

            _unitView.Rigidbody().AddForce(
                movingVector.x * _deltaImpulce,
                _gravityForce * deltaTime,
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
    }
}