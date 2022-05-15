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
    public class CrudCategoria : BaseForm
    {
        ListView listView;
        ButtonForm btnCadastrar;
        ButtonForm btnEditar;
        ButtonForm btnExcluir;
        ButtonForm btnCancelar;
       
        public CrudCategoria() : base("Lista de Categorias",SizeScreen.Small)
        {
            listView = new ListView();
			listView.Location = new Point(10, 20);
			listView.Size = new Size(280,180);
            listView.View = View.Details;
            ListViewItem Categoria1 = new ListViewItem("XXXXX");
			Categoria1.SubItems.Add("ZZZZZZ");
            listView.Items.AddRange(new ListViewItem[]{Categoria1});
			listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
    		listView.Columns.Add("Descrição", -2, HorizontalAlignment.Left);
			listView.FullRowSelect = true;
			listView.GridLines = true;
			listView.AllowColumnReorder = true;
			listView.Sorting = SortOrder.Ascending;
			
            btnCadastrar = new ButtonForm("Cadastrar", 10, 220, this.CadastrarCategoria);
            btnEditar = new ButtonForm("Editar", 10, 260, this.EditarCategoria);
            btnExcluir = new ButtonForm("Excluir", 120, 220, this.ExcluirCategoria);
            btnCancelar = new ButtonForm("Cancelar", 120, 260, this.handleCancel);

            this.Controls.Add(listView);
            this.Controls.Add(btnCadastrar);
            this.Controls.Add(btnEditar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnCancelar);

        }
  
        private void CadastrarCategoria(object sender, EventArgs e)
        {
            (new CadastrarCategoria()).Show();

        }
        private void EditarCategoria(object sender, EventArgs e)
        {
            //(new EditarCategoria()).Show();

        }
        private void ExcluirCategoria(object sender, EventArgs e)
        {
            //(new ExcluirCategoria()).Show();

        }
        private void handleCancel(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
