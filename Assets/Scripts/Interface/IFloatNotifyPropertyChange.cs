using System;


namespace Interface
{
    public interface IFloatNotifyPropertyChange
    {
        float               Value { get; set; }
        event Action<float> OnValueChange;
    }
}