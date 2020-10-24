using Controller;
using Data;
using UnityEngine;


namespace Initializator
{
    public sealed class InputInitializator
    {
        public InputInitializator(MainController mainController, InputStruct inputVector)
        {
            mainController.AddUpdated(new InputController( inputVector));
        }
    }
}