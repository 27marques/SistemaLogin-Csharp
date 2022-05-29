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
    public class AlterarTag : BaseForm
    {
        CrudTag parent;
        FieldForm fieldDescricao;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public AlterarTag(CrudTag parent) : base("Alterar Tag", SizeScreen.Small) 
        {
            this.parent = parent;
            this.parent.Hide();

            fieldDescricao = new FieldForm("DEscrição",20,320,120,20);
                        
			btnConfirmar = new ButtonForm("Confirmar", 200, 520, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 300, 520, this.handleCancel);

            this.Controls.Add(fieldDescricao.lblField);
            this.Controls.Add(fieldDescricao.txtField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            try {
                TagController.AlterarTag(
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
