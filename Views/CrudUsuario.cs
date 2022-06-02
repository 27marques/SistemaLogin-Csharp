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
    public class CrudUsuario : BaseForm
    {
        Form parent;
        ListView listView;
        ButtonForm btnCadastrar;
        ButtonForm btnEditar;
        ButtonForm btnExcluir;
        ButtonForm btnCancelar;
       
        public CrudUsuario(Form parent) : base("Lista de Usuários",SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();
            listView = new ListView();
			listView.Location = new Point(10, 20);
			listView.Size = new Size(280,180);
            listView.View = View.Details;
            listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
    		listView.Columns.Add("Email", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Senha", -2, HorizontalAlignment.Left);
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
            IEnumerable<Usuario> usuarios = UsuarioController.VisualizarUsuario();

            this.listView.Items.Clear();
            foreach (Usuario item in usuarios)
            {
                ListViewItem lvItem = new ListViewItem(item.Id.ToString());
                lvItem.SubItems.Add(item.Nome);
                lvItem.SubItems.Add(item.Email);
                lvItem.SubItems.Add(item.Senha);

                this.listView.Items.Add(lvItem);
            }
        }
  
        private void handleIncluir(object sender, EventArgs e)
        {
            (new CadastrarUsuario(this)).Show();
            this.Hide();

        }
        private void handleAlterar(object sender, EventArgs e)
        {
            if (this.listView.SelectedItems.Count > 0) {
                (new AlterarUsuario(this)).Show();
                this.Hide();
            } else {
                MessageBox.Show("Selecione ao menos um item", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        private void handleExcluir(object sender, EventArgs e)
        {
            if (this.listView.SelectedItems.Count > 0) {
                int id = Convert.ToInt32(this.listView.SelectedItems[0].Text);
                DialogResult result = MessageBox.Show(
                    $"Deseja excluir o item {id}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes) {
                    UsuarioController.RemoverUsuario(id);
                    this.LoadInfo();
                }
            } else {
                MessageBox.Show("Selecione ao menos um item", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        private void handleCancel(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close(); 
        }
    }
}
