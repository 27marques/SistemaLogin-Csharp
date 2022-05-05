using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Views.Lib;

namespace Views
{
    public class Login : BaseForm
    {
        FieldForm fieldNome;
        FieldForm fieldSenha;
		ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public Login() : base("Login",SizeScreen.Small)
        {
            fieldNome = new FieldForm("Usuário",20,20,180,20);
            fieldSenha = new FieldForm("Senha",20,100,180,60);

			btnConfirmar = new ButtonForm("Confirmar", 50, 220, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 180, 220, this.handleCancel);

            this.Controls.Add(fieldNome.lblField);
            this.Controls.Add(fieldNome.txtField);
            this.Controls.Add(fieldSenha.lblField);
            this.Controls.Add(fieldSenha.txtField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            //verificar se pode logar
            (new MenuPrincipal()).Show();

        }

        private void handleCancel(object sender, EventArgs e)
        {
            this.Close();
        }
    
    }

}
