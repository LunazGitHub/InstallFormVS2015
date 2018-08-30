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
    public partial class ProgressBar : Form
    {
        

        public ProgressBar()
        {
            

            InitializeComponent();
        }

        private void ProgressBar_Load(object sender, EventArgs e)
        {
            timer1.Start();
            circularProgressBar1.Value = 0;
            circularProgressBar1.Maximum = 100;
            circularProgressBar1.Step = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            circularProgressBar1.Value += 1;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();

            if(circularProgressBar1.Value == 100)
            {
                this.Hide();
                timer1.Stop();
                new InstComplete().ShowDialog();
                this.Close();
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            if (MessageBox.Show("Are you sure you want to cancel the installation?", "Telgraf 2.3.2", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                Application.Exit();
            }
            else
            {
                timer1.Start();
            }

          
        }
    }
}
