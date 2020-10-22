using Data;
using Interface;
using UnityEngine;
using View;


namespace Controller
{
    public sealed class CameraController: IUpdated
    {
        #region Fields
    
        private CameraView _cameraView;
        private GameContext _context;
        private Transform _target;
    
        #endregion
        
        
        #region ctor

        public CameraController(CameraView camera, GameContext context)
        {
            _cameraView = camera;
            _context = context;
            _target = context.PlayerData.PlayerStruct.Player.transform;
        }


        #endregion

        
        #region IUpdated

        public void UpdateTick()
        {
            if (_target == null) return;
            
            _cameraView.transform.position = _target.position +  _cameraView._offSet;
        }

        #endregion
    }
}