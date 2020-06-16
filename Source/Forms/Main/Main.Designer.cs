namespace Fluiid.Source.Forms
{
	partial class Main
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
      this.ButtonWash = new System.Windows.Forms.Button();
      this.ButtonInit = new System.Windows.Forms.Button();
      this.ButtonDisconnect = new System.Windows.Forms.Button();
      this.ButtonConnect = new System.Windows.Forms.Button();
      this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
      this.Settings = new System.Windows.Forms.ToolStripMenuItem();
      this.AboutBtn = new System.Windows.Forms.ToolStripMenuItem();
      this.ButtonSend = new System.Windows.Forms.Button();
      this.TextBoxCmd = new System.Windows.Forms.TextBox();
      this.sendGroupBox = new System.Windows.Forms.GroupBox();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.MenuStrip1.SuspendLayout();
      this.sendGroupBox.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // ButtonWash
      // 
      this.ButtonWash.Location = new System.Drawing.Point(186, 29);
      this.ButtonWash.Name = "ButtonWash";
      this.ButtonWash.Size = new System.Drawing.Size(74, 24);
      this.ButtonWash.TabIndex = 13;
      this.ButtonWash.Text = "Wash";
      this.ButtonWash.UseVisualStyleBackColor = true;
      this.ButtonWash.Visible = false;
      // 
      // ButtonInit
      // 
      this.ButtonInit.Location = new System.Drawing.Point(106, 29);
      this.ButtonInit.Name = "ButtonInit";
      this.ButtonInit.Size = new System.Drawing.Size(74, 24);
      this.ButtonInit.TabIndex = 12;
      this.ButtonInit.Text = "Init";
      this.ButtonInit.UseVisualStyleBackColor = true;
      this.ButtonInit.Visible = false;
      // 
      // ButtonDisconnect
      // 
      this.ButtonDisconnect.Location = new System.Drawing.Point(13, 29);
      this.ButtonDisconnect.Name = "ButtonDisconnect";
      this.ButtonDisconnect.Size = new System.Drawing.Size(87, 24);
      this.ButtonDisconnect.TabIndex = 9;
      this.ButtonDisconnect.Text = "Disconnect";
      this.ButtonDisconnect.UseVisualStyleBackColor = true;
      this.ButtonDisconnect.Visible = false;
      // 
      // ButtonConnect
      // 
      this.ButtonConnect.Location = new System.Drawing.Point(13, 29);
      this.ButtonConnect.Name = "ButtonConnect";
      this.ButtonConnect.Size = new System.Drawing.Size(73, 24);
      this.ButtonConnect.TabIndex = 8;
      this.ButtonConnect.Text = "Connect";
      this.ButtonConnect.UseVisualStyleBackColor = true;
      // 
      // MenuStrip1
      // 
      this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Settings,
            this.AboutBtn});
      this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
      this.MenuStrip1.Name = "MenuStrip1";
      this.MenuStrip1.Size = new System.Drawing.Size(289, 24);
      this.MenuStrip1.TabIndex = 14;
      this.MenuStrip1.Text = "MenuStrip1";
      // 
      // Settings
      // 
      this.Settings.Name = "Settings";
      this.Settings.Size = new System.Drawing.Size(61, 20);
      this.Settings.Text = "Settings";
      // 
      // AboutBtn
      // 
      this.AboutBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.AboutBtn.Name = "AboutBtn";
      this.AboutBtn.Size = new System.Drawing.Size(52, 20);
      this.AboutBtn.Text = "About";
      // 
      // ButtonSend
      // 
      this.ButtonSend.Location = new System.Drawing.Point(128, 14);
      this.ButtonSend.Name = "ButtonSend";
      this.ButtonSend.Size = new System.Drawing.Size(81, 29);
      this.ButtonSend.TabIndex = 16;
      this.ButtonSend.Text = "Send";
      this.ButtonSend.UseVisualStyleBackColor = true;
      this.ButtonSend.Visible = false;
      // 
      // TextBoxCmd
      // 
      this.TextBoxCmd.Location = new System.Drawing.Point(6, 19);
      this.TextBoxCmd.Name = "TextBoxCmd";
      this.TextBoxCmd.Size = new System.Drawing.Size(116, 20);
      this.TextBoxCmd.TabIndex = 15;
      this.TextBoxCmd.Visible = false;
      // 
      // sendGroupBox
      // 
      this.sendGroupBox.Controls.Add(this.ButtonSend);
      this.sendGroupBox.Controls.Add(this.TextBoxCmd);
      this.sendGroupBox.Location = new System.Drawing.Point(13, 79);
      this.sendGroupBox.Name = "sendGroupBox";
      this.sendGroupBox.Size = new System.Drawing.Size(220, 53);
      this.sendGroupBox.TabIndex = 18;
      this.sendGroupBox.TabStop = false;
      this.sendGroupBox.Text = "Send raw command";
      this.sendGroupBox.Visible = false;
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusLabel});
      this.statusStrip1.Location = new System.Drawing.Point(0, 140);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(289, 22);
      this.statusStrip1.TabIndex = 19;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(77, 17);
      this.toolStripStatusLabel1.Text = "Device Status";
      // 
      // statusLabel
      // 
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(79, 17);
      this.statusLabel.Text = "Disconnected";
      // 
      // Main
      // 
      this.AcceptButton = this.ButtonSend;
      this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(289, 162);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.sendGroupBox);
      this.Controls.Add(this.MenuStrip1);
      this.Controls.Add(this.ButtonWash);
      this.Controls.Add(this.ButtonInit);
      this.Controls.Add(this.ButtonDisconnect);
      this.Controls.Add(this.ButtonConnect);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Main";
      this.Text = "Fluiid";
      this.MenuStrip1.ResumeLayout(false);
      this.MenuStrip1.PerformLayout();
      this.sendGroupBox.ResumeLayout(false);
      this.sendGroupBox.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button ButtonWash;
		internal System.Windows.Forms.Button ButtonInit;
		internal System.Windows.Forms.Button ButtonDisconnect;
		internal System.Windows.Forms.Button ButtonConnect;
		internal System.Windows.Forms.MenuStrip MenuStrip1;
		internal System.Windows.Forms.ToolStripMenuItem Settings;
		internal System.Windows.Forms.ToolStripMenuItem AboutBtn;
		internal System.Windows.Forms.Button ButtonSend;
		internal System.Windows.Forms.TextBox TextBoxCmd;
    private System.Windows.Forms.GroupBox sendGroupBox;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripStatusLabel statusLabel;
  }
}