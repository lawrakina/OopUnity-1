using Interface;


namespace Controller
{
    public sealed class InputController :IController, IExecute
    {
        #region Fields

        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;

        #endregion

        
        #region Ctor

        public InputController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input)
        {
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
        }

        #endregion


        #region UnityMethods

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
        }

        #endregion
        
        
        // _inputVector = new Vector3(
        //     UltimateJoystick.GetHorizontalAxis("Movement"),
        //     0.0f,
        //     UltimateJoystick.GetVerticalAxis("Movement"));
        // _userInputVector.InputVector = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
    }
}