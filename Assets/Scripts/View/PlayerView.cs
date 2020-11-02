using System;
using Enum;
using Interface;
using Model;
using UnityEngine;


namespace View
{
    public sealed class PlayerView : MonoBehaviour, ICollision
    {
        #region Fields

        public Transform Transform;
        public Collider Collider;
        public Rigidbody Rigidbody;
        public MeshRenderer MeshRenderer;

        #endregion


        #region Events

        public event Action<InfoCollision> OnBonusUp;

        #endregion
        

        #region UnityMethods

        private void Awake()
        {
            Transform = GetComponent<Transform>();
            Rigidbody = GetComponent<Rigidbody>();
            Collider = GetComponent<Collider>();
            MeshRenderer = GetComponent<MeshRenderer>();
        }

        #endregion

        
        #region Methods

        public void OnCollision(InfoCollision infoCollision)
        {
            OnBonusUp?.Invoke(infoCollision);
        }

        #endregion
    }
}