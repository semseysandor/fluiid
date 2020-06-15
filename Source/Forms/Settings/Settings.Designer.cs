namespace Fluiid.Source.Forms.Settings
{
  partial class Settings
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
      this.ports = new System.Windows.Forms.ComboBox();
      this.logging = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.close = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // ports
      // 
      this.ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ports.FormattingEnabled = true;
      this.ports.Location = new System.Drawing.Point(88, 6);
      this.ports.Name = "ports";
      this.ports.Size = new System.Drawing.Size(78, 21);
      this.ports.TabIndex = 0;
      // 
      // logging
      // 
      this.logging.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.logging.FormattingEnabled = true;
      this.logging.Location = new System.Drawing.Point(88, 43);
      this.logging.Name = "logging";
      this.logging.Size = new System.Drawing.Size(78, 21);
      this.logging.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(53, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "COM Port";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 46);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(70, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Logging level";
      // 
      // close
      // 
      this.close.Location = new System.Drawing.Point(41, 70);
      this.close.Name = "close";
      this.close.Size = new System.Drawing.Size(94, 39);
      this.close.TabIndex = 4;
      this.close.Text = "Close";
      this.close.UseVisualStyleBackColor = true;
      // 
      // Settings
      // 
      this.AcceptButton = this.close;
      this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(180, 119);
      this.Controls.Add(this.close);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.logging);
      this.Controls.Add(this.ports);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Settings";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Settings";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox ports;
    private System.Windows.Forms.ComboBox logging;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button close;
  }
}