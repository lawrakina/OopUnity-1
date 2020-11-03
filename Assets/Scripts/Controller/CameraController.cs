using Interface;
using UnityEngine;
using View;


namespace Controller
{
    public sealed class CameraController:IController, ILateExecute
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

        public void LateExecute(float deltaTime)
        {
            _cameraView.transform.position = Vector3.Lerp (_cameraView.transform.position, _target.position +  _cameraView.OffSet, deltaTime);
        }
    }
}