using UnityEngine;


namespace Units.Enemy
{
    public sealed class EnemyProvider : MonoBehaviour, IEnemy
    {
        [SerializeField] private float     _speed;
        [SerializeField] private float     _stopDistance;
        private                  Rigidbody _rigidbody;
        private                  Transform _transform;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _transform = transform;
        }

        public void Move(Vector3 point)
        {
            if ((_transform.localPosition - point).sqrMagnitude >= _stopDistance * _stopDistance)
            {
                var dir = (point - _transform.localPosition).normalized;
                _rigidbody.velocity = dir * _speed;
            }
            else
            {
                _rigidbody.velocity = Vector2.zero;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
        }
    }
}