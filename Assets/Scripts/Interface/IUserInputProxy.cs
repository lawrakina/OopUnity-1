using System;


namespace Interface
{
    public interface IUserInputProxy
    {
        event Action<float> AxisOnChange;
        void                GetAxis();
    }
}