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
    public class CrudUsuario : BaseForm
    {
        ListView listView;
        ButtonForm btnCadastrar;
        ButtonForm btnEditar;
        ButtonForm btnExcluir;
        ButtonForm btnCancelar;
       
        public CrudUsuario() : base("Lista de Usuários",SizeScreen.Small)
        {
            listView = new ListView();
			listView.Location = new Point(10, 20);
			listView.Size = new Size(280,180);
            listView.View = View.Details;
            ListViewItem Usuario1 = new ListViewItem("XXXXX");
			Usuario1.SubItems.Add("ZZZZZZ");
            listView.Items.AddRange(new ListViewItem[]{Usuario1});
			listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
    		listView.Columns.Add("Email", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Senha", -2, HorizontalAlignment.Left);
			listView.FullRowSelect = true;
			listView.GridLines = true;
			listView.AllowColumnReorder = true;
			listView.Sorting = SortOrder.Ascending;
			
            btnCadastrar = new ButtonForm("Cadastrar", 10, 220, this.CadastrarUsuario);
            btnEditar = new ButtonForm("Editar", 10, 260, this.EditarUsuario);
            btnExcluir = new ButtonForm("Excluir", 120, 220, this.ExcluirUsuario);
            btnCancelar = new ButtonForm("Cancelar", 120, 260, this.handleCancel);

            this.Controls.Add(listView);
            this.Controls.Add(btnCadastrar);
            this.Controls.Add(btnEditar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnCancelar);

        }
  
        private void CadastrarUsuario(object sender, EventArgs e)
        {
            //(new CadastrarUsuario()).Show();

        }
        private void EditarUsuario(object sender, EventArgs e)
        {
            //(new EditarUsuario()).Show();

        }
        private void ExcluirUsuario(object sender, EventArgs e)
        {
            //(new ExcluirUsuario()).Show();

        }
        private void handleCancel(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
