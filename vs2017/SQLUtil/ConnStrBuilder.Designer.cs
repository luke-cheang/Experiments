namespace SQLUtil
{
    partial class ConnStrBuilder
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
            this.lbConnStr = new System.Windows.Forms.Label();
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.btnParseConnStr = new System.Windows.Forms.Button();
            this.lvConnStrKeys = new System.Windows.Forms.ListView();
            this.colKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtConnStrResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbConnStr
            // 
            this.lbConnStr.AutoSize = true;
            this.lbConnStr.Location = new System.Drawing.Point(11, 9);
            this.lbConnStr.Name = "lbConnStr";
            this.lbConnStr.Size = new System.Drawing.Size(93, 12);
            this.lbConnStr.TabIndex = 0;
            this.lbConnStr.Text = "Connection String:";
            // 
            // txtConnStr
            // 
            this.txtConnStr.Location = new System.Drawing.Point(11, 25);
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.Size = new System.Drawing.Size(774, 22);
            this.txtConnStr.TabIndex = 1;
            this.txtConnStr.TextChanged += new System.EventHandler(this.txtConnStr_TextChanged);
            // 
            // btnParseConnStr
            // 
            this.btnParseConnStr.Location = new System.Drawing.Point(11, 51);
            this.btnParseConnStr.Name = "btnParseConnStr";
            this.btnParseConnStr.Size = new System.Drawing.Size(75, 23);
            this.btnParseConnStr.TabIndex = 2;
            this.btnParseConnStr.Text = "Parse";
            this.btnParseConnStr.UseVisualStyleBackColor = true;
            this.btnParseConnStr.Click += new System.EventHandler(this.btnParseConnStr_Click);
            // 
            // lvConnStrKeys
            // 
            this.lvConnStrKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colKey,
            this.colValue});
            this.lvConnStrKeys.FullRowSelect = true;
            this.lvConnStrKeys.GridLines = true;
            this.lvConnStrKeys.HideSelection = false;
            this.lvConnStrKeys.Location = new System.Drawing.Point(11, 105);
            this.lvConnStrKeys.MultiSelect = false;
            this.lvConnStrKeys.Name = "lvConnStrKeys";
            this.lvConnStrKeys.Size = new System.Drawing.Size(774, 328);
            this.lvConnStrKeys.TabIndex = 3;
            this.lvConnStrKeys.UseCompatibleStateImageBehavior = false;
            this.lvConnStrKeys.View = System.Windows.Forms.View.Details;
            // 
            // colKey
            // 
            this.colKey.Text = "Key";
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            // 
            // txtConnStrResult
            // 
            this.txtConnStrResult.Location = new System.Drawing.Point(11, 77);
            this.txtConnStrResult.Name = "txtConnStrResult";
            this.txtConnStrResult.ReadOnly = true;
            this.txtConnStrResult.Size = new System.Drawing.Size(772, 22);
            this.txtConnStrResult.TabIndex = 4;
            // 
            // ConnStrBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtConnStrResult);
            this.Controls.Add(this.lvConnStrKeys);
            this.Controls.Add(this.btnParseConnStr);
            this.Controls.Add(this.txtConnStr);
            this.Controls.Add(this.lbConnStr);
            this.Name = "ConnStrBuilder";
            this.Text = "ConnStrBuilder";
            this.Load += new System.EventHandler(this.ConnStrBuilder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbConnStr;
        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.Button btnParseConnStr;
        private System.Windows.Forms.ListView lvConnStrKeys;
        private System.Windows.Forms.ColumnHeader colKey;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.TextBox txtConnStrResult;
    }
}

