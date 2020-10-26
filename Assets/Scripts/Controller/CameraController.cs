using Interface;
using UnityEngine;
using View;


namespace Controller
{
    public sealed class CameraController: ILateUpdated
    {
        #region Fields
    
        private CameraView _cameraView;
        private Transform _target;
    
        #endregion
        
        
        #region ctor

        public CameraController(Transform target, CameraView mainCamera)
        {
            _cameraView = mainCamera;
            _target = target;
        }

        #endregion

        
        #region ILateUpdated

        #endregion

        public void LateUpdateTick()
        {
            _cameraView.transform.position = _target.position +  _cameraView.OffSet;
        }
    }
}