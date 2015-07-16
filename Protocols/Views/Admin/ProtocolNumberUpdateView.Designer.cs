namespace Toxikon.ProtocolManager.Views.Admin
{
    partial class ProtocolNumberUpdateView
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
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.RequestIDTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.TemplateIDTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.SearchButton = new System.Windows.Forms.ToolStripButton();
            this.UpdateButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TrueFalseRadioButtonGroup = new System.Windows.Forms.FlowLayoutPanel();
            this.TrueRadioButton = new System.Windows.Forms.RadioButton();
            this.FalseRadioButton = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.ProtocolTypeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RevisedNumberTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ProtocolNumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.YearNumberTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SequenceNumberTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.TrueFalseRadioButtonGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.RequestIDTextBox,
            this.toolStripLabel2,
            this.TemplateIDTextBox,
            this.SearchButton,
            this.UpdateButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(680, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(69, 35);
            this.toolStripLabel1.Text = "Request ID: ";
            // 
            // RequestIDTextBox
            // 
            this.RequestIDTextBox.BackColor = System.Drawing.Color.LemonChiffon;
            this.RequestIDTextBox.Name = "RequestIDTextBox";
            this.RequestIDTextBox.Size = new System.Drawing.Size(100, 38);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(77, 35);
            this.toolStripLabel2.Text = "Template ID: ";
            // 
            // TemplateIDTextBox
            // 
            this.TemplateIDTextBox.BackColor = System.Drawing.Color.LemonChiffon;
            this.TemplateIDTextBox.Name = "TemplateIDTextBox";
            this.TemplateIDTextBox.Size = new System.Drawing.Size(100, 38);
            // 
            // SearchButton
            // 
            this.SearchButton.Image = global::Toxikon.ProtocolManager.Properties.Resources.ZoomNeutral_16xlG;
            this.SearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(46, 35);
            this.SearchButton.Text = "Search";
            this.SearchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.UpdateButton.Image = global::Toxikon.ProtocolManager.Properties.Resources.StatusAnnotations_Complete_and_ok_16xLG_color;
            this.UpdateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(49, 35);
            this.UpdateButton.Text = "Update";
            this.UpdateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.TrueFalseRadioButtonGroup, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ProtocolTypeTextBox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.RevisedNumberTextBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ProtocolNumberTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.YearNumberTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.SequenceNumberTextBox, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(680, 117);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // TrueFalseRadioButtonGroup
            // 
            this.TrueFalseRadioButtonGroup.Controls.Add(this.TrueRadioButton);
            this.TrueFalseRadioButtonGroup.Controls.Add(this.FalseRadioButton);
            this.TrueFalseRadioButtonGroup.Location = new System.Drawing.Point(477, 66);
            this.TrueFalseRadioButtonGroup.Name = "TrueFalseRadioButtonGroup";
            this.TrueFalseRadioButtonGroup.Size = new System.Drawing.Size(195, 35);
            this.TrueFalseRadioButtonGroup.TabIndex = 11;
            // 
            // TrueRadioButton
            // 
            this.TrueRadioButton.AutoSize = true;
            this.TrueRadioButton.Location = new System.Drawing.Point(3, 3);
            this.TrueRadioButton.Name = "TrueRadioButton";
            this.TrueRadioButton.Size = new System.Drawing.Size(49, 19);
            this.TrueRadioButton.TabIndex = 0;
            this.TrueRadioButton.TabStop = true;
            this.TrueRadioButton.Text = "True";
            this.TrueRadioButton.UseVisualStyleBackColor = true;
            // 
            // FalseRadioButton
            // 
            this.FalseRadioButton.AutoSize = true;
            this.FalseRadioButton.Location = new System.Drawing.Point(58, 3);
            this.FalseRadioButton.Name = "FalseRadioButton";
            this.FalseRadioButton.Size = new System.Drawing.Size(51, 19);
            this.FalseRadioButton.TabIndex = 1;
            this.FalseRadioButton.TabStop = true;
            this.FalseRadioButton.Text = "False";
            this.FalseRadioButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(343, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Is Active:";
            // 
            // ProtocolTypeTextBox
            // 
            this.ProtocolTypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProtocolTypeTextBox.Location = new System.Drawing.Point(477, 37);
            this.ProtocolTypeTextBox.Name = "ProtocolTypeTextBox";
            this.ProtocolTypeTextBox.Size = new System.Drawing.Size(195, 23);
            this.ProtocolTypeTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(343, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Protocol Type:";
            // 
            // RevisedNumberTextBox
            // 
            this.RevisedNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RevisedNumberTextBox.Location = new System.Drawing.Point(477, 8);
            this.RevisedNumberTextBox.Name = "RevisedNumberTextBox";
            this.RevisedNumberTextBox.Size = new System.Drawing.Size(195, 23);
            this.RevisedNumberTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Revised Number: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Protocol Number:";
            // 
            // ProtocolNumberTextBox
            // 
            this.ProtocolNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProtocolNumberTextBox.Location = new System.Drawing.Point(142, 8);
            this.ProtocolNumberTextBox.Name = "ProtocolNumberTextBox";
            this.ProtocolNumberTextBox.Size = new System.Drawing.Size(195, 23);
            this.ProtocolNumberTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Year Number:";
            // 
            // YearNumberTextBox
            // 
            this.YearNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.YearNumberTextBox.Location = new System.Drawing.Point(142, 37);
            this.YearNumberTextBox.Name = "YearNumberTextBox";
            this.YearNumberTextBox.Size = new System.Drawing.Size(195, 23);
            this.YearNumberTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sequence Number:";
            // 
            // SequenceNumberTextBox
            // 
            this.SequenceNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SequenceNumberTextBox.Location = new System.Drawing.Point(142, 66);
            this.SequenceNumberTextBox.Name = "SequenceNumberTextBox";
            this.SequenceNumberTextBox.Size = new System.Drawing.Size(195, 23);
            this.SequenceNumberTextBox.TabIndex = 5;
            // 
            // ProtocolNumberUpdateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(680, 155);
            this.Name = "ProtocolNumberUpdateView";
            this.Size = new System.Drawing.Size(680, 155);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.TrueFalseRadioButtonGroup.ResumeLayout(false);
            this.TrueFalseRadioButtonGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox RequestIDTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox TemplateIDTextBox;
        private System.Windows.Forms.ToolStripButton SearchButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ProtocolNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox YearNumberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SequenceNumberTextBox;
        private System.Windows.Forms.TextBox RevisedNumberTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ProtocolTypeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel TrueFalseRadioButtonGroup;
        private System.Windows.Forms.RadioButton TrueRadioButton;
        private System.Windows.Forms.RadioButton FalseRadioButton;
        private System.Windows.Forms.ToolStripButton UpdateButton;
    }
}
