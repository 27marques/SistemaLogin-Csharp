using System;
using System.Windows.Forms;
using System.Drawing;

namespace Views.Lib
{
    public class Pessoa : BaseForm
    {
        FieldForm fieldNome;
        FieldForm fieldCpf;
        FieldForm fieldTelefone;
        FieldForm fieldEmail;
        FieldForm fieldSenha;
                     

        public Pessoa() : base("Pessoa",SizeScreen.Medium)
        {
            fieldNome = new FieldForm("Nome",20,20,400,20);
            fieldCpf = new FieldForm("CPF",20,80,120,20);
            fieldTelefone = new FieldForm("Telefone",20,140,120,20);
            fieldEmail = new FieldForm("E-mail",20,200,400,20);
            fieldSenha = new FieldForm("Senha",20,260,120,20);

            this.Controls.Add(fieldNome.lblField);
            this.Controls.Add(fieldNome.txtField);
            this.Controls.Add(fieldCpf.lblField);
            this.Controls.Add(fieldCpf.txtField);
            this.Controls.Add(fieldTelefone.lblField);
            this.Controls.Add(fieldTelefone.txtField);
            this.Controls.Add(fieldEmail.lblField);
            this.Controls.Add(fieldEmail.txtField);
            this.Controls.Add(fieldSenha.lblField);
            this.Controls.Add(fieldSenha.txtField);
            
        }

    }

}