using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Views;

namespace EncryptMe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.Run(new Login());

        }
    }
}
