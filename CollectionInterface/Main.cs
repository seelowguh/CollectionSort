using CLCode.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLCode
{
    public partial class Main : Form
    {
        clsRegistry cReg = null;
        clsFileHandle cFile = null;
        public Main()
        {
            InitializeComponent();
            cReg = new clsRegistry();
            cFile = new clsFileHandle(cReg);
        }

        
        private void Main_Load(object sender, EventArgs e)
        {
            //  Get the defaults from the reg
            string _slstFolder = cReg.GetConfig().LastFolder;
            if (_slstFolder == string.Empty || _slstFolder == null)
                GetFolder();
            else
                txtFolder.Text = _slstFolder;

            if (txtFolder.Text != string.Empty)
            {
                if (txtFolder.Text.FolderExists())
                {
                    foreach (var f in cFile.GetDVDFilesAndFolders(txtFolder.Text))
                    {
                        if (f.FileExists())
                            f.MoveFile(string.Format("{0}\\DVD", txtFolder.Text));
                        else if (f.FolderExists())
                            f.MoveFolder(string.Format("{0}\\DVD", txtFolder.Text));

                    }

                    PopulateCode(clbSelected);

                }
            }

        }

        private void PopulateCode(CheckedListBox clb)
        {
            clb.Items.Clear();
            foreach (var _f in cFile.GetDisplayFileAndFolderNames(txtFolder.Text))
                clb.Items.Add(_f);
        }

        private void txtFolder_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GetFolder();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            foreach(string s in clbSelected.CheckedItems)
            {
                cFile.MoveFileOrFolder(txtFolder.Text, s);
            }
            PopulateCode(clbSelected);

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
