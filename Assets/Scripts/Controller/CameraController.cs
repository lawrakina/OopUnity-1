﻿using Interface;
using UnityEngine;
using View;


namespace Controller
{
    public sealed class CameraController: IUpdated
    {
        #region Fields
    
        private CameraView _cameraView;
        private Transform _target;
    
        #endregion
        
        
        #region ctor

        public CameraController(GameObject target, CameraView mainCamera)
        {
            _cameraView = mainCamera;
            _target = target.transform;
        }

        #endregion

        
        #region IUpdated

        public void UpdateTick()
        {
            _cameraView.transform.position = _target.position +  _cameraView.OffSet;
        }

        #endregion
    }
}