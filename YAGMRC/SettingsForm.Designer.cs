namespace YAGMRC
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.CloseButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.GMRTabPage = new System.Windows.Forms.TabPage();
            this.GoogleTabPage = new System.Windows.Forms.TabPage();
            this.ArchiveGameFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.AuthKeyTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddGoogleStorageButton = new System.Windows.Forms.Button();
            this.GoogleStorageListBox = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.GMRTabPage.SuspendLayout();
            this.GoogleTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(12, 310);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.GMRTabPage);
            this.tabControl1.Controls.Add(this.GoogleTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(562, 275);
            this.tabControl1.TabIndex = 8;
            // 
            // GMRTabPage
            // 
            this.GMRTabPage.Controls.Add(this.ArchiveGameFilesCheckBox);
            this.GMRTabPage.Controls.Add(this.AuthKeyTextBox);
            this.GMRTabPage.Controls.Add(this.label1);
            this.GMRTabPage.Location = new System.Drawing.Point(4, 22);
            this.GMRTabPage.Name = "GMRTabPage";
            this.GMRTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GMRTabPage.Size = new System.Drawing.Size(554, 170);
            this.GMRTabPage.TabIndex = 0;
            this.GMRTabPage.Text = "Giant Multiplayer Robot";
            this.GMRTabPage.UseVisualStyleBackColor = true;
            // 
            // GoogleTabPage
            // 
            this.GoogleTabPage.Controls.Add(this.AddGoogleStorageButton);
            this.GoogleTabPage.Controls.Add(this.GoogleStorageListBox);
            this.GoogleTabPage.Controls.Add(this.textBox1);
            this.GoogleTabPage.Location = new System.Drawing.Point(4, 22);
            this.GoogleTabPage.Name = "GoogleTabPage";
            this.GoogleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GoogleTabPage.Size = new System.Drawing.Size(554, 249);
            this.GoogleTabPage.TabIndex = 1;
            this.GoogleTabPage.Text = "Google Storage";
            this.GoogleTabPage.UseVisualStyleBackColor = true;
            // 
            // ArchiveGameFilesCheckBox
            // 
            this.ArchiveGameFilesCheckBox.AutoSize = true;
            this.ArchiveGameFilesCheckBox.Location = new System.Drawing.Point(9, 35);
            this.ArchiveGameFilesCheckBox.Name = "ArchiveGameFilesCheckBox";
            this.ArchiveGameFilesCheckBox.Size = new System.Drawing.Size(126, 17);
            this.ArchiveGameFilesCheckBox.TabIndex = 5;
            this.ArchiveGameFilesCheckBox.Text = "do archive game files";
            this.ArchiveGameFilesCheckBox.UseVisualStyleBackColor = true;
            // 
            // AuthKeyTextBox
            // 
            this.AuthKeyTextBox.Location = new System.Drawing.Point(59, 9);
            this.AuthKeyTextBox.Name = "AuthKeyTextBox";
            this.AuthKeyTextBox.Size = new System.Drawing.Size(100, 20);
            this.AuthKeyTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "AuthKey";
            // 
            // AddGoogleStorageButton
            // 
            this.AddGoogleStorageButton.Location = new System.Drawing.Point(112, 7);
            this.AddGoogleStorageButton.Name = "AddGoogleStorageButton";
            this.AddGoogleStorageButton.Size = new System.Drawing.Size(125, 23);
            this.AddGoogleStorageButton.TabIndex = 12;
            this.AddGoogleStorageButton.Text = "Add Google Storage";
            this.AddGoogleStorageButton.UseVisualStyleBackColor = true;
            // 
            // GoogleStorageListBox
            // 
            this.GoogleStorageListBox.FormattingEnabled = true;
            this.GoogleStorageListBox.Location = new System.Drawing.Point(6, 53);
            this.GoogleStorageListBox.Name = "GoogleStorageListBox";
            this.GoogleStorageListBox.Size = new System.Drawing.Size(231, 147);
            this.GoogleStorageListBox.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 10;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 345);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.CloseButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.tabControl1.ResumeLayout(false);
            this.GMRTabPage.ResumeLayout(false);
            this.GMRTabPage.PerformLayout();
            this.GoogleTabPage.ResumeLayout(false);
            this.GoogleTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage GMRTabPage;
        public System.Windows.Forms.CheckBox ArchiveGameFilesCheckBox;
        public System.Windows.Forms.TextBox AuthKeyTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage GoogleTabPage;
        private System.Windows.Forms.Button AddGoogleStorageButton;
        private System.Windows.Forms.ListBox GoogleStorageListBox;
        public System.Windows.Forms.TextBox textBox1;
    }
}