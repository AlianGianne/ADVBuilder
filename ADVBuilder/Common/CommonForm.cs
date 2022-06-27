using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                if(c.Tag!= null)
                    c.Text = c.Tag.ToString() == "Integer" ? "-1" : "";
                else
                    c.Text = "";
            }
        }
    }
}
