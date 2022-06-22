using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Views.Lib;
using Controllers;

namespace Views
{
    public class Login : BaseForm
    {
        FieldForm fieldUsuario;
        FieldForm fieldSenha;
		ButtonForm btnConfirmar;
        ButtonForm btnCancelar;
        ButtonForm btnCadastrar;

        public Login() : base("Login",SizeScreen.Small)
        {
           
            fieldUsuario = new FieldForm("Usuário",20,20,180,20);
            fieldSenha = new FieldForm("Senha",20,100,180,60);
            fieldSenha.txtField.PasswordChar = '*';

			btnConfirmar = new ButtonForm("Confirmar", 50, 220, this.handleConfirm);
            btnCancelar = new ButtonForm("Sair", 180, 220, this.handleCancel);
            btnCadastrar = new ButtonForm("Cadastrar", 120, 260, this.handleIncluir);

            this.Controls.Add(fieldUsuario.lblField);
            this.Controls.Add(fieldUsuario.txtField);
            this.Controls.Add(fieldSenha.lblField);
            this.Controls.Add(fieldSenha.txtField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
            this.Controls.Add(btnCadastrar);
        }

        private void handleConfirm(object sender, EventArgs e)

        {
            try {
                UsuarioController.Auth(
                    this.fieldUsuario.txtField.Text,
                    this.fieldSenha.txtField.Text
                );
                (new MenuPrincipal(this)).Show();

            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }

        }
       
        private void handleCancel(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Deseja mesmo sair? ", "Mensage do sistema ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void handleIncluir(object sender, EventArgs e)
        {
            (new CadastrarUsuario1(this)).Show();
            this.Hide();

        }
    
    }

}
