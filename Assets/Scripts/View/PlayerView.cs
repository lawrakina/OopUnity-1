using System;
using Interface;
using Model;
using Units.Player;
using UnityEngine;


namespace View
{

    public sealed class PlayerView : MonoBehaviour, IPlayerView
    {
        #region Fields

        private Transform    _transform;
        private Collider     _collider;
        private Rigidbody    _rigidbody;
        private MeshRenderer _meshRenderer;

        #endregion


        #region Properties

        public Transform    Transform()    => _transform;
        public Collider     Collider()     => _collider;
        public Rigidbody    Rigidbody()    => _rigidbody;
        public MeshRenderer MeshRenderer() => _meshRenderer;

        #endregion


        #region Events

        public event Action<InfoCollision> OnBonusUp;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            _meshRenderer = GetComponent<MeshRenderer>();
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