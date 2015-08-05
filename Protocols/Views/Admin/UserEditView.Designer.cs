namespace Toxikon.ProtocolManager.Views.Admin
{
    partial class UserEditView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserEditView));
            this.SearchToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.SearchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.SearchButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SubmitButton = new System.Windows.Forms.ToolStripButton();
            this.MainContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.FullNameTextBox = new System.Windows.Forms.TextBox();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.IsActiveRadioButtonGroup = new System.Windows.Forms.FlowLayoutPanel();
            this.TrueRadioButton = new System.Windows.Forms.RadioButton();
            this.FalseRadioButton = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DepartmentComboBox = new System.Windows.Forms.ComboBox();
            this.RoleComboBox = new System.Windows.Forms.ComboBox();
            this.SearchToolStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.Panel2.SuspendLayout();
            this.MainContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.IsActiveRadioButtonGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchToolStrip
            // 
            this.SearchToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.SearchTextBox,
            this.SearchButton});
            this.SearchToolStrip.Location = new System.Drawing.Point(0, 0);
            this.SearchToolStrip.Name = "SearchToolStrip";
            this.SearchToolStrip.Padding = new System.Windows.Forms.Padding(0, 4, 1, 4);
            this.SearchToolStrip.Size = new System.Drawing.Size(714, 31);
            this.SearchToolStrip.TabIndex = 5;
            this.SearchToolStrip.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(90, 20);
            this.toolStripLabel1.Text = "TMS Username:";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(200, 23);
            this.SearchTextBox.ToolTipText = "Enter TMS username";
            // 
            // SearchButton
            // 
            this.SearchButton.Image = ((System.Drawing.Image)(resources.GetObject("SearchButton.Image")));
            this.SearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(62, 20);
            this.SearchButton.Text = "Search";
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubmitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 202);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(714, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SubmitButton.Image = ((System.Drawing.Image)(resources.GetObject("SubmitButton.Image")));
            this.SubmitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(65, 22);
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // MainContainer
            // 
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.IsSplitterFixed = true;
            this.MainContainer.Location = new System.Drawing.Point(0, 31);
            this.MainContainer.Name = "MainContainer";
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.MainContainer.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // MainContainer.Panel2
            // 
            this.MainContainer.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.MainContainer.Size = new System.Drawing.Size(714, 171);
            this.MainContainer.SplitterDistance = 414;
            this.MainContainer.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.30713F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.69287F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.EmailTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.FirstNameTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.LastNameTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.FullNameTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.UserNameTextBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(408, 165);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Email Address: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "First Name:";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmailTextBox.Location = new System.Drawing.Point(106, 135);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(299, 23);
            this.EmailTextBox.TabIndex = 5;
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstNameTextBox.Location = new System.Drawing.Point(106, 36);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(299, 23);
            this.FirstNameTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last Name: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Full Name:";
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LastNameTextBox.Location = new System.Drawing.Point(106, 69);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(299, 23);
            this.LastNameTextBox.TabIndex = 3;
            // 
            // FullNameTextBox
            // 
            this.FullNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FullNameTextBox.Location = new System.Drawing.Point(106, 102);
            this.FullNameTextBox.Name = "FullNameTextBox";
            this.FullNameTextBox.Size = new System.Drawing.Size(299, 23);
            this.FullNameTextBox.TabIndex = 4;
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(106, 3);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(299, 23);
            this.UserNameTextBox.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.27599F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.72401F));
            this.tableLayoutPanel2.Controls.Add(this.IsActiveRadioButtonGroup, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.DepartmentComboBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.RoleComboBox, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(281, 101);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // IsActiveRadioButtonGroup
            // 
            this.IsActiveRadioButtonGroup.Controls.Add(this.TrueRadioButton);
            this.IsActiveRadioButtonGroup.Controls.Add(this.FalseRadioButton);
            this.IsActiveRadioButtonGroup.Location = new System.Drawing.Point(108, 68);
            this.IsActiveRadioButtonGroup.Name = "IsActiveRadioButtonGroup";
            this.IsActiveRadioButtonGroup.Size = new System.Drawing.Size(167, 27);
            this.IsActiveRadioButtonGroup.TabIndex = 7;
            // 
            // TrueRadioButton
            // 
            this.TrueRadioButton.AutoSize = true;
            this.TrueRadioButton.Location = new System.Drawing.Point(3, 3);
            this.TrueRadioButton.Name = "TrueRadioButton";
            this.TrueRadioButton.Size = new System.Drawing.Size(49, 19);
            this.TrueRadioButton.TabIndex = 8;
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
            this.FalseRadioButton.TabIndex = 9;
            this.FalseRadioButton.TabStop = true;
            this.FalseRadioButton.Text = "False";
            this.FalseRadioButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Department:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Role:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Active:";
            // 
            // DepartmentComboBox
            // 
            this.DepartmentComboBox.DisplayMember = "DepartmentName";
            this.DepartmentComboBox.FormattingEnabled = true;
            this.DepartmentComboBox.ItemHeight = 15;
            this.DepartmentComboBox.Location = new System.Drawing.Point(108, 6);
            this.DepartmentComboBox.Name = "DepartmentComboBox";
            this.DepartmentComboBox.Size = new System.Drawing.Size(167, 23);
            this.DepartmentComboBox.TabIndex = 6;
            // 
            // RoleComboBox
            // 
            this.RoleComboBox.DisplayMember = "RoleName";
            this.RoleComboBox.FormattingEnabled = true;
            this.RoleComboBox.Location = new System.Drawing.Point(108, 37);
            this.RoleComboBox.Name = "RoleComboBox";
            this.RoleComboBox.Size = new System.Drawing.Size(167, 23);
            this.RoleComboBox.TabIndex = 7;
            // 
            // UserEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 227);
            this.Controls.Add(this.MainContainer);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.SearchToolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserEditView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User";
            this.SearchToolStrip.ResumeLayout(false);
            this.SearchToolStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.IsActiveRadioButtonGroup.ResumeLayout(false);
            this.IsActiveRadioButtonGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip SearchToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox SearchTextBox;
        private System.Windows.Forms.ToolStripButton SearchButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SubmitButton;
        private System.Windows.Forms.SplitContainer MainContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.TextBox FullNameTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel IsActiveRadioButtonGroup;
        private System.Windows.Forms.RadioButton TrueRadioButton;
        private System.Windows.Forms.RadioButton FalseRadioButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox DepartmentComboBox;
        private System.Windows.Forms.ComboBox RoleComboBox;
        private System.Windows.Forms.TextBox UserNameTextBox;
    }
}