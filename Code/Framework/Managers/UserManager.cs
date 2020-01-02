using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core;

namespace Framework.Managers
{
    static class UserManager
    {
        // Keeps track of the current users level.
        // No other functionality for the time being.
        // The class was created just in case other data the represents the current user must be used.

        public static int Level { get; private set; }

        /// <summary>
        /// Initialises all User Data for the Application.
        /// </summary>
        public static void Initialise()
        {
            // 1A. Does JOSN exists? Load data into current parameters.
            // 1B. If not, set Level to 1 and save new JSON to local disk.
        }
    }
}
