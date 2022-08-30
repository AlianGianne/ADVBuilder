using System.Linq;
using System.Windows.Forms;

namespace ADVBuilder.Common
{
    public class CommonForm : Form
    {
        public void CleanFields(Form pForm)
        {
            foreach (object obj in pForm.Controls)
            {
            }
        }

        public void CleanFields(Panel pPanel)
        {
            foreach (var c in pPanel.Controls.OfType<TextBox>())
            {
                if (c.Tag != null)
                    c.Text = c.Tag.ToString() == "Integer" ? "-1" : "";
                else
                    c.Text = "";
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CommonForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "CommonForm";
            this.Load += new System.EventHandler(this.CommonForm_Load);
            this.ResumeLayout(false);

        }

        private void CommonForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}