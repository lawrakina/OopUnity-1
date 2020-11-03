using UnityEngine;


namespace Interface
{
    public interface IBonusFactory
    {
        Transform CreateCoins();
        Transform CreateLive();
        Transform CreateBomb();
        Transform CreateImmunity();
        Transform CreateSpeedUp();
    }
}