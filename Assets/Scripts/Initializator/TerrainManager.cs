using System.ComponentModel;
using Data;
using Interface;
using UnityEngine;


namespace Initializator
{
    public sealed class TerrainManager: IInitialization
    {
        #region Fields

        private GameData _gameData;

        #endregion

        
        #region Properties

        [Description("x - StartPoint.X,\ny - StartPoint.Y,\nz - Lendht,\nw - Wight")]
        public Vector4 SizeOfPlatform => _gameData.GameStruct.SizeOfPlatform;

        #endregion


        #region ctor

        public TerrainManager(GameData gameData)
        {
            _gameData = gameData;
        }

        public void Initialization()
        {
            
        }

        #endregion


        #region Methods

        public Vector3 GeneratePoint()
        {
            return new Vector3(
                Random.Range(SizeOfPlatform.x - (SizeOfPlatform.z / 2), 
                    SizeOfPlatform.x + (SizeOfPlatform.z / 2)),
                1.0f,
                Random.Range(SizeOfPlatform.y - (SizeOfPlatform.w / 2), 
                    SizeOfPlatform.y + (SizeOfPlatform.w / 2))
            );
        }

        #endregion
    }
}