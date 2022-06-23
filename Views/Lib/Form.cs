using System.Windows.Forms;
using System.Drawing;

namespace Views.Lib {
    public enum SizeScreen
    {
        Small,
        Medium,
        Large,
        Especific
    }


    public class BaseForm : Form
    {
        public BaseForm(
            string Title,
            SizeScreen size
        )
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            switch (size)
            {
                case SizeScreen.Especific:
                    this.ClientSize = new System.Drawing.Size(450, 900);
                    break;
                case SizeScreen.Large:
                    this.ClientSize = new System.Drawing.Size(900, 900);
                    break;
                case SizeScreen.Medium:
                    this.ClientSize = new System.Drawing.Size(600, 600);
                    break;
                default:
                    this.ClientSize = new System.Drawing.Size(350, 300);
                    break;
            }
            this.Text = Title;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.AliceBlue;
        }
    }
    
}

