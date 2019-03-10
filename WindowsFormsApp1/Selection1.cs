using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Selection1 : Form
    {
        EMBA e1;
        MBA e2;
        public Selection1()
        {
            InitializeComponent();
        }
        
        private void btnEMBA_Click(object sender, EventArgs e)
        {
            e1 = new EMBA();
            e1.MdiParent = Application.OpenForms.OfType<Main_Menu>().FirstOrDefault();
            e1.Show();
            e1.Left = this.Left;
            e1.Top = this.Top;
            this.Close();

        }

        private void btnMBA_Click(object sender, EventArgs e)
        {
            e2 = new MBA();
            e2.MdiParent = Application.OpenForms.OfType<Main_Menu>().FirstOrDefault();
            e2.Show();
            e2.Left = this.Left;
            e2.Top = this.Top;
            this.Close();
        }
    }
}
