using System.Collections.Generic;
using Bonus;
using Controller.TimeRemaining;
using Data;
using Healper;
using Initializator;
using Units.Enemy;
using Units.Player;
using UnityEngine;
using View;


namespace Controller
{
    public sealed class MainController : MonoBehaviour
    {
        #region Fields

        // private readonly List<IExecute>      _iUpdated      = new List<IExecute>();
        // private readonly List<ILateUpdated>  _iLateUpdated  = new List<ILateUpdated>();
        // private readonly List<IFixedExecute> _iFixedUpdated = new List<IFixedExecute>();
        // private readonly List<IEnabled>      _iEnabled      = new List<IEnabled>();

        private Controllers _controllers;

        [SerializeField] private CameraView _mainCamera;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private GameData   _gameData;
        [SerializeField] private BonusData  _bonusData;
        [SerializeField] private EnemyData  _enemyData;

        [Header("Game Layers")] [SerializeField]
        private LayerMask _groundLayer;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            LayerManager.GroundLayer = _groundLayer;
            // var inputVector = new UserInput();
            var terrainManager       = new TerrainManager(_gameData);
            var inputInitialization  = new InputInitialization();
            var playerFactory        = new PlayerFactory(_playerData);
            var playerInitialization = new PlayerInitialization(playerFactory);
            var bonusFactory         = new BonusFactory(_bonusData);
            var bonusInitialization  = new BonusInitialization(bonusFactory, terrainManager);
            var enemyFactory         = new EnemyFactory(_enemyData);
            var enemyInitialization  = new EnemyInitialization(enemyFactory, _enemyData, terrainManager);

            _controllers = new Controllers();
            _controllers.Add(inputInitialization);
            _controllers.Add(playerInitialization);
            _controllers.Add(enemyInitialization);
            _controllers.Add(bonusInitialization);
            _controllers.Add(new InputController(inputInitialization.GetInput()));
            _controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(),
                _playerData));
            // _controllers.Add(new EnemyMoveController(enemyInitialization.GetEnemy(), playerInitialization.GetPlayer()));
            _controllers.Add(new CameraController(playerInitialization.GetPlayer(), _mainCamera));
            _controllers.Initialization();

            //todo добавить:
            // 1) класс контроллер
            // 4) gui   экран победы и поражения
            // 5) счетчики coins & live

            // _playerData.PlayerStruct.Speed = new BoxFloat(){};
            // _gameData.GameStruct.CountCoins = new BoxInt() {};
            // _gameData.GameStruct.CountLive = new BoxInt() {};
            // _gameData.GameStruct.CountNeedCoins = new BoxInt(){};

            // _playerData.PlayerStruct.Speed.Value = _playerData.PlayerStruct.speed;
            // _gameData.GameStruct.CountCoins.Value = _gameData.GameStruct.countCoins;
            // _gameData.GameStruct.CountLive.Value = _gameData.GameStruct.countLive;
            // _gameData.GameStruct.CountNeedCoins.Value = _gameData.GameStruct.countNeedCoins;

            // new PlayerInitializator(this, _gameData, _playerData, inputVector);
            // new BonusInitialization(_gameData);
            // new UiInitializator(this, _gameData, _playerData);
            // AddLateUpdated(CameraInitializator.GetController(_playerData, _mainCamera));
            // AddUpdated(new InputController(inputVector));
            // AddUpdated(new TimeRemainingController());
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateExecute(deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }

        // private void LateUpdate()
        // {
        //     for (var i = 0; i < _iLateUpdated.Count; i++)
        //     {
        //         _iLateUpdated[i].LateUpdateTick();
        //     }
        // }
        //
        // private void FixedUpdate()
        // {
        //     for (var i = 0; i < _iFixedUpdated.Count; i++)
        //     {
        //         _iFixedUpdated[i].FixedExecute();
        //     }
        // }

        // private void OnEnable()
        // {
        //     for (var i = 0; i < _iEnabled.Count; i++)
        //     {
        //         _iEnabled[i].On();
        //     }
        // }
        //
        // private void OnDisable()
        // {
        //     for (var i = 0; i < _iEnabled.Count; i++)
        //     {
        //         _iEnabled[i].Off();
        //     }
        // }

        #endregion


        #region Methods

        // public void AddUpdated(Interface.IExecute controller)
        // {
        //     _iUpdated.Add(controller);
        // }
        //
        // public void AddLateUpdated(ILateUpdated controller)
        // {
        //     _iLateUpdated.Add(controller);
        // }
        //
        // public void AddFixedUpdated(IFixedExecute controller)
        // {
        //     _iFixedUpdated.Add(controller);
        // }
        //
        // public void AddEnabled(IEnabled controller)
        // {
        //     _iEnabled.Add(controller);
        // }

        #endregion
    }
}