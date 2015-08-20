namespace Toxikon.ProtocolManager.Views
{
    partial class CreateProtocolView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SelectSourceFileButton = new System.Windows.Forms.Button();
            this.SelectDestFolderButton = new System.Windows.Forms.Button();
            this.SourceFileNameLabel = new System.Windows.Forms.Label();
            this.DestFolderNameLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.CreateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // SelectSourceFileButton
            // 
            this.SelectSourceFileButton.Location = new System.Drawing.Point(53, 3);
            this.SelectSourceFileButton.Name = "SelectSourceFileButton";
            this.SelectSourceFileButton.Size = new System.Drawing.Size(134, 34);
            this.SelectSourceFileButton.TabIndex = 0;
            this.SelectSourceFileButton.Text = "Select Source File";
            this.SelectSourceFileButton.UseVisualStyleBackColor = true;
            this.SelectSourceFileButton.Click += new System.EventHandler(this.SelectSourceFileButton_Click);
            // 
            // SelectDestFolderButton
            // 
            this.SelectDestFolderButton.Location = new System.Drawing.Point(53, 3);
            this.SelectDestFolderButton.Name = "SelectDestFolderButton";
            this.SelectDestFolderButton.Size = new System.Drawing.Size(134, 35);
            this.SelectDestFolderButton.TabIndex = 1;
            this.SelectDestFolderButton.Text = "Select Destination Folder";
            this.SelectDestFolderButton.UseVisualStyleBackColor = true;
            this.SelectDestFolderButton.Click += new System.EventHandler(this.SelectDestFolderButton_Click);
            // 
            // SourceFileNameLabel
            // 
            this.SourceFileNameLabel.AutoSize = true;
            this.SourceFileNameLabel.Location = new System.Drawing.Point(193, 13);
            this.SourceFileNameLabel.Margin = new System.Windows.Forms.Padding(3, 13, 3, 0);
            this.SourceFileNameLabel.Name = "SourceFileNameLabel";
            this.SourceFileNameLabel.Size = new System.Drawing.Size(60, 13);
            this.SourceFileNameLabel.TabIndex = 2;
            this.SourceFileNameLabel.Text = "Source File";
            this.SourceFileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DestFolderNameLabel
            // 
            this.DestFolderNameLabel.AutoSize = true;
            this.DestFolderNameLabel.Location = new System.Drawing.Point(193, 13);
            this.DestFolderNameLabel.Margin = new System.Windows.Forms.Padding(3, 13, 3, 0);
            this.DestFolderNameLabel.Name = "DestFolderNameLabel";
            this.DestFolderNameLabel.Size = new System.Drawing.Size(60, 13);
            this.DestFolderNameLabel.TabIndex = 3;
            this.DestFolderNameLabel.Text = "Destination";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.SelectSourceFileButton);
            this.flowLayoutPanel1.Controls.Add(this.SourceFileNameLabel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(550, 40);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.SelectDestFolderButton);
            this.flowLayoutPanel2.Controls.Add(this.DestFolderNameLabel);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 58);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(550, 40);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(53, 3);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(134, 34);
            this.CreateButton.TabIndex = 6;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 13, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Step 1: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 13, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Step 2: ";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.CreateButton);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(12, 102);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(550, 40);
            this.flowLayoutPanel3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 13, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Step 3: ";
            // 
            // CreateProtocolView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(574, 152);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "CreateProtocolView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Protocol";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button SelectSourceFileButton;
        private System.Windows.Forms.Button SelectDestFolderButton;
        private System.Windows.Forms.Label SourceFileNameLabel;
        private System.Windows.Forms.Label DestFolderNameLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label3;
    }
}