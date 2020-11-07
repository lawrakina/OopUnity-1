using Bonus;
using Controller.TimeRemaining;
using Data;
using Healper;
using Initializator;
using Model;
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

        [SerializeField] private CameraView  _mainCamera;
        [SerializeField] private PlayerData  _playerData;
        [SerializeField] private GameData    _gameData;
        [SerializeField] private BonusData   _bonusData;
        [SerializeField] private EnemyData   _enemyData;
        private                  UiReference _uiReference;

        [Header("Game Layers")] [SerializeField]
        private LayerMask _groundLayer;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            LayerManager.GroundLayer = _groundLayer;
            _uiReference = new UiReference();
            var terrainManager          = new TerrainManager(_gameData);
            var inputInitialization     = new InputInitialization();
            var statInitialization      = new StatisticsInitialization(_gameData);
            var playerFactory           = new PlayerFactory(_playerData);
            var playerInitialization    = new PlayerInitialization(playerFactory, _playerData);
            var bonusFactory            = new BonusFactory(_bonusData);
            var bonusInitialization     = new BonusInitialization(bonusFactory, terrainManager);
            var enemyFactory            = new EnemyFactory(_enemyData);
            var enemyInitialization     = new EnemyInitialization(enemyFactory, _enemyData, terrainManager);
            var uiInitialization        = new UiInitialization(_uiReference);
            var gameStateInitialization = new GameStateInitialization(_gameData, _playerData);
            
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
            _controllers.Add(new PlayerBehaviorController(
                playerInitialization.GetPlayer(),
                statInitialization.GetCoinCount(),
                statInitialization.GetMaxCoinCount(),
                statInitialization.GetLiveCount(),
                playerInitialization.GetPlayerSpeed(),
                gameStateInitialization.GetGameState()));
            _controllers.Add(new UiController(
                uiInitialization.GetUi(),
                statInitialization.GetCoinCount(),
                statInitialization.GetMaxCoinCount(),
                statInitialization.GetLiveCount(),
                uiInitialization.GetMenuScreen(),
                uiInitialization.GetPauseScreen(),
                uiInitialization.GetEndScreen(),
                gameStateInitialization.GetGameState()
            ));
            _controllers.Add(new EnemyMoveController(enemyInitialization.GetEnemy(), playerInitialization.GetPlayer()));
            _controllers.Add(new CameraController(playerInitialization.GetPlayer().Transform(), _mainCamera));
            _controllers.Add(new TimeRemainingController());
            _controllers.Initialization();
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