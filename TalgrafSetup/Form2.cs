using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Permissions;

namespace TalgrafSetup
{
    public partial class Installer : Form
    {

       
        FolderBrowserDialog fdb = new FolderBrowserDialog();

        public Installer()
        {
            InitializeComponent();

        }

        private void SecondFormBackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Setup stp = new Setup();
            stp.ShowDialog();
            this.Close();

        }

        public void BrwseBtn_Click(object sender, EventArgs e)
        {

            fdb.RootFolder = System.Environment.SpecialFolder.MyComputer;
            fdb.ShowNewFolderButton = true;

            if (fdb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                textBox1.Text = fdb.SelectedPath;

             

                string fileName = System.IO.Path.GetRandomFileName();
                string newPath = Path.Combine(textBox1.Text, "Telgraf");

                if (!Directory.Exists(newPath))
                {

                    Directory.CreateDirectory(newPath);
                    Directory.SetCurrentDirectory(newPath);

                    newPath = Path.Combine(newPath, fileName);


                    if (!System.IO.File.Exists(newPath))
                    {
                        using (System.IO.FileStream fs = System.IO.File.Create(newPath))
                        {
                            for (byte i = 0; i < 100; i++)
                            {
                                fs.WriteByte(i);

                            }
                        }
                    }

                }

            }
        }

        public void InstallBtn_Click(object sender, EventArgs e)
        {


            if (Directory.Exists(fdb.SelectedPath))
            {
                this.Hide();
                ProgressBar bar = new ProgressBar();
                bar.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Selected path is incorrect!");

            }
                           
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel the installation?", "Telgraf 2.3.2", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
                    
         
    

