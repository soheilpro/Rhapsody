using System;

namespace Rhapsody.UI {
    partial class IssuesForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssuesForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvwIssues = new System.Windows.Forms.ListView();
            this.chItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chItemValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIssue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFix = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilsIcons = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(667, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnContinue.Location = new System.Drawing.Point(586, 305);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 25);
            this.btnContinue.TabIndex = 2;
            this.btnContinue.Text = "Con&tinue";
            this.btnContinue.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(164, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "The following issues were found:\r\n";
            // 
            // lvwIssues
            // 
            this.lvwIssues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwIssues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chItem,
            this.chItemValue,
            this.chIssue,
            this.chFix});
            this.lvwIssues.FullRowSelect = true;
            this.lvwIssues.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwIssues.Location = new System.Drawing.Point(12, 52);
            this.lvwIssues.Name = "lvwIssues";
            this.lvwIssues.ShowItemToolTips = true;
            this.lvwIssues.Size = new System.Drawing.Size(730, 243);
            this.lvwIssues.SmallImageList = this.ilsIcons;
            this.lvwIssues.TabIndex = 1;
            this.lvwIssues.UseCompatibleStateImageBehavior = false;
            this.lvwIssues.View = System.Windows.Forms.View.Details;
            this.lvwIssues.Click += new System.EventHandler(this.lvwIssues_Click);
            this.lvwIssues.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvwIssues_MouseMove);
            // 
            // chItem
            // 
            this.chItem.Text = "Item";
            this.chItem.Width = 101;
            // 
            // chItemValue
            // 
            this.chItemValue.Text = "Value";
            this.chItemValue.Width = 275;
            // 
            // chIssue
            // 
            this.chIssue.Text = "Issue";
            this.chIssue.Width = 275;
            // 
            // chFix
            // 
            this.chFix.Text = "Fix";
            this.chFix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chFix.Width = 50;
            // 
            // ilsIcons
            // 
            this.ilsIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilsIcons.ImageStream")));
            this.ilsIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilsIcons.Images.SetKeyName(0, "Warning.png");
            this.ilsIcons.Images.SetKeyName(1, "Error.png");
            // 
            // IssuesForm
            // 
            this.AcceptButton = this.btnContinue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(754, 342);
            this.Controls.Add(this.lvwIssues);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssuesForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Issues";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwIssues;
        private System.Windows.Forms.ColumnHeader chIssue;
        private System.Windows.Forms.ImageList ilsIcons;
        private System.Windows.Forms.ColumnHeader chFix;
        private System.Windows.Forms.ColumnHeader chItem;
        private System.Windows.Forms.ColumnHeader chItemValue;
    }
}