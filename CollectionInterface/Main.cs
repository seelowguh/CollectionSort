using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLCode;

namespace CLCode
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        

        private void Main_Load(object sender, EventArgs e)
        {
            BaseClasses.CRegistry cReg = new BaseClasses.CRegistry();
            
        }

        private void txtFolder_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            txtFolder.Text = GetFolder();
        }

        private string GetFolder()
        {
            string sReturn = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowNewFolderButton = false;
            using (fbd)
                if (fbd.ShowDialog() == DialogResult.OK)
                    sReturn = fbd.SelectedPath;

            return sReturn;
        }
    }
}
