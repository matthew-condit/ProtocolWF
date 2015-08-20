using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Interfaces;

namespace Toxikon.ProtocolManager.Controllers
{
    public class CreateProtocolController
    {
        private ICreateProtocol view;

        public CreateProtocolController(ICreateProtocol view)
        {
            this.view = view;
            this.view.SetController(this);
        }

        public void CreateButtonClicked()
        {
            if(this.view.SourceFile == null || this.view.DestFolder == null)
            {
                MessageBox.Show("Source file and destination folder are required!");
                this.view.SetDialogResult(System.Windows.Forms.DialogResult.Retry);
            }
            else
            {
                this.view.SetDialogResult(DialogResult.OK);
            }
        }
    }
}
