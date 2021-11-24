namespace DXApplication2.Win {
    partial class XafSplashScreen
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XafSplashScreen));
      this.ımageSlider1 = new DevExpress.XtraEditors.Controls.ImageSlider();
      ((System.ComponentModel.ISupportInitialize)(this.ımageSlider1)).BeginInit();
      this.SuspendLayout();
      // 
      // ımageSlider1
      // 
      this.ımageSlider1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.ımageSlider1.CurrentImageIndex = 0;
      this.ımageSlider1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ımageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider1.Images"))));
      this.ımageSlider1.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.MiddleRight;
      this.ımageSlider1.Location = new System.Drawing.Point(1, 1);
      this.ımageSlider1.Name = "ımageSlider1";
      this.ımageSlider1.Size = new System.Drawing.Size(591, 663);
      this.ımageSlider1.TabIndex = 0;
      this.ımageSlider1.Text = "ımageSlider1";
      this.ımageSlider1.Click += new System.EventHandler(this.ImageSlider1_Click);
      // 
      // XafSplashScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(593, 665);
      this.Controls.Add(this.ımageSlider1);
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "XafSplashScreen";
      this.Padding = new System.Windows.Forms.Padding(1);
      this.SplashImage = global::DXApplication2.Win.Properties.Resources._1MM_sisteme_bağlan;
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.ımageSlider1)).EndInit();
      this.ResumeLayout(false);

        }

    #endregion

    private DevExpress.XtraEditors.Controls.ImageSlider ımageSlider1;
  }
}
