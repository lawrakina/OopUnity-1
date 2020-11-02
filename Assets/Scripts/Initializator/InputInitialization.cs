using Interface;
using UserInput;


namespace Controller
{
    internal sealed class InputInitialization: IInitialization
    {
        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;

        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
        }
        public void Initialization()
        {
            
        }
    }
}