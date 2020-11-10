using Units.Player;


namespace Interface
{
    public interface IPlayerFactory
    {
        IPlayerView CreatePlayer();
    }
}