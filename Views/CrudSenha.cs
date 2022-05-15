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
    public class CrudSenha : BaseForm
    {
        ListView listView;
        ButtonForm btnCadastrar;
        ButtonForm btnEditar;
        ButtonForm btnExcluir;
        ButtonForm btnCancelar;
       
        public CrudSenha() : base("Senhas",SizeScreen.Small)
        {
            listView = new ListView();
			listView.Location = new Point(10, 20);
			listView.Size = new Size(280,180);
            listView.View = View.Details;
            ListViewItem Senha1 = new ListViewItem("XXXXX");
			Senha1.SubItems.Add("ZZZZZZ");
            listView.Items.AddRange(new ListViewItem[]{Senha1});
			listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
    		listView.Columns.Add("Categoria", -2, HorizontalAlignment.Left);
            listView.Columns.Add("URL", -2, HorizontalAlignment.Left);
			listView.FullRowSelect = true;
			listView.GridLines = true;
			listView.AllowColumnReorder = true;
			listView.Sorting = SortOrder.Ascending;
			
            btnCadastrar = new ButtonForm("Cadastrar", 10, 220, this.CadastrarSenha);
            btnEditar = new ButtonForm("Editar", 10, 260, this.EditarSenha);
            btnExcluir = new ButtonForm("Excluir", 120, 220, this.ExcluirSenha);
            btnCancelar = new ButtonForm("Cancelar", 120, 260, this.handleCancel);

            this.Controls.Add(listView);
            this.Controls.Add(btnCadastrar);
            this.Controls.Add(btnEditar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnCancelar);

        }
  
        private void CadastrarSenha(object sender, EventArgs e)
        {
            //(new CadastrarSenha()).Show();

        }
        private void EditarSenha(object sender, EventArgs e)
        {
            //(new EditarSenha()).Show();

        }
        private void ExcluirSenha(object sender, EventArgs e)
        {
            //(new ExcluirSenha()).Show();

        }
        private void handleCancel(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
