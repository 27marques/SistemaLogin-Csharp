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
    public class CadastrarCategoria : BaseForm
    {
        FieldForm fieldNome;
        FieldForm fieldDescricao;
		ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public CadastrarCategoria() : base("Categoria",SizeScreen.Small)
        {
            fieldNome = new FieldForm("Nome",20,20,180,20);
            fieldDescricao = new FieldForm("Descrição",20,100,180,60);

			btnConfirmar = new ButtonForm("Confirmar", 180, 220, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 180, 260, this.handleCancel);

            this.Controls.Add(fieldNome.lblField);
            this.Controls.Add(fieldNome.txtField);
            this.Controls.Add(fieldDescricao.lblField);
            this.Controls.Add(fieldDescricao.txtField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            string title = "Atenção"; 
            string message = "Categoria Cadastrada";  
            MessageBox.Show(message, title);
            this.Close();

        }

        private void handleCancel(object sender, EventArgs e)
        {
            this.Close();
        }
    
    }

}
