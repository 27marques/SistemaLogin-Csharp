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
using static System.Windows.Forms.CheckedListBox;

namespace Views
{
    public class CadastrarSenha1 : BaseForm
    {
        CrudSenha parent;
        ListView listView;
        FieldForm fieldNome;
        FieldForm fieldCategoria;
        FieldForm fieldUrl;
        FieldForm fieldUsuario;
        FieldForm fieldSenha;
        FieldForm fieldProcedimento;
        FieldForm fieldTag;
        CheckedListBox checkedList;
        CheckedListBox ChechedListItem;
        ComboBox comboBox;
        RichTextBox richBox;
		ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public CadastrarSenha1(CrudSenha parent) : base("Cadastrar Senha",SizeScreen.Especific)
        {
            this.parent = parent;
            this.parent.Hide();

            fieldNome = new FieldForm("Nome",20,10,260,20);
            fieldCategoria = new FieldForm("Categoria",20,80,260,60);
            fieldUrl = new FieldForm("Url",20,150,260,60);
            fieldUsuario = new FieldForm("Usuario",20,225,260,60);
            fieldSenha = new FieldForm("Senha",20,300,260,60);
            fieldProcedimento = new FieldForm("Procedimento",20,390,260,60);
            fieldTag = new FieldForm("Tag",20,530,260,60);
            
            checkedList = new CheckedListBox();
			this.checkedList.Location = new System.Drawing.Point(20, 550);
            this.checkedList.Size = new System.Drawing.Size(260, 100);
            this.checkedList.TabIndex = 0;

            comboBox = new ComboBox(); 
            comboBox.Location = new System.Drawing.Point(20, 110);
            comboBox.Name = "Categoria";
            comboBox.Size = new System.Drawing.Size(245, 15);
        
            richBox = new RichTextBox();
            richBox.Location = new Point(20, 410);
            richBox.Size = new System.Drawing.Size(230, 100);
            
			btnConfirmar = new ButtonForm("Confirmar", 100, 650, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 250, 650, this.handleCancel);

            this.LoadInfo();
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

        public void LoadInfo() {
             /*IEnumerable<Senha> senhas = SenhaController.VisualizarSenha();

            this.checkedList.Items.Clear();
            foreach (Senha item in senhas)
            {
                checkedListItem clItem = new checkedListItem(item.Id.ToString());
                clItem.SubItems.Add(item.Descricao);

                this.checkedList.Items.Add(clItem);
            }*/
        }
        private void handleConfirm(object sender, EventArgs e)
        {
           /*try {
                SenhaController.InserirSenha(
                    this.fieldNome.txtField.Text,
                    this.fieldCategoria.txtField.Text,
                    this.fieldUrl.txtField.Text,
                    this.fieldUsuario.txtField.Text,
                    this.fieldSenha.txtField.Text,
                    this.fieldProcedimento.txtField.Text
                    //TAG??
                );
                if (checkedList.SelectedItems.Count > 0) {
                ChechedListItem item = this.checkedList.SelectedItems[0];
                int id = Convert.ToInt32(item.Text);
                } else {
                    MessageBox.Show("Selecione 1 tag da lista");
                }
                this.parent.LoadInfo();
                this.parent.Show();
                this.Close();
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }*/
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
