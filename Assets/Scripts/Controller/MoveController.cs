using Interface;
using Units;
using UnityEngine;


namespace Controller
{
    public sealed class MoveController : IController, IExecute, ICleanup
    {
        #region Fields

        private readonly Transform _unit;
        private readonly IUnit     _unitData;

        private float           _horizontal;
        private float           _vertical;
        private Vector3         _move;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;

        #endregion

        
        #region ctor

        public MoveController(
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, Transform unit, IUnit unitData)
        {
            _unit = unit;
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
            _vertical = value;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        public void Execute(float deltaTime)
        {
            var speed = deltaTime * _unitData.Speed;
            _move.Set(_horizontal * speed, _vertical * speed, 0.0f);
            _unit.localPosition += _move;
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }

        #endregion
    }
}