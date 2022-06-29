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
using Models;

namespace Views
{
    public class AlterarUsuario : BaseForm
    {
        CrudUsuario parent;
        FieldForm fieldNome;
        FieldForm fieldEmail;
        FieldForm fieldSenha;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;
        ListViewItem selectedItem;
        int id = 0;

        public AlterarUsuario(CrudUsuario parent) : base ("Alterar Usuário",SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();

            this.selectedItem = this.parent.listView.SelectedItems[0];
            this.id = Convert.ToInt32(this.selectedItem.Text);

            Usuario usuario = UsuarioController.GetUsuario(id);

            fieldNome = new FieldForm("Nome",20,20,180,20);
            fieldEmail = new FieldForm("E-mail",20,100,180,60);
            fieldSenha = new FieldForm("Senha",20,180,180,100);
           		
            btnConfirmar = new ButtonForm("Confirmar", 60, 260, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 180, 260, this.handleCancel);

            this.fieldNome.txtField.Text = usuario.Nome;
            this.fieldEmail.txtField.Text = usuario.Nome;
            this.fieldSenha.txtField.Text = usuario.Senha;
            
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
            try {
                UsuarioController.AlterarUsuario(
                    Convert.ToInt32(this.parent.listView.SelectedItems[0].Text),
                    this.fieldNome.txtField.Text,
                    this.fieldEmail.txtField.Text,
                    this.fieldSenha.txtField.Text
                );
                this.parent.LoadInfo();
                this.parent.Show();
                this.Close();
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }

        }

        private void handleCancel(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Deseja mesmo sair? ", "Mensage do sistema ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.parent.Show();
                this.Close();
            }
        }
    
    }

}
