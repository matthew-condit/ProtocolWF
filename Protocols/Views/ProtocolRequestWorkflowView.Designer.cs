namespace Protocols.Views
{
    partial class ProtocolRequestWorkflowView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.RequestedByLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RequestedDateLabel = new System.Windows.Forms.ToolStripLabel();
            this.CompletedLabel = new System.Windows.Forms.ToolStripLabel();
            this.InProcessLabel = new System.Windows.Forms.ToolStripLabel();
            this.ReceivedLabel = new System.Windows.Forms.ToolStripLabel();
            this.SubmittedLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SponsorLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RequestedByLabel,
            this.toolStripSeparator1,
            this.RequestedDateLabel,
            this.CompletedLabel,
            this.InProcessLabel,
            this.ReceivedLabel,
            this.SubmittedLabel,
            this.toolStripSeparator2,
            this.SponsorLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(706, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // RequestedByLabel
            // 
            this.RequestedByLabel.Name = "RequestedByLabel";
            this.RequestedByLabel.Size = new System.Drawing.Size(91, 22);
            this.RequestedByLabel.Text = "Requested By";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // RequestedDateLabel
            // 
            this.RequestedDateLabel.Name = "RequestedDateLabel";
            this.RequestedDateLabel.Size = new System.Drawing.Size(105, 22);
            this.RequestedDateLabel.Text = "Requested Date";
            // 
            // CompletedLabel
            // 
            this.CompletedLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CompletedLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.CompletedLabel.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.CompletedLabel.Name = "CompletedLabel";
            this.CompletedLabel.Size = new System.Drawing.Size(70, 22);
            this.CompletedLabel.Text = "Completed";
            this.CompletedLabel.MouseLeave += new System.EventHandler(this.StatusLabel_MouseLeave);
            this.CompletedLabel.MouseHover += new System.EventHandler(this.StatusLabel_MouseHover);
            // 
            // InProcessLabel
            // 
            this.InProcessLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.InProcessLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.InProcessLabel.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.InProcessLabel.Name = "InProcessLabel";
            this.InProcessLabel.Size = new System.Drawing.Size(77, 22);
            this.InProcessLabel.Text = "In Process";
            this.InProcessLabel.MouseLeave += new System.EventHandler(this.StatusLabel_MouseLeave);
            this.InProcessLabel.MouseHover += new System.EventHandler(this.StatusLabel_MouseHover);
            // 
            // ReceivedLabel
            // 
            this.ReceivedLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ReceivedLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.ReceivedLabel.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.ReceivedLabel.Name = "ReceivedLabel";
            this.ReceivedLabel.Size = new System.Drawing.Size(63, 22);
            this.ReceivedLabel.Text = "Received";
            this.ReceivedLabel.MouseLeave += new System.EventHandler(this.StatusLabel_MouseLeave);
            this.ReceivedLabel.MouseHover += new System.EventHandler(this.StatusLabel_MouseHover);
            // 
            // SubmittedLabel
            // 
            this.SubmittedLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SubmittedLabel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.SubmittedLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SubmittedLabel.Name = "SubmittedLabel";
            this.SubmittedLabel.Size = new System.Drawing.Size(70, 22);
            this.SubmittedLabel.Text = "Submitted";
            this.SubmittedLabel.MouseLeave += new System.EventHandler(this.StatusLabel_MouseLeave);
            this.SubmittedLabel.MouseHover += new System.EventHandler(this.StatusLabel_MouseHover);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // SponsorLabel
            // 
            this.SponsorLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SponsorLabel.Name = "SponsorLabel";
            this.SponsorLabel.Size = new System.Drawing.Size(56, 22);
            this.SponsorLabel.Text = "Sponsor";
            // 
            // ProtocolRequestWorkflowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.toolStrip1);
            this.Name = "ProtocolRequestWorkflowView";
            this.Size = new System.Drawing.Size(706, 25);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel RequestedDateLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel RequestedByLabel;
        private System.Windows.Forms.ToolStripLabel SubmittedLabel;
        private System.Windows.Forms.ToolStripLabel ReceivedLabel;
        private System.Windows.Forms.ToolStripLabel InProcessLabel;
        private System.Windows.Forms.ToolStripLabel CompletedLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel SponsorLabel;
    }
}
