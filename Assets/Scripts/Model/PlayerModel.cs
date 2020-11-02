using Data;


namespace Model
{
    public sealed class PlayerModel
    {
        #region fields

        public readonly float DistanceToCheckGround = 1.0f;

        private BoxInt _live;

        #endregion


        #region Properties
        
        public BoxFloat Speed { get; set; }

        public BoxInt Live
        {
            get => _live;
            set
            {
                if (!Immunity)
                    _live = value;
            }
        }

        public BoxInt CountCoins { get; set; }
        public bool Immunity { get; set; }
        public float NormalSpeed { get; set; }

        // public StateUnit StateUnit { get; set; }

        #endregion
    }
}