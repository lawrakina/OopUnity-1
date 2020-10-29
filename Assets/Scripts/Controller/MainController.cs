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

        [SerializeField] private CameraView _mainCamera;
        [SerializeField] private PlayerData _playerData;

        [Header("Game Layers")] [SerializeField]
        private LayerMask _groundLayer;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            LayerManager.GroundLayer = _groundLayer;

            var inputVector = new UserInput();
            AddUpdated(PlayerInitializator.GetController(_playerData, inputVector));
            AddUpdated(CameraInitializator.GetController(_playerData, _mainCamera));
            AddUpdated(new InputController(inputVector));
            
            //For history 8-)
            // new PlayerInitializator(this, _playerData, inputVector);
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

        #endregion


        #region Methods

        public void AddUpdated(IUpdated controller)
        {
            _iUpdated.Add(controller);
        }

        #endregion
    }
}