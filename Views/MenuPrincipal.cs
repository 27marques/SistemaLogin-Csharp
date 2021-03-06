using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Views.Lib;
using Views;

namespace Views
{
    public class MenuPrincipal : BaseForm
    {
        Form parent;
        ButtonForm btnCategorias;
        ButtonForm btnTags;
        ButtonForm btnSenhas;
        ButtonForm btnUsuario;
        ButtonForm btnCancelar;


        public MenuPrincipal(Form parent) : base("Menu Principal", SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();
            btnCategorias = new ButtonForm("Categoria", 60, 70, this.handleCategorias);
            btnTags = new ButtonForm("Tags", 60, 150, this.handleTags);
            btnSenhas = new ButtonForm("Senhas", 200, 70, this.handleSenhas);
            btnUsuario = new ButtonForm("Usuário", 200, 150, this.handleUsuario);
            btnCancelar = new ButtonForm("Voltar", 120, 230, this.handleCancel);

            this.Controls.Add(btnCategorias);
            this.Controls.Add(btnTags);
            this.Controls.Add(btnSenhas);
            this.Controls.Add(btnUsuario);
            this.Controls.Add(btnCancelar);

        }

        private void handleCategorias(object sender, EventArgs e)
        {
            (new CrudCategoria(this)).Show();
            this.Hide();

        }

        private void handleTags(object sender, EventArgs e)
        {
            (new CrudTag(this)).Show();
            this.Hide();

        }

        private void handleSenhas(object sender, EventArgs e)
        {
            (new CrudSenha(this)).Show();
            this.Hide();

        }

        private void handleUsuario(object sender, EventArgs e)
        {
            (new CrudUsuario(this)).Show();
            this.Hide();

        }

        private void handleCancel(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close();

        }

    }
}

