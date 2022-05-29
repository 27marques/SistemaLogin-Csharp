using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Views;
using Controllers;

namespace EncryptMe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*try {
            UsuarioController.InserirUsuario("Administrador","admin@email.com", "12345678");
            }
            catch (Exception err) {
                MessageBox.Show(err.Message);

            }*/
            Application.EnableVisualStyles();
            Application.Run(new Login());

        }
    }
}
