  using UnityEngine;

  
  namespace Units.Enemy
{
    public interface IEnemy : IMove
    {
        void Move(Vector3 point);
    }
}