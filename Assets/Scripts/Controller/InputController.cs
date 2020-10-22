﻿using Data;
using Interface;
using UnityEngine;


namespace Controller
{
    public sealed class InputController : IUpdated
    {
        #region Fields

        private UnityEngine.Vector3 _inputVector;
        private Services _services;

        #endregion

        
        #region ctor

        public InputController(Services services)
        {
            _services = services;
        }

        #endregion
        
        
        #region IUdpatable

        public void UpdateTick()
        {
            // _inputVector = new Vector3(
            //     UltimateJoystick.GetHorizontalAxis("Movement"),
            //     0.0f,
            //     UltimateJoystick.GetVerticalAxis("Movement"));
             _inputVector = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            _services.PlayerController.Move(_inputVector);
        }

        #endregion
    }
}