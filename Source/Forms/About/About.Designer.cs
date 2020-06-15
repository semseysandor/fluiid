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
      this.BtnClose = new System.Windows.Forms.Button();
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
      // BtnClose
      // 
      this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.BtnClose.Location = new System.Drawing.Point(237, 147);
      this.BtnClose.Name = "BtnClose";
      this.BtnClose.Size = new System.Drawing.Size(82, 32);
      this.BtnClose.TabIndex = 3;
      this.BtnClose.Text = "Cool!";
      this.BtnClose.UseVisualStyleBackColor = true;
      this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
      // 
      // About
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(342, 204);
      this.Controls.Add(this.BtnClose);
      this.Controls.Add(this.TextInfo);
      this.Controls.Add(this.PictureBox1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "About";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "About";
      this.Load += new System.EventHandler(this.Loader);
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    internal System.Windows.Forms.PictureBox PictureBox1;
    internal System.Windows.Forms.Label TextInfo;
    internal System.Windows.Forms.Button BtnClose;
  }
}