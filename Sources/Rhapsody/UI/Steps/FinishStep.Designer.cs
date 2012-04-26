using System;

namespace Rhapsody.UI.Steps
{
    partial class FinishStep
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinishStep));
            this.lblFinished = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnExplore = new System.Windows.Forms.Button();
            this.picAlbum = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAlbum)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFinished
            // 
            this.lblFinished.AutoSize = true;
            this.lblFinished.Location = new System.Drawing.Point(341, 104);
            this.lblFinished.Name = "lblFinished";
            this.lblFinished.Size = new System.Drawing.Size(290, 39);
            this.lblFinished.TabIndex = 0;
            this.lblFinished.Text = "Done.\r\n\r\nYou may browse the album directory or play it playlist now.";
            // 
            // btnPlay
            // 
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlay.Location = new System.Drawing.Point(344, 225);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Padding = new System.Windows.Forms.Padding(0, 0, 23, 0);
            this.btnPlay.Size = new System.Drawing.Size(80, 25);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "Play";
            this.btnPlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnExplore
            // 
            this.btnExplore.Image = ((System.Drawing.Image)(resources.GetObject("btnExplore.Image")));
            this.btnExplore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExplore.Location = new System.Drawing.Point(344, 194);
            this.btnExplore.Name = "btnExplore";
            this.btnExplore.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.btnExplore.Size = new System.Drawing.Size(80, 25);
            this.btnExplore.TabIndex = 1;
            this.btnExplore.Text = "Explore";
            this.btnExplore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExplore.UseVisualStyleBackColor = true;
            this.btnExplore.Click += new System.EventHandler(this.btnExplore_Click);
            // 
            // picAlbum
            // 
            this.picAlbum.Image = ((System.Drawing.Image)(resources.GetObject("picAlbum.Image")));
            this.picAlbum.Location = new System.Drawing.Point(57, 57);
            this.picAlbum.Name = "picAlbum";
            this.picAlbum.Size = new System.Drawing.Size(256, 256);
            this.picAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picAlbum.TabIndex = 6;
            this.picAlbum.TabStop = false;
            // 
            // FinishStep
            // 
            this.Controls.Add(this.lblFinished);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnExplore);
            this.Controls.Add(this.picAlbum);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FinishStep";
            this.Size = new System.Drawing.Size(772, 482);
            ((System.ComponentModel.ISupportInitialize)(this.picAlbum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFinished;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnExplore;
        private System.Windows.Forms.PictureBox picAlbum;
    }
}
