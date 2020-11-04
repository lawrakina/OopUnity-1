using System;
using Interface;
using Model;


namespace Units.Player
{
    public interface IPlayerView:  IBaseUnitView, ICollision
    {
        event Action<InfoCollision> OnBonusUp;
    }
}