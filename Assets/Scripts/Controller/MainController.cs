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
            var terrainManager         = new TerrainManager(_gameData);
            var inputInitialization    = new InputInitialization();
            var gameStatInitialization = new StatisticsInitialization(_gameData);
            var playerFactory          = new PlayerFactory(_playerData);
            var playerInitialization   = new PlayerInitialization(playerFactory, _playerData);
            var bonusFactory           = new BonusFactory(_bonusData);
            var bonusInitialization    = new BonusInitialization(bonusFactory, terrainManager);
            var enemyFactory           = new EnemyFactory(_enemyData);
            var enemyInitialization    = new EnemyInitialization(enemyFactory, _enemyData, terrainManager);
            var uiInitialization       = new UiInitialization();

            _controllers = new Controllers();
            _controllers.Add(inputInitialization);
            _controllers.Add(playerInitialization);
            _controllers.Add(enemyInitialization);
            _controllers.Add(bonusInitialization);
            _controllers.Add(new InputController(
                inputInitialization.GetInput()));
            _controllers.Add(new MoveController(
                inputInitialization.GetInput(),
                playerInitialization.GetPlayer(),
                _playerData));
            _controllers.Add(new GameBehaviorController(
                playerInitialization.GetPlayer(),
                gameStatInitialization.GetCoinCount(),
                gameStatInitialization.GetMaxCoinCount(),
                gameStatInitialization.GetLiveCount(),
                playerInitialization.GetPlayerSpeed()));
            _controllers.Add(new UiController(
                uiInitialization.GetUi(),
                gameStatInitialization.GetCoinCount(),
                gameStatInitialization.GetMaxCoinCount(),
                gameStatInitialization.GetLiveCount()
            ));
            // _controllers.Add(new EnemyMoveController(enemyInitialization.GetEnemy(), playerInitialization.GetPlayer()));
            _controllers.Add(new CameraController(playerInitialization.GetPlayer().Transform(), _mainCamera));
            _controllers.Add(new TimeRemainingController());
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

        private void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            _controllers.FixedExecute(deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }

        #endregion
    }
}