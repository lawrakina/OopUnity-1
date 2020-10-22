namespace Model
{
    public sealed class PlayerModel
    {
        #region fields

        private float _speed;
        public float DistanceToCheckGround = 1.0f;

        #endregion

        #region Properties

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        #endregion
    }
}