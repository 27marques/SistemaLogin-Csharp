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
    public class ExcluirTag : BaseForm
    {
        CrudTag parent;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public ExcluirTag(CrudTag parent) : base("Excluir",SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();

            btnConfirmar = new ButtonForm("Confirmar", 180, 220, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 180, 260, this.handleCancel);

            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            try {
                TagController.ExcluirTag(0);
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
