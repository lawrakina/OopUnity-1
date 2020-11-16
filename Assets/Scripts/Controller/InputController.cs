using Interface;
using Model;
using SaveLoadData;
using UnityEngine;


namespace Controller
{
    public sealed class InputController :IInitialization, IExecute
    {

        #region Fields

        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly PlayerModel _player;
        private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;

        #endregion

        
        #region ClassLiveCycles

        public InputController(
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, 
            SaveDataRepository saveDataRepository, 
            PlayerModel player)
        {
            _saveDataRepository = saveDataRepository;
            _player = player;
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
        }

        #endregion

        
        public void Initialization()
        {
            
        }
        

        #region IExecute

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            
            if (Input.GetKeyDown(_savePlayer))
            {
                _saveDataRepository.Save(_player);
            }
            if (Input.GetKeyDown(_loadPlayer))
            {
                _saveDataRepository.Load(_player);
            }
        }

        #endregion
        
        
        // _inputVector = new Vector3(
        //     UltimateJoystick.GetHorizontalAxis("Movement"),
        //     0.0f,
        //     UltimateJoystick.GetVerticalAxis("Movement"));
        // _userInputVector.InputVector = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
    }
}