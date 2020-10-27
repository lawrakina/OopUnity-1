using System.Collections.Generic;
using Data;
using Healper;
using Initializator;
using Interface;
using UnityEngine;
using View;


namespace Controller
{
    public sealed class MainController : MonoBehaviour
    {
        #region Fields

        private readonly List<IUpdated> _iUpdated = new List<IUpdated>();
        private readonly List<ILateUpdated> _iLateUpdated = new List<ILateUpdated>();
        private readonly List<IFixedUpdated> _iFixedUpdated = new List<IFixedUpdated>();
        private readonly List<IEnabled> _iEnabled = new List<IEnabled>();

        [SerializeField] private CameraView _mainCamera;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private GameData _gameData;

        [Header("Game Layers")] [SerializeField]
        private LayerMask _groundLayer;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            LayerManager.GroundLayer = _groundLayer;

            InitGameData(_gameData, _playerData);
            var inputVector = new UserInput();

            new PlayerInitializator(this, _gameData, _playerData, inputVector);
            new BonusInitializator(_gameData);
            AddLateUpdated(CameraInitializator.GetController(_playerData, _mainCamera));
            AddUpdated(new InputController(inputVector));

            new UiInitializator(this, _gameData, _playerData);

            //For history 8-)
            // new CameraInitializator(this, _playerData, _mainCamera);
            // new InputInitializator(this, inputVector); 
        }


        private void Update()
        {
            for (var i = 0; i < _iUpdated.Count; i++)
            {
                _iUpdated[i].UpdateTick();
            }
        }

        private void LateUpdate()
        {
            for (var i = 0; i < _iLateUpdated.Count; i++)
            {
                _iLateUpdated[i].LateUpdateTick();
            }
        }

        private void FixedUpdate()
        {
            for (var i = 0; i < _iFixedUpdated.Count; i++)
            {
                _iFixedUpdated[i].FixedUpdateTick();
            }
        }

        private void OnEnable()
        {
            for (var i = 0; i < _iEnabled.Count; i++)
            {
                _iEnabled[i].On();
            }
        }

        private void OnDisable()
        {
            for (var i = 0; i < _iEnabled.Count; i++)
            {
                _iEnabled[i].Off();
            }
        }

        #endregion


        #region Methods

        public void AddUpdated(IUpdated controller)
        {
            _iUpdated.Add(controller);
        }

        public void AddLateUpdated(ILateUpdated controller)
        {
            _iLateUpdated.Add(controller);
        }

        public void AddFixedUpdated(IFixedUpdated controller)
        {
            _iFixedUpdated.Add(controller);
        }

        public void AddEnabled(IEnabled controller)
        {
            _iEnabled.Add(controller);
        }
        
        private static void InitGameData(GameData gameData, PlayerData playerData)
        {
            gameData.GameStruct.CountCoins = new BoxInt() {Value = gameData.GameStruct.countCoins};
            gameData.GameStruct.CountLive = new BoxInt() {Value = gameData.GameStruct.countLive};
            gameData.GameStruct.CountNeedCoins = new BoxInt(){Value = gameData.GameStruct.countNeedCoins};
            playerData.PlayerStruct.Speed = new BoxFloat(){Value = playerData.PlayerStruct.speed};
        }

        #endregion
    }
}