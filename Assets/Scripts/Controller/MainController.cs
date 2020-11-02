using System.Collections.Generic;
using Controller.TimeRemaining;
using Data;
using Healper;
using Initializator;
using Interface;
using Player;
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
            // var inputVector = new UserInput();
            var inputInitialization = new InputInitialization();
            var playerFactory = new PlayerFactory(_playerData);
            var playerInitialization = new PlayerInitialization(playerFactory);
            
            //todo добавить:
            1) класс контроллер
                2) контроллер врагов
                    3) контроллер бонусов
                        4) gui экран победы и поражения
                            5) счетчики coins&live

                // _playerData.PlayerStruct.Speed = new BoxFloat(){};
            // _gameData.GameStruct.CountCoins = new BoxInt() {};
            // _gameData.GameStruct.CountLive = new BoxInt() {};
            // _gameData.GameStruct.CountNeedCoins = new BoxInt(){};
            
            // _playerData.PlayerStruct.Speed.Value = _playerData.PlayerStruct.speed;
            // _gameData.GameStruct.CountCoins.Value = _gameData.GameStruct.countCoins;
            // _gameData.GameStruct.CountLive.Value = _gameData.GameStruct.countLive;
            // _gameData.GameStruct.CountNeedCoins.Value = _gameData.GameStruct.countNeedCoins;

            // new PlayerInitializator(this, _gameData, _playerData, inputVector);
            new BonusInitializator(_gameData);
            new UiInitializator(this, _gameData, _playerData);
            // AddLateUpdated(CameraInitializator.GetController(_playerData, _mainCamera));
            // AddUpdated(new InputController(inputVector));
            // AddUpdated(new TimeRemainingController());

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

        #endregion
    }
}