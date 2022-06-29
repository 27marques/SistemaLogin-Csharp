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
    public class AlterarTag : BaseForm
    {
        CrudTag parent;
        FieldForm fieldDescricao;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        ListViewItem selectedItem;
        int id = 0;

        public AlterarTag(CrudTag parent) : base("Alterar Tag", SizeScreen.Small) 
        {
            this.parent = parent;
            this.parent.Hide();

            this.selectedItem = this.parent.listView.SelectedItems[0];
            this.id = Convert.ToInt32(this.selectedItem.Text);

            Tag tag = TagController.GetTag(id);

            fieldDescricao = new FieldForm("Descrição",20,100,180,60);
                        
			btnConfirmar = new ButtonForm("Confirmar", 40, 230, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 200, 230, this.handleCancel);

            this.Controls.Add(fieldDescricao.lblField);
            this.Controls.Add(fieldDescricao.txtField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);

            this.fieldDescricao.txtField.Text = tag.Descricao;
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            try {
                TagController.AlterarTag(
                    Convert.ToInt32(this.parent.listView.SelectedItems[0].Text),
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
