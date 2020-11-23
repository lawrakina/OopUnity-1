using Interface;
using Model;
using SaveLoadData;
using UnityEngine;


namespace Controller
{
    public sealed class InputController : IInitialization, IExecute
    {
        #region Fields

        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly SaveDataRepository _saveDataRepository;
        private PlayerModel _player;
        private BonusesModel _bonuses;
        private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;

        #endregion


        #region ClassLiveCycles

        public InputController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input,
            SaveDataRepository saveDataRepository,
            PlayerModel player,
            BonusesModel bonuses)
        {
            _saveDataRepository = saveDataRepository;
            _player = player;
            _bonuses = bonuses;
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
                _saveDataRepository.AddToSave(_player);
                _saveDataRepository.AddToSave(_bonuses);
                _saveDataRepository.Save();
            }

            if (Input.GetKeyDown(_loadPlayer))
            {
                _saveDataRepository.Load(ref _player, ref _bonuses);
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