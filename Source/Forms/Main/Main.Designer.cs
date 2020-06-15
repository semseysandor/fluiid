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
      this.Label1 = new System.Windows.Forms.Label();
      this.TextConnection = new System.Windows.Forms.Label();
      this.ButtonDisconnect = new System.Windows.Forms.Button();
      this.ButtonConnect = new System.Windows.Forms.Button();
      this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
      this.Settings = new System.Windows.Forms.ToolStripMenuItem();
      this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ButtonSend = new System.Windows.Forms.Button();
      this.TextBoxCmd = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.MenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // ButtonWash
      // 
      this.ButtonWash.Location = new System.Drawing.Point(249, 59);
      this.ButtonWash.Name = "ButtonWash";
      this.ButtonWash.Size = new System.Drawing.Size(74, 24);
      this.ButtonWash.TabIndex = 13;
      this.ButtonWash.Text = "Wash";
      this.ButtonWash.UseVisualStyleBackColor = true;
      this.ButtonWash.Visible = false;
      // 
      // ButtonInit
      // 
      this.ButtonInit.Location = new System.Drawing.Point(249, 29);
      this.ButtonInit.Name = "ButtonInit";
      this.ButtonInit.Size = new System.Drawing.Size(74, 24);
      this.ButtonInit.TabIndex = 12;
      this.ButtonInit.Text = "Init";
      this.ButtonInit.UseVisualStyleBackColor = true;
      this.ButtonInit.Visible = false;
      // 
      // Label1
      // 
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(10, 35);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(44, 13);
      this.Label1.TabIndex = 11;
      this.Label1.Text = "Device:";
      // 
      // TextConnection
      // 
      this.TextConnection.AutoSize = true;
      this.TextConnection.Location = new System.Drawing.Point(10, 59);
      this.TextConnection.Name = "TextConnection";
      this.TextConnection.Size = new System.Drawing.Size(73, 13);
      this.TextConnection.TabIndex = 10;
      this.TextConnection.Text = "Disconnected";
      // 
      // ButtonDisconnect
      // 
      this.ButtonDisconnect.Location = new System.Drawing.Point(112, 59);
      this.ButtonDisconnect.Name = "ButtonDisconnect";
      this.ButtonDisconnect.Size = new System.Drawing.Size(87, 24);
      this.ButtonDisconnect.TabIndex = 9;
      this.ButtonDisconnect.Text = "Disconnect";
      this.ButtonDisconnect.UseVisualStyleBackColor = true;
      this.ButtonDisconnect.Visible = false;
      // 
      // ButtonConnect
      // 
      this.ButtonConnect.Location = new System.Drawing.Point(112, 29);
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
            this.AboutToolStripMenuItem});
      this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
      this.MenuStrip1.Name = "MenuStrip1";
      this.MenuStrip1.Size = new System.Drawing.Size(337, 24);
      this.MenuStrip1.TabIndex = 14;
      this.MenuStrip1.Text = "MenuStrip1";
      // 
      // Settings
      // 
      this.Settings.Name = "Settings";
      this.Settings.Size = new System.Drawing.Size(61, 20);
      this.Settings.Text = "Settings";
      // 
      // AboutToolStripMenuItem
      // 
      this.AboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
      this.AboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
      this.AboutToolStripMenuItem.Text = "About";
      // 
      // ButtonSend
      // 
      this.ButtonSend.Location = new System.Drawing.Point(234, 110);
      this.ButtonSend.Name = "ButtonSend";
      this.ButtonSend.Size = new System.Drawing.Size(89, 36);
      this.ButtonSend.TabIndex = 16;
      this.ButtonSend.Text = "SEND CMD";
      this.ButtonSend.UseVisualStyleBackColor = true;
      this.ButtonSend.Visible = false;
      // 
      // TextBoxCmd
      // 
      this.TextBoxCmd.Location = new System.Drawing.Point(112, 119);
      this.TextBoxCmd.Name = "TextBoxCmd";
      this.TextBoxCmd.Size = new System.Drawing.Size(116, 20);
      this.TextBoxCmd.TabIndex = 15;
      this.TextBoxCmd.Visible = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 122);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(78, 13);
      this.label2.TabIndex = 17;
      this.label2.Text = "Raw command";
      // 
      // Main
      // 
      this.AcceptButton = this.ButtonSend;
      this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(337, 162);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.ButtonSend);
      this.Controls.Add(this.TextBoxCmd);
      this.Controls.Add(this.MenuStrip1);
      this.Controls.Add(this.ButtonWash);
      this.Controls.Add(this.ButtonInit);
      this.Controls.Add(this.Label1);
      this.Controls.Add(this.TextConnection);
      this.Controls.Add(this.ButtonDisconnect);
      this.Controls.Add(this.ButtonConnect);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Main";
      this.Text = "Main";
      this.MenuStrip1.ResumeLayout(false);
      this.MenuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button ButtonWash;
		internal System.Windows.Forms.Button ButtonInit;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label TextConnection;
		internal System.Windows.Forms.Button ButtonDisconnect;
		internal System.Windows.Forms.Button ButtonConnect;
		internal System.Windows.Forms.MenuStrip MenuStrip1;
		internal System.Windows.Forms.ToolStripMenuItem Settings;
		internal System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
		internal System.Windows.Forms.Button ButtonSend;
		internal System.Windows.Forms.TextBox TextBoxCmd;
    private System.Windows.Forms.Label label2;
  }
}