namespace Zip1
{
    partial class MainForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lbDestZip = new System.Windows.Forms.Label();
            this.txtDestZip = new System.Windows.Forms.TextBox();
            this.lbSrcFiles = new System.Windows.Forms.Label();
            this.btnDestZip = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.lvSrcFiles = new System.Windows.Forms.ListView();
            this.colFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemoveFiles = new System.Windows.Forms.Button();
            this.btnZip = new System.Windows.Forms.Button();
            this.chkVerifyZip = new System.Windows.Forms.CheckBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.OverwritePrompt = false;
            // 
            // lbDestZip
            // 
            this.lbDestZip.AutoSize = true;
            this.lbDestZip.Location = new System.Drawing.Point(11, 11);
            this.lbDestZip.Name = "lbDestZip";
            this.lbDestZip.Size = new System.Drawing.Size(79, 12);
            this.lbDestZip.TabIndex = 0;
            this.lbDestZip.Text = "Destination Zip:";
            // 
            // txtDestZip
            // 
            this.txtDestZip.Location = new System.Drawing.Point(11, 25);
            this.txtDestZip.Name = "txtDestZip";
            this.txtDestZip.ReadOnly = true;
            this.txtDestZip.Size = new System.Drawing.Size(600, 22);
            this.txtDestZip.TabIndex = 1;
            // 
            // lbSrcFiles
            // 
            this.lbSrcFiles.AutoSize = true;
            this.lbSrcFiles.Location = new System.Drawing.Point(11, 81);
            this.lbSrcFiles.Name = "lbSrcFiles";
            this.lbSrcFiles.Size = new System.Drawing.Size(64, 12);
            this.lbSrcFiles.TabIndex = 2;
            this.lbSrcFiles.Text = "Source Files:";
            // 
            // btnDestZip
            // 
            this.btnDestZip.Location = new System.Drawing.Point(613, 24);
            this.btnDestZip.Name = "btnDestZip";
            this.btnDestZip.Size = new System.Drawing.Size(25, 23);
            this.btnDestZip.TabIndex = 3;
            this.btnDestZip.Text = "...";
            this.btnDestZip.UseVisualStyleBackColor = true;
            this.btnDestZip.Click += new System.EventHandler(this.btnDestZip_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(558, 95);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(80, 23);
            this.btnAddFile.TabIndex = 4;
            this.btnAddFile.Text = "Add File";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // lvSrcFiles
            // 
            this.lvSrcFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFilename});
            this.lvSrcFiles.FullRowSelect = true;
            this.lvSrcFiles.GridLines = true;
            this.lvSrcFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSrcFiles.HideSelection = false;
            this.lvSrcFiles.Location = new System.Drawing.Point(11, 95);
            this.lvSrcFiles.Name = "lvSrcFiles";
            this.lvSrcFiles.Size = new System.Drawing.Size(540, 170);
            this.lvSrcFiles.TabIndex = 5;
            this.lvSrcFiles.UseCompatibleStateImageBehavior = false;
            this.lvSrcFiles.View = System.Windows.Forms.View.Details;
            // 
            // colFilename
            // 
            this.colFilename.Text = "Filename";
            this.colFilename.Width = 320;
            // 
            // btnRemoveFiles
            // 
            this.btnRemoveFiles.Location = new System.Drawing.Point(558, 120);
            this.btnRemoveFiles.Name = "btnRemoveFiles";
            this.btnRemoveFiles.Size = new System.Drawing.Size(80, 23);
            this.btnRemoveFiles.TabIndex = 6;
            this.btnRemoveFiles.Text = "Remove Files";
            this.btnRemoveFiles.UseVisualStyleBackColor = true;
            this.btnRemoveFiles.Click += new System.EventHandler(this.btnRemoveFiles_Click);
            // 
            // btnZip
            // 
            this.btnZip.Location = new System.Drawing.Point(558, 242);
            this.btnZip.Name = "btnZip";
            this.btnZip.Size = new System.Drawing.Size(80, 23);
            this.btnZip.TabIndex = 7;
            this.btnZip.Text = "Zip";
            this.btnZip.UseVisualStyleBackColor = true;
            this.btnZip.Click += new System.EventHandler(this.btnZip_Click);
            // 
            // chkVerifyZip
            // 
            this.chkVerifyZip.AutoSize = true;
            this.chkVerifyZip.Checked = true;
            this.chkVerifyZip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerifyZip.Location = new System.Drawing.Point(558, 220);
            this.chkVerifyZip.Name = "chkVerifyZip";
            this.chkVerifyZip.Size = new System.Drawing.Size(73, 16);
            this.chkVerifyZip.TabIndex = 8;
            this.chkVerifyZip.Text = "Verify Zip";
            this.chkVerifyZip.UseVisualStyleBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(558, 53);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(80, 23);
            this.btnCheck.TabIndex = 9;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 271);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.chkVerifyZip);
            this.Controls.Add(this.btnZip);
            this.Controls.Add(this.btnRemoveFiles);
            this.Controls.Add(this.lvSrcFiles);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.btnDestZip);
            this.Controls.Add(this.lbSrcFiles);
            this.Controls.Add(this.txtDestZip);
            this.Controls.Add(this.lbDestZip);
            this.Name = "MainForm";
            this.Text = "Ionic.Zip Sample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lbDestZip;
        private System.Windows.Forms.TextBox txtDestZip;
        private System.Windows.Forms.Label lbSrcFiles;
        private System.Windows.Forms.Button btnDestZip;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.ListView lvSrcFiles;
        private System.Windows.Forms.ColumnHeader colFilename;
        private System.Windows.Forms.Button btnRemoveFiles;
        private System.Windows.Forms.Button btnZip;
        private System.Windows.Forms.CheckBox chkVerifyZip;
        private System.Windows.Forms.Button btnCheck;
    }
}

