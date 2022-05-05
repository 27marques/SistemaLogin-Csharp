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
    public class MenuPrincipal : BaseForm
    {
        ButtonForm btnCategorias;
        ButtonForm btnTags;
        ButtonForm btnSenhas;
        ButtonForm btnUsuario;
        ButtonForm btnCancelar;
    

        public MenuPrincipal() : base("Menu Principal",SizeScreen.Small)
        {
            btnCategorias = new ButtonForm("Categoria", 30, 70, this.handleCategorias);
            btnTags = new ButtonForm("Tags", 30, 120, this.handleTags);
            btnSenhas = new ButtonForm("Senhas", 170, 70, this.handleSenhas);
            btnUsuario = new ButtonForm("Usuário", 170, 120, this.handleUsuario);
            btnCancelar = new ButtonForm("Sair", 100, 230, this.handleCancel);

            this.Controls.Add(btnCategorias);
            this.Controls.Add(btnTags);
            this.Controls.Add(btnSenhas);
            this.Controls.Add(btnUsuario);
            this.Controls.Add(btnCancelar);

        }

        private void handleCategorias(object sender, EventArgs e)
        {
            //(new CrudCategoria()).Show();

        }

        private void handleTags(object sender, EventArgs e)
        {
            //(new CrudTag()).Show();

        }

        private void handleSenhas(object sender, EventArgs e)
        {
            //(new CrudSenha()).Show();

        }

        private void handleUsuario(object sender, EventArgs e)
        {
            //(new CrudUsuario()).Show();

        }

        private void handleCancel(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

