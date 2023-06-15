namespace XMLTool
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
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoadXML = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelectSingleNode = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.statusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusFilename = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtProgressMessage = new System.Windows.Forms.TextBox();
            this.txtSelectXPath1 = new System.Windows.Forms.ToolStripTextBox();
            this.menuStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(800, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLoadXML,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(38, 20);
            this.menuFile.Text = "&File";
            // 
            // menuLoadXML
            // 
            this.menuLoadXML.Name = "menuLoadXML";
            this.menuLoadXML.Size = new System.Drawing.Size(132, 22);
            this.menuLoadXML.Text = "&Load XML";
            this.menuLoadXML.Click += new System.EventHandler(this.menuLoadXML_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(132, 22);
            this.menuExit.Text = "E&xit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSelectSingleNode});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(41, 20);
            this.menuEdit.Text = "&Edit";
            // 
            // menuSelectSingleNode
            // 
            this.menuSelectSingleNode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtSelectXPath1});
            this.menuSelectSingleNode.Name = "menuSelectSingleNode";
            this.menuSelectSingleNode.Size = new System.Drawing.Size(182, 22);
            this.menuSelectSingleNode.Text = "Select &Single Node";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMessage,
            this.statusFilename});
            this.statusStripMain.Location = new System.Drawing.Point(0, 426);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(800, 24);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStripMain";
            // 
            // statusMessage
            // 
            this.statusMessage.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusMessage.Name = "statusMessage";
            this.statusMessage.Size = new System.Drawing.Size(723, 19);
            this.statusMessage.Spring = true;
            this.statusMessage.Text = "Status Message";
            this.statusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusFilename
            // 
            this.statusFilename.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusFilename.Name = "statusFilename";
            this.statusFilename.Size = new System.Drawing.Size(62, 19);
            this.statusFilename.Text = "Filename";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtProgressMessage
            // 
            this.txtProgressMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProgressMessage.Location = new System.Drawing.Point(0, 24);
            this.txtProgressMessage.Multiline = true;
            this.txtProgressMessage.Name = "txtProgressMessage";
            this.txtProgressMessage.ReadOnly = true;
            this.txtProgressMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtProgressMessage.Size = new System.Drawing.Size(800, 402);
            this.txtProgressMessage.TabIndex = 2;
            // 
            // txtSelectXPath1
            // 
            this.txtSelectXPath1.Name = "txtSelectXPath1";
            this.txtSelectXPath1.Size = new System.Drawing.Size(100, 23);
            this.txtSelectXPath1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSelectXPath1_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtProgressMessage);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuLoadXML;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuSelectSingleNode;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel statusMessage;
        private System.Windows.Forms.ToolStripStatusLabel statusFilename;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtProgressMessage;
        private System.Windows.Forms.ToolStripTextBox txtSelectXPath1;
    }
}

