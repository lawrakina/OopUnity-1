using System;
using System.Collections.Generic;
using Data;
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

        [Header("Game Data")] private GameContext _context;
        private Services _services;

        [Header("Game Layers")] [SerializeField]
        private LayerMask _groundLayer;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _services = new Services(this);
            _context = new GameContext()
            {
                PlayerData = _playerData,
                GroundLayer = _groundLayer,
            };
            new PlayerInitializator(_services, _context);
            new CameraInitializator(_services, _context, _mainCamera);
            new InputInitializator(_services);
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