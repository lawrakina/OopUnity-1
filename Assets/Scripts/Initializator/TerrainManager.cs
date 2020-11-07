using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using Data;
using Healper;
using Interface;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;
using Vector4 = UnityEngine.Vector4;


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
            Vector3 result = Vector3.one;
            for (int i = 0; i < 10; i++)
            {
                var checkPoint = new Vector3(
                        Random.Range(SizeOfPlatform.x - (SizeOfPlatform.z / 2), 
                            SizeOfPlatform.x + (SizeOfPlatform.z / 2)),
                        1.5f,
                        Random.Range(SizeOfPlatform.y - (SizeOfPlatform.w / 2), 
                            SizeOfPlatform.y + (SizeOfPlatform.w / 2)));
                var _ = new Collider[2];
                int numColliders = Physics.OverlapSphereNonAlloc(checkPoint,2.0f, _);
                Dbg.Log($"i:{i}, numColliders:{numColliders}");
                if (numColliders == 1) return checkPoint;
            }
            return result;
        }

        #endregion
    }
}