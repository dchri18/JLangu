﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // Initialise ALL Key classes here:
            // Encryption.Initialise()
            // UserManager.Initialise()
            // VocabularyManager.Initialise()

            //System.Windows.Forms.Application.Run(new Form1());
        }
    }
}
