using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Views.Lib;
using Models;
using Controllers;

namespace Views
{
    public class CrudTag : BaseForm
    {
        Form parent;
        ListView listView;
        ButtonForm btnCadastrar;
        ButtonForm btnEditar;
        ButtonForm btnExcluir;
        ButtonForm btnCancelar;

        public CrudTag(Form parent) : base("Tags", SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();
            listView = new ListView();
            listView.Location = new Point(10, 20);
            listView.Size = new Size(280,180);
            listView.View = View.Details;
            listView.Columns.Add("Descrição", -2, HorizontalAlignment.Left);
    		listView.FullRowSelect = true;
			listView.GridLines = true;
			listView.AllowColumnReorder = true;
			listView.Sorting = SortOrder.Ascending;

            btnCadastrar = new ButtonForm("Cadastrar", 10, 220, this.handleIncluir);
            btnEditar = new ButtonForm("Editar", 10, 260, this.handleAlterar);
            btnExcluir = new ButtonForm("Excluir", 120, 220, this.handleExcluir);
            btnCancelar = new ButtonForm("Cancelar", 120, 260, this.handleCancel);

            this.LoadInfo();
            this.Controls.Add(listView);
            this.Controls.Add(btnCadastrar);
            this.Controls.Add(btnEditar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnCancelar);

        }

        public void LoadInfo() {
            IEnumerable<Tag> tags = TagController.GetTag();

            this.listView.Items.Clear();
            foreach (Tag item in tags)
            {
                ListViewItem lvItem = new ListViewItem(item.Id.ToString());
                lvItem.SubItems.Add(item.Descricao);
                
                this.listView.Items.Add(lvItem);
            }
        }
  
        private void handleIncluir(object sender, EventArgs e)
        {
            (new CadastrarTag(this)).Show();
            this.Hide();

        }
        private void handleAlterar(object sender, EventArgs e)
        {
            //(new AlterarTag()).Show();
            this.Hide();

        }
        private void handleExcluir(object sender, EventArgs e)
        {
            //(new RemoverTag()).Show();
            this.Hide();

        }
        private void handleCancel(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close(); 
        }
    }
}

 