using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;
using Controllers;
using Models;

namespace Views
{
    public class CadastrarSenha1 : BaseForm
    {
        CrudSenha parent;
        FieldForm fieldNome;
        FieldForm fieldCategoria;
        FieldForm fieldUrl;
        FieldForm fieldUsuario;
        FieldForm fieldSenha;
        FieldForm fieldProcedimento;
        FieldForm fieldTag;
        CheckedListBox checkedList;
        ComboBox comboBox;
        RichTextBox richBox;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;
        private object itemList;

        public CadastrarSenha1(CrudSenha parent) : base("InserirSenha", SizeScreen.Especific)
        {
            this.parent = parent;
            this.parent.Hide();

            fieldNome = new FieldForm("Nome", 80, 10, 260, 20);
            fieldCategoria = new FieldForm("Categoria", 80, 80, 260, 60);
            fieldUrl = new FieldForm("Url", 80, 150, 260, 60);
            fieldUsuario = new FieldForm("Usuario", 80, 225, 260, 60);
            fieldSenha = new FieldForm("Senha", 80, 300, 260, 60);
            fieldProcedimento = new FieldForm("Procedimento", 80, 390, 260, 60);
            fieldTag = new FieldForm("Tag", 80, 520, 260, 60);

            IEnumerable<Tag> tags = TagController.VisualizarTags();
            checkedList = new CheckedListBox();
            this.checkedList.Location = new System.Drawing.Point(80, 550);
            this.checkedList.Size = new System.Drawing.Size(260, 100);
            this.checkedList.TabIndex = 0;
            foreach (Tag item in tags)
            {
                checkedList.Items.Add(item.Id + " - " + item.Descricao);
            }

            IEnumerable<Categoria> categorias = CategoriaController.VisualizarCategoria();
            comboBox = new ComboBox();
            comboBox.Location = new System.Drawing.Point(80, 110);
            comboBox.Name = "Categoria";
            comboBox.Size = new System.Drawing.Size(245, 15);
            foreach (Categoria item in categorias)
            {
                comboBox.Items.Add(item.Id + " - " + item.Nome);
            }

            richBox = new RichTextBox();
            richBox.Location = new Point(80, 410);
            richBox.Size = new System.Drawing.Size(230, 100);

            btnConfirmar = new ButtonForm("Confirmar", 100, 650, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 250, 650, this.handleCancel);

            this.Controls.Add(checkedList);
            this.Controls.Add(comboBox);
            this.Controls.Add(fieldNome.lblField);
            this.Controls.Add(fieldNome.txtField);
            this.Controls.Add(fieldCategoria.lblField);
            this.Controls.Add(fieldUrl.lblField);
            this.Controls.Add(fieldUrl.txtField);
            this.Controls.Add(fieldUsuario.lblField);
            this.Controls.Add(fieldUsuario.txtField);
            this.Controls.Add(fieldSenha.lblField);
            this.Controls.Add(fieldSenha.txtField);
            this.Controls.Add(fieldProcedimento.lblField);
            this.Controls.Add(richBox);
            this.Controls.Add(fieldTag.lblField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }
        private void handleConfirm(object sender, EventArgs e)
        {
            try
            {
                string comboBoxValue = this.comboBox.Text;
                string[] destructComboBoxValue = comboBoxValue.Split('-');
                string idCategoria = destructComboBoxValue[0].Trim();
                SenhaController.InserirSenha(
                    this.fieldNome.txtField.Text,
                    Convert.ToInt32(idCategoria),
                    this.fieldUrl.txtField.Text,
                    this.fieldUsuario.txtField.Text,
                    this.fieldSenha.txtField.Text,
                    this.fieldProcedimento.txtField.Text
                );
                if (checkedList.SelectedItems.Count > 0)
                {
                    foreach (var item in checkedList.SelectedItems)
                    {
                        string checkedValue = itemList.ToString(); // "1 - Nome"
                        string[] destructCheckedValue = checkedValue.Split('-'); // ["1 ", " Nome"];
                        string idTagString = destructCheckedValue[0].Trim(); // "1 " => "1"
                        string idSenhaString = destructCheckedValue[0].Trim(); // "1 " => "1"
                        int TagId = Convert.ToInt32(idTagString);
                        int SenhaId = Convert.ToInt32(idSenhaString);
                        SenhaTagController.InserirSenhaTag(TagId, SenhaId);
                    }
                    //this.Hide();

                }
                else
                {
                    MessageBox.Show("Selecione 1 Tag da lista");
                }
                this.parent.LoadInfo();
                this.parent.Show();
                this.Close();
            }
            catch (Exception err)
            {
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
