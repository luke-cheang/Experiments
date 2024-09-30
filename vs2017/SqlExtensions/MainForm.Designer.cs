namespace SqlExtensions
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
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.tabCtrlMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStripMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbReopenCnnString = new System.Windows.Forms.Label();
            this.txtReopenCnnString = new System.Windows.Forms.TextBox();
            this.txtReopenRetryCnt = new System.Windows.Forms.TextBox();
            this.lbReopenRetryCnt = new System.Windows.Forms.Label();
            this.btnOpenWithRetry = new System.Windows.Forms.Button();
            this.txtReopenDelay = new System.Windows.Forms.TextBox();
            this.lbReopenDelay = new System.Windows.Forms.Label();
            this.statusStripMain.SuspendLayout();
            this.tabCtrlMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMessage});
            this.statusStripMain.Location = new System.Drawing.Point(0, 426);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(800, 24);
            this.statusStripMain.TabIndex = 0;
            // 
            // tabCtrlMain
            // 
            this.tabCtrlMain.Controls.Add(this.tabPage1);
            this.tabCtrlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlMain.Location = new System.Drawing.Point(0, 0);
            this.tabCtrlMain.Name = "tabCtrlMain";
            this.tabCtrlMain.SelectedIndex = 0;
            this.tabCtrlMain.Size = new System.Drawing.Size(800, 426);
            this.tabCtrlMain.TabIndex = 0;
            this.tabCtrlMain.SelectedIndexChanged += new System.EventHandler(this.tabCtrlMain_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtReopenDelay);
            this.tabPage1.Controls.Add(this.lbReopenDelay);
            this.tabPage1.Controls.Add(this.btnOpenWithRetry);
            this.tabPage1.Controls.Add(this.txtReopenRetryCnt);
            this.tabPage1.Controls.Add(this.lbReopenRetryCnt);
            this.tabPage1.Controls.Add(this.txtReopenCnnString);
            this.tabPage1.Controls.Add(this.lbReopenCnnString);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "OpenWithRetry";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStripMessage
            // 
            this.toolStripMessage.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripMessage.Name = "toolStripMessage";
            this.toolStripMessage.Size = new System.Drawing.Size(785, 19);
            this.toolStripMessage.Spring = true;
            this.toolStripMessage.Text = "toolStripMessage";
            this.toolStripMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbReopenCnnString
            // 
            this.lbReopenCnnString.Location = new System.Drawing.Point(5, 11);
            this.lbReopenCnnString.Name = "lbReopenCnnString";
            this.lbReopenCnnString.Size = new System.Drawing.Size(100, 22);
            this.lbReopenCnnString.TabIndex = 0;
            this.lbReopenCnnString.Text = "Connection String:";
            this.lbReopenCnnString.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtReopenCnnString
            // 
            this.txtReopenCnnString.Location = new System.Drawing.Point(111, 11);
            this.txtReopenCnnString.Name = "txtReopenCnnString";
            this.txtReopenCnnString.Size = new System.Drawing.Size(600, 22);
            this.txtReopenCnnString.TabIndex = 1;
            // 
            // txtReopenRetryCnt
            // 
            this.txtReopenRetryCnt.Location = new System.Drawing.Point(111, 41);
            this.txtReopenRetryCnt.Name = "txtReopenRetryCnt";
            this.txtReopenRetryCnt.Size = new System.Drawing.Size(50, 22);
            this.txtReopenRetryCnt.TabIndex = 3;
            // 
            // lbReopenRetryCnt
            // 
            this.lbReopenRetryCnt.Location = new System.Drawing.Point(5, 41);
            this.lbReopenRetryCnt.Name = "lbReopenRetryCnt";
            this.lbReopenRetryCnt.Size = new System.Drawing.Size(100, 22);
            this.lbReopenRetryCnt.TabIndex = 2;
            this.lbReopenRetryCnt.Text = "Retry Count (>=0):";
            this.lbReopenRetryCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOpenWithRetry
            // 
            this.btnOpenWithRetry.Location = new System.Drawing.Point(111, 101);
            this.btnOpenWithRetry.Name = "btnOpenWithRetry";
            this.btnOpenWithRetry.Size = new System.Drawing.Size(75, 23);
            this.btnOpenWithRetry.TabIndex = 4;
            this.btnOpenWithRetry.Text = "Open";
            this.btnOpenWithRetry.UseVisualStyleBackColor = true;
            this.btnOpenWithRetry.Click += new System.EventHandler(this.btnOpenWithRetry_Click);
            // 
            // txtReopenDelay
            // 
            this.txtReopenDelay.Location = new System.Drawing.Point(111, 71);
            this.txtReopenDelay.Name = "txtReopenDelay";
            this.txtReopenDelay.Size = new System.Drawing.Size(50, 22);
            this.txtReopenDelay.TabIndex = 6;
            // 
            // lbReopenDelay
            // 
            this.lbReopenDelay.Location = new System.Drawing.Point(5, 71);
            this.lbReopenDelay.Name = "lbReopenDelay";
            this.lbReopenDelay.Size = new System.Drawing.Size(100, 22);
            this.lbReopenDelay.TabIndex = 5;
            this.lbReopenDelay.Text = "Delay (ms):";
            this.lbReopenDelay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabCtrlMain);
            this.Controls.Add(this.statusStripMain);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.tabCtrlMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.TabControl tabCtrlMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripMessage;
        private System.Windows.Forms.Button btnOpenWithRetry;
        private System.Windows.Forms.TextBox txtReopenRetryCnt;
        private System.Windows.Forms.Label lbReopenRetryCnt;
        private System.Windows.Forms.TextBox txtReopenCnnString;
        private System.Windows.Forms.Label lbReopenCnnString;
        private System.Windows.Forms.TextBox txtReopenDelay;
        private System.Windows.Forms.Label lbReopenDelay;
    }
}

