namespace EchoSystems.Administration.Views
{
    partial class SplashScreen
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
            this.bwSplash = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // bwSplash
            // 
            this.bwSplash.WorkerReportsProgress = true;
            this.bwSplash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSplash_DoWork);
            this.bwSplash.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwSplash_ProgressChanged);
            this.bwSplash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSplash_RunWorkerCompleted);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EchoSystems.Administration.Properties.Resources.Logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(367, 347);
            this.DoubleBuffered = true;
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bwSplash;
    }
}