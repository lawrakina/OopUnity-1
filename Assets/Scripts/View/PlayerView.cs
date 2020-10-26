using System;
using Enum;
using Interface;
using UnityEngine;


namespace View
{
    public sealed class PlayerView : MonoBehaviour, ICollision
    {
        #region Fields

        public Transform Transform;
        public Collider Collider;
        public Rigidbody Rigidbody;

        #endregion


        #region Events

        public event Action<BonusType> OnBonusUp;

        #endregion
        

        #region UnityMethods

        private void Awake()
        {
            Transform = GetComponent<Transform>();
            Rigidbody = GetComponent<Rigidbody>();
            Collider = GetComponent<Collider>();
        }

        #endregion

        
        #region Methods

        public void OnCollision(BonusType bonusType)
        {
            OnBonusUp?.Invoke(bonusType);
        }

        #endregion
    }
}