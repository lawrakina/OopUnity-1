using Data;
using Enum;
using Healper;


namespace Model
{
    public sealed class PlayerModel
    {
        #region fields

        public readonly float DistanceToCheckGround = 1.0f;

        #endregion

        
        #region Properties

        public BoxFloat Speed { get; set; }
        public BoxInt Live { get; set; }
        public BoxInt CountCoins { get; set; }
        
        // public StateUnit StateUnit { get; set; }

        #endregion
    }
}