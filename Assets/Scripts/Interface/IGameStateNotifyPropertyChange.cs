using System;
using Enum;
using Model;


namespace Interface
{
    public interface IGameStateNotifyPropertyChange
    {
        GameState               Value { get; }
        event Action<GameState, string> OnValueChange;
        void                    SetValue(GameState value, string message);
    }
}