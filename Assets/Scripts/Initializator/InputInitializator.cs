﻿using Controller;
using Data;


namespace Initializator
{
    public sealed class InputInitializator
    {
        public InputInitializator(Services services)
        {
            services.MainController.AddUpdated(new InputController(services));
        }
    }
}