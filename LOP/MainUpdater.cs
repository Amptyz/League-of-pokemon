using System;
using System.Collections.Generic;

namespace LOP
{
    public class MainUpdater
    {
        private static MainUpdater instance;
        public static MainUpdater Instance
        {
            get { return instance ??= new MainUpdater(); }
        }
        
    }
}
