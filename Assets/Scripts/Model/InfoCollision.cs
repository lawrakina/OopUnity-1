using Enum;


namespace Model
{
    public struct InfoCollision
    {
        public InteractiveObjectType ObjectType{ get; set; }
        public int Value { get; set; }
        public string OtherName{ get; set; }
    }
}