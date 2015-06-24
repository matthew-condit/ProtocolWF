namespace Toxikon.ProtocolManager.Views.Protocols
{
    partial class ProtocolEventAddView
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
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.EventTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ProtocolEventsListBox = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SubmitButton = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Protocol Event Type: ";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.EventTypeComboBox);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(367, 35);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // EventTypeComboBox
            // 
            this.EventTypeComboBox.FormattingEnabled = true;
            this.EventTypeComboBox.Location = new System.Drawing.Point(140, 3);
            this.EventTypeComboBox.Name = "EventTypeComboBox";
            this.EventTypeComboBox.Size = new System.Drawing.Size(195, 25);
            this.EventTypeComboBox.TabIndex = 1;
            this.EventTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.EventTypeComboBox_SelectedIndexChanged);
            // 
            // ProtocolEventsListBox
            // 
            this.ProtocolEventsListBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProtocolEventsListBox.FormattingEnabled = true;
            this.ProtocolEventsListBox.ItemHeight = 17;
            this.ProtocolEventsListBox.Location = new System.Drawing.Point(0, 55);
            this.ProtocolEventsListBox.Name = "ProtocolEventsListBox";
            this.ProtocolEventsListBox.Size = new System.Drawing.Size(367, 191);
            this.ProtocolEventsListBox.TabIndex = 2;
            this.ProtocolEventsListBox.SelectedIndexChanged += new System.EventHandler(this.ProtocolEventsListBox_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubmitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 258);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(367, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SubmitButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitButton.Image = global::Toxikon.ProtocolManager.Properties.Resources.StatusAnnotations_Complete_and_ok_16xLG_color;
            this.SubmitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(68, 22);
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // ProtocolEventAddView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 283);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ProtocolEventsListBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ProtocolEventAddView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Protocol Event";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProtocolEventAddView_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox EventTypeComboBox;
        private System.Windows.Forms.ListBox ProtocolEventsListBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SubmitButton;
    }
}