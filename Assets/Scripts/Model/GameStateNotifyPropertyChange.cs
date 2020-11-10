using System;
using Enum;
using Interface;


namespace Model
{
    public class GameStateNotifyPropertyChange : IGameStateNotifyPropertyChange
    {
        #region Fields

        private GameState _value;
        private string    _lastMessage;

        #endregion


        #region ClassLiveCycles

        public GameStateNotifyPropertyChange(GameState value)
        {
            _value = value;
        }

        #endregion

        public GameState Value
        {
            get => _value;
            private set
            {
                _value = value;
                OnValueChange.Invoke(_value, _lastMessage);
            }
        }

        public event Action<GameState, string> OnValueChange = delegate(GameState i, string arg2) { };

        public void SetValue(GameState value, string message)
        {
            Value = value;
            _lastMessage = message;
        }
    }
}