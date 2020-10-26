using Enum;


namespace Model
{
    public sealed class PlayerModel
    {
        #region fields

        public readonly float DistanceToCheckGround = 1.0f;

        #endregion

        
        #region Properties

        public float Speed { get; set; }
        public int Live { get; set; }
        public int CountCoins { get; set; }
        
        // public StateUnit StateUnit { get; set; }

        #endregion
    }
}