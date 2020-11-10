using System;


namespace Interface
{
    public interface IIntNotifyPropertyChange
    {
        int Value { get; set; }
        event Action<int> OnValueChange;
    }
}