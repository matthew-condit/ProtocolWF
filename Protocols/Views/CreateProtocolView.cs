using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers;
using Toxikon.ProtocolManager.Interfaces;

namespace Toxikon.ProtocolManager.Views
{
    public partial class CreateProtocolView : Form, ICreateProtocol
    {
        public CreateProtocolView()
        {
            InitializeComponent();
        }

        private CreateProtocolController controller;

        public void SetController(CreateProtocolController controller)
        {
            this.controller = controller;   
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        public string SourceFile { get; set; }
        public string DestFolder { get; set; }
            
        private void SelectSourceFileButton_Click(object sender, EventArgs e)
        {
            if(this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.SourceFile = openFileDialog.FileName;
                this.SourceFileNameLabel.Text = System.IO.Path.GetFileName(this.SourceFile);
            }
        }

        private void SelectDestFolderButton_Click(object sender, EventArgs e)
        {
            if(this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.DestFolder = folderBrowserDialog.SelectedPath;
                var dirInfo = new System.IO.DirectoryInfo(this.DestFolder);
                this.DestFolderNameLabel.Text = dirInfo.Name;
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            this.controller.CreateButtonClicked();
        }
    }
}
