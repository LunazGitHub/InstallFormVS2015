using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TalgrafSetup
{
    public partial class Setup : Form
    {
        public Setup()
        {
            InitializeComponent();   
            
        }

        private void FirstNextBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Installer inst = new Installer();
            inst.ShowDialog();
            this.Close();
   
        }

        private void CancelBtn_Click_1(object sender, EventArgs e)
        {
            
            if(MessageBox.Show("Are you sure you want to cancel the installation?", "Telgraf 2.3.2", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
