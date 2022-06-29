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
    public class AlterarCategoria : BaseForm
    {
        CrudCategoria parent;
        FieldForm fieldNome;
        FieldForm fieldDescricao;
		ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        ListViewItem selectedItem;
        int id = 0;        

        public AlterarCategoria(CrudCategoria parent) : base("Alterar Categoria",SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();

            this.selectedItem = this.parent.listView.SelectedItems[0];
            this.id = Convert.ToInt32(this.selectedItem.Text);

            Categoria categoria = CategoriaController.GetCategoria(id);

            fieldNome = new FieldForm("Nome",20,20,180,20);
            fieldDescricao = new FieldForm("Descrição",20,100,180,60);

			btnConfirmar = new ButtonForm("Confirmar", 50, 230, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 200, 230, this.handleCancel);

            this.fieldNome.txtField.Text = categoria.Nome;
            this.fieldDescricao.txtField.Text = categoria.Descricao;

            this.Controls.Add(fieldNome.lblField);
            this.Controls.Add(fieldNome.txtField);
            this.Controls.Add(fieldDescricao.lblField);
            this.Controls.Add(fieldDescricao.txtField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            try {
                CategoriaController.AlterarCategoria(
                    Convert.ToInt32(this.parent.listView.SelectedItems[0].Text),
                    this.fieldNome.txtField.Text,
                    this.fieldDescricao.txtField.Text
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
