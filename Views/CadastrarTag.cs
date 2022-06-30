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
    public class CadastrarTag : BaseForm
    {
        CrudTag parent;
        FieldForm fieldDescricao;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public CadastrarTag(CrudTag parent) : base("Cadastrar Tag", SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();

            fieldDescricao = new FieldForm("Descrição", 80, 100, 180, 60);

            btnConfirmar = new ButtonForm("Confirmar", 60, 220, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 180, 220, this.handleCancel);

            this.Controls.Add(fieldDescricao.lblField);
            this.Controls.Add(fieldDescricao.txtField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            try
            {
                TagController.IncluirTag(
                    this.fieldDescricao.txtField.Text
                );
                this.parent.LoadInfo();
                this.parent.Show();
                this.Close();
            }
            catch (Exception err)
            {
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
