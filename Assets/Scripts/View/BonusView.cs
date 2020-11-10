using Enum;
using Healper;
using Interface;
using Model;
using UnityEngine;


namespace View
{
    public sealed class BonusView : InteractiveObject, IBonusView
    {
        #region fields

        [SerializeField] private InteractiveObjectType _interactiveObjectType;
        [SerializeField] private int                   _value;

        #endregion

        public void Init(InteractiveObjectType type, int value)
        {
            _interactiveObjectType = type;
            _value = value;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(StringManager.TAG_PLAYER) && other.TryGetComponent(out ICollision obj))
            {
                var info = new InfoCollision
                {
                    ObjectType = _interactiveObjectType,
                    Value = _value,
                    OtherName = gameObject.name
                };
                Dbg.Log($"OnTriggerEnter:{info.ObjectType}, {info.Value}, {info.OtherName}");
                obj.OnCollision(info);
                Destroy(gameObject);
            }
        }

        protected override void Interaction()
        {
            Dbg.Log($"BonusView.Name:{gameObject.name}, Interaction");
            // throw new System.NotImplementedException();
        }
    }
}