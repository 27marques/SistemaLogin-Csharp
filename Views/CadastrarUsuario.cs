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
    public class CadastrarUsuario : Pessoa
    {
        FieldForm fieldNome;
        FieldForm fieldEmail;
        FieldForm fieldSenha;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public CadastrarUsuario() 
        {
            fieldNome = new FieldForm("Nome",20,320,120,20);
            fieldEmail = new FieldForm("E-mail",20,380,120,20);
            fieldSenha = new FieldForm("Senha",20,440,100,20);
           		
            btnConfirmar = new ButtonForm("Confirmar", 200, 520, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 300, 520, this.handleCancel);

            this.Controls.Add(fieldNome.lblField);
            this.Controls.Add(fieldNome.txtField);
            this.Controls.Add(fieldEmail.lblField);
            this.Controls.Add(fieldEmail.txtField);
            this.Controls.Add(fieldSenha.lblField);
            this.Controls.Add(fieldSenha.txtField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            string title = "Atenção"; 
            string message = "Usuário Cadastrado";  
            MessageBox.Show(message, title);
            this.Close();

        }

        private void handleCancel(object sender, EventArgs e)
        {
            this.Close();
        }
    
    }

}
