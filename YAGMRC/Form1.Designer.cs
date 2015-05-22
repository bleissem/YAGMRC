namespace YAGMRC
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ExitButton = new System.Windows.Forms.Button();
            this.AllGamesListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MyTurnListBox = new System.Windows.Forms.ListBox();
            this.MyTurnLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.LoggedInCheckBox = new System.Windows.Forms.CheckBox();
            this.PleaseWaitPictureBox = new System.Windows.Forms.PictureBox();
            this.Statuslabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.multiplayerrobotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PleaseWaitPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(314, 379);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(92, 23);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // AllGamesListBox
            // 
            this.AllGamesListBox.DisplayMember = "DisplayValue";
            this.AllGamesListBox.FormattingEnabled = true;
            this.AllGamesListBox.Location = new System.Drawing.Point(16, 97);
            this.AllGamesListBox.Name = "AllGamesListBox";
            this.AllGamesListBox.Size = new System.Drawing.Size(167, 251);
            this.AllGamesListBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "All games";
            // 
            // MyTurnListBox
            // 
            this.MyTurnListBox.DisplayMember = "DisplayValue";
            this.MyTurnListBox.FormattingEnabled = true;
            this.MyTurnListBox.Location = new System.Drawing.Point(217, 97);
            this.MyTurnListBox.Name = "MyTurnListBox";
            this.MyTurnListBox.Size = new System.Drawing.Size(181, 251);
            this.MyTurnListBox.TabIndex = 3;
            this.MyTurnListBox.DoubleClick += new System.EventHandler(this.MyTurnListBox_DoubleClick);
            // 
            // MyTurnLabel
            // 
            this.MyTurnLabel.AutoSize = true;
            this.MyTurnLabel.Location = new System.Drawing.Point(214, 69);
            this.MyTurnLabel.Name = "MyTurnLabel";
            this.MyTurnLabel.Size = new System.Drawing.Size(147, 13);
            this.MyTurnLabel.TabIndex = 5;
            this.MyTurnLabel.Text = "my Turn - double Click to Play";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(217, 12);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 6;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LoggedInCheckBox
            // 
            this.LoggedInCheckBox.AutoSize = true;
            this.LoggedInCheckBox.Enabled = false;
            this.LoggedInCheckBox.Location = new System.Drawing.Point(299, 17);
            this.LoggedInCheckBox.Name = "LoggedInCheckBox";
            this.LoggedInCheckBox.Size = new System.Drawing.Size(15, 14);
            this.LoggedInCheckBox.TabIndex = 7;
            this.LoggedInCheckBox.UseVisualStyleBackColor = true;
            // 
            // PleaseWaitPictureBox
            // 
            this.PleaseWaitPictureBox.Image = global::YAGMRC.Properties.Resources.pleasewait;
            this.PleaseWaitPictureBox.Location = new System.Drawing.Point(85, 378);
            this.PleaseWaitPictureBox.Name = "PleaseWaitPictureBox";
            this.PleaseWaitPictureBox.Size = new System.Drawing.Size(223, 24);
            this.PleaseWaitPictureBox.TabIndex = 8;
            this.PleaseWaitPictureBox.TabStop = false;
            this.PleaseWaitPictureBox.Visible = false;
            // 
            // Statuslabel
            // 
            this.Statuslabel.AutoSize = true;
            this.Statuslabel.Location = new System.Drawing.Point(87, 357);
            this.Statuslabel.Name = "Statuslabel";
            this.Statuslabel.Size = new System.Drawing.Size(0, 13);
            this.Statuslabel.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(413, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem,
            this.createGameToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.googleToolStripMenuItem1,
            this.multiplayerrobotToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingToolStripMenuItem.Text = "Settings";
            // 
            // googleToolStripMenuItem1
            // 
            this.googleToolStripMenuItem1.Name = "googleToolStripMenuItem1";
            this.googleToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.googleToolStripMenuItem1.Text = "Google";
            // 
            // multiplayerrobotToolStripMenuItem
            // 
            this.multiplayerrobotToolStripMenuItem.Name = "multiplayerrobotToolStripMenuItem";
            this.multiplayerrobotToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.multiplayerrobotToolStripMenuItem.Text = "Multiplayerrobot";
            this.multiplayerrobotToolStripMenuItem.Click += new System.EventHandler(this.multiplayerrobotToolStripMenuItem_Click);
            // 
            // createGameToolStripMenuItem
            // 
            this.createGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.googleToolStripMenuItem});
            this.createGameToolStripMenuItem.Name = "createGameToolStripMenuItem";
            this.createGameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createGameToolStripMenuItem.Text = "Create Game";
            // 
            // googleToolStripMenuItem
            // 
            this.googleToolStripMenuItem.Name = "googleToolStripMenuItem";
            this.googleToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.googleToolStripMenuItem.Text = "Google";
            this.googleToolStripMenuItem.Click += new System.EventHandler(this.googleToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(413, 414);
            this.Controls.Add(this.Statuslabel);
            this.Controls.Add(this.PleaseWaitPictureBox);
            this.Controls.Add(this.LoggedInCheckBox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.MyTurnLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MyTurnListBox);
            this.Controls.Add(this.AllGamesListBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YAGMRC";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PleaseWaitPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ListBox AllGamesListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox MyTurnListBox;
        private System.Windows.Forms.Label MyTurnLabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.CheckBox LoggedInCheckBox;
        private System.Windows.Forms.PictureBox PleaseWaitPictureBox;
        private System.Windows.Forms.Label Statuslabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem multiplayerrobotToolStripMenuItem;
    }
}

