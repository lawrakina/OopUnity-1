using UnityEngine;


namespace View
{
    public sealed class PlayerView : MonoBehaviour
    {
        #region Fields

        public Transform Transform;
        public Collider Collider;
        public Rigidbody Rigidbody;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            Transform = GetComponent<Transform>();
            Rigidbody = GetComponent<Rigidbody>();
            Collider = GetComponent<Collider>();
        }

        #endregion
    }
}