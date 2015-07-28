using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Views.Protocols
{
    public partial class ProtocolRequestDirectorView : RequestDetailView
    {
        public ProtocolRequestDirectorView()
        {
            InitializeComponent();
            this.TemplateListView = this.TitlesListView;
            this.RequestForm = this.RequestFormDirectorView;
        }

        public override Control ParentControl
        {
            get { return this.ParentForm; }
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            this.controller.AddEventButtonClicked();
        }

        private void AddCommentButton_Click(object sender, EventArgs e)
        {
            this.controller.AddCommentsButtonClicked();
        }

        private void ViewEventsButton_Click(object sender, EventArgs e)
        {
            this.controller.ViewEventsButtonClicked();
        }

        private void ViewCommentsButton_Click(object sender, EventArgs e)
        {
            this.controller.ViewCommentsButtonClicked();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            this.controller.OpenFileButtonClicked();
        }
    }
}
