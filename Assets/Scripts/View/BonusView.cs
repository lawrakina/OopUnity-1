using Enum;
using Healper;
using Interface;
using UnityEngine;


namespace View
{
    public class BonusView : MonoBehaviour
    {
        #region fields

        [SerializeField] private BonusType _bonusType;

        #endregion
        
        private void OnTriggerEnter(Collider other)
        {
            Dbg.Log(other);
            if (other.TryGetComponent(out ICollision obj))
            {
                Dbg.Log("Ok");
                obj.OnCollision(_bonusType);
                Destroy(gameObject);
            }
        }
    }
}
