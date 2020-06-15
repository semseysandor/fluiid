namespace Fluiid.Source.Forms
{
  partial class About
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
      this.PictureBox1 = new System.Windows.Forms.PictureBox();
      this.TextInfo = new System.Windows.Forms.Label();
      this.Close = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // PictureBox1
      // 
      this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
      this.PictureBox1.Location = new System.Drawing.Point(12, 12);
      this.PictureBox1.Name = "PictureBox1";
      this.PictureBox1.Size = new System.Drawing.Size(172, 175);
      this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.PictureBox1.TabIndex = 1;
      this.PictureBox1.TabStop = false;
      // 
      // TextInfo
      // 
      this.TextInfo.AutoSize = true;
      this.TextInfo.Location = new System.Drawing.Point(234, 23);
      this.TextInfo.Name = "TextInfo";
      this.TextInfo.Size = new System.Drawing.Size(24, 13);
      this.TextInfo.TabIndex = 2;
      this.TextInfo.Text = "info";
      // 
      // Close
      // 
      this.Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close.Location = new System.Drawing.Point(237, 147);
      this.Close.Name = "Close";
      this.Close.Size = new System.Drawing.Size(82, 32);
      this.Close.TabIndex = 3;
      this.Close.Text = "Cool!";
      this.Close.UseVisualStyleBackColor = true;
      // 
      // About
      // 
      this.AcceptButton = this.Close;
      this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
      this.AllowDrop = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(342, 204);
      this.Controls.Add(this.Close);
      this.Controls.Add(this.TextInfo);
      this.Controls.Add(this.PictureBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "About";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "About";
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    internal System.Windows.Forms.PictureBox PictureBox1;
    internal System.Windows.Forms.Label TextInfo;
    internal System.Windows.Forms.Button Close;
  }
}