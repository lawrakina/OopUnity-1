using UnityEngine;
using View;


namespace Interface
{
    public interface IBonusFactory
    {
        BonusView CreateCoins();
        BonusView CreateLive();
        BonusView CreateBomb();
        BonusView CreateImmunity();
        BonusView CreateSpeedUp();
    }
}