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
            this.lbOrgConnStr = new System.Windows.Forms.Label();
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.btnParseConnStr = new System.Windows.Forms.Button();
            this.lvConnStrKeys = new System.Windows.Forms.ListView();
            this.colNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtConnStrResult = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtPlainPassword = new System.Windows.Forms.TextBox();
            this.txtBase64Password = new System.Windows.Forms.TextBox();
            this.lbOutConnStr = new System.Windows.Forms.Label();
            this.lbPlainPassword = new System.Windows.Forms.Label();
            this.lbBase64Password = new System.Windows.Forms.Label();
            this.chkSeparatePassword = new System.Windows.Forms.CheckBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.lbConnectionResult = new System.Windows.Forms.Label();
            this.txtConnectionResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbOrgConnStr
            // 
            this.lbOrgConnStr.AutoSize = true;
            this.lbOrgConnStr.Location = new System.Drawing.Point(11, 9);
            this.lbOrgConnStr.Name = "lbOrgConnStr";
            this.lbOrgConnStr.Size = new System.Drawing.Size(134, 12);
            this.lbOrgConnStr.TabIndex = 1;
            this.lbOrgConnStr.Text = "Original Connection String:";
            // 
            // txtConnStr
            // 
            this.txtConnStr.Location = new System.Drawing.Point(11, 25);
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.Size = new System.Drawing.Size(774, 22);
            this.txtConnStr.TabIndex = 2;
            this.txtConnStr.TextChanged += new System.EventHandler(this.txtConnStr_TextChanged);
            // 
            // btnParseConnStr
            // 
            this.btnParseConnStr.Location = new System.Drawing.Point(11, 51);
            this.btnParseConnStr.Name = "btnParseConnStr";
            this.btnParseConnStr.Size = new System.Drawing.Size(100, 23);
            this.btnParseConnStr.TabIndex = 3;
            this.btnParseConnStr.Text = "Parse";
            this.btnParseConnStr.UseVisualStyleBackColor = true;
            this.btnParseConnStr.Click += new System.EventHandler(this.btnParseConnStr_Click);
            // 
            // lvConnStrKeys
            // 
            this.lvConnStrKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colKey,
            this.colValue});
            this.lvConnStrKeys.FullRowSelect = true;
            this.lvConnStrKeys.GridLines = true;
            this.lvConnStrKeys.HideSelection = false;
            this.lvConnStrKeys.Location = new System.Drawing.Point(11, 77);
            this.lvConnStrKeys.MultiSelect = false;
            this.lvConnStrKeys.Name = "lvConnStrKeys";
            this.lvConnStrKeys.Size = new System.Drawing.Size(774, 292);
            this.lvConnStrKeys.TabIndex = 4;
            this.lvConnStrKeys.UseCompatibleStateImageBehavior = false;
            this.lvConnStrKeys.View = System.Windows.Forms.View.Details;
            this.lvConnStrKeys.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvConnStrKeys_MouseDoubleClick);
            // 
            // colNo
            // 
            this.colNo.Text = "No";
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
            this.txtConnStrResult.Location = new System.Drawing.Point(11, 421);
            this.txtConnStrResult.Name = "txtConnStrResult";
            this.txtConnStrResult.ReadOnly = true;
            this.txtConnStrResult.Size = new System.Drawing.Size(774, 22);
            this.txtConnStrResult.TabIndex = 8;
            this.txtConnStrResult.TextChanged += new System.EventHandler(this.txtConnStrResult_TextChanged);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(11, 375);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(100, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtPlainPassword
            // 
            this.txtPlainPassword.Location = new System.Drawing.Point(11, 467);
            this.txtPlainPassword.Name = "txtPlainPassword";
            this.txtPlainPassword.ReadOnly = true;
            this.txtPlainPassword.Size = new System.Drawing.Size(384, 22);
            this.txtPlainPassword.TabIndex = 10;
            // 
            // txtBase64Password
            // 
            this.txtBase64Password.Location = new System.Drawing.Point(401, 467);
            this.txtBase64Password.Name = "txtBase64Password";
            this.txtBase64Password.ReadOnly = true;
            this.txtBase64Password.Size = new System.Drawing.Size(384, 22);
            this.txtBase64Password.TabIndex = 12;
            // 
            // lbOutConnStr
            // 
            this.lbOutConnStr.AutoSize = true;
            this.lbOutConnStr.Location = new System.Drawing.Point(11, 406);
            this.lbOutConnStr.Name = "lbOutConnStr";
            this.lbOutConnStr.Size = new System.Drawing.Size(128, 12);
            this.lbOutConnStr.TabIndex = 7;
            this.lbOutConnStr.Text = "Output Connection String:";
            // 
            // lbPlainPassword
            // 
            this.lbPlainPassword.AutoSize = true;
            this.lbPlainPassword.Location = new System.Drawing.Point(11, 451);
            this.lbPlainPassword.Name = "lbPlainPassword";
            this.lbPlainPassword.Size = new System.Drawing.Size(77, 12);
            this.lbPlainPassword.TabIndex = 9;
            this.lbPlainPassword.Text = "Plain Password:";
            // 
            // lbBase64Password
            // 
            this.lbBase64Password.AutoSize = true;
            this.lbBase64Password.Location = new System.Drawing.Point(401, 451);
            this.lbBase64Password.Name = "lbBase64Password";
            this.lbBase64Password.Size = new System.Drawing.Size(88, 12);
            this.lbBase64Password.TabIndex = 11;
            this.lbBase64Password.Text = "Base64 Password:";
            // 
            // chkSeparatePassword
            // 
            this.chkSeparatePassword.AutoSize = true;
            this.chkSeparatePassword.Location = new System.Drawing.Point(131, 379);
            this.chkSeparatePassword.Name = "chkSeparatePassword";
            this.chkSeparatePassword.Size = new System.Drawing.Size(109, 16);
            this.chkSeparatePassword.TabIndex = 6;
            this.chkSeparatePassword.Text = "Separate Password";
            this.chkSeparatePassword.UseVisualStyleBackColor = true;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(11, 501);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(100, 23);
            this.btnTestConnection.TabIndex = 13;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // lbConnectionResult
            // 
            this.lbConnectionResult.AutoSize = true;
            this.lbConnectionResult.Location = new System.Drawing.Point(115, 506);
            this.lbConnectionResult.Name = "lbConnectionResult";
            this.lbConnectionResult.Size = new System.Drawing.Size(59, 12);
            this.lbConnectionResult.TabIndex = 14;
            this.lbConnectionResult.Text = "Test Result:";
            // 
            // txtConnectionResult
            // 
            this.txtConnectionResult.Location = new System.Drawing.Point(181, 502);
            this.txtConnectionResult.Name = "txtConnectionResult";
            this.txtConnectionResult.ReadOnly = true;
            this.txtConnectionResult.Size = new System.Drawing.Size(604, 22);
            this.txtConnectionResult.TabIndex = 15;
            // 
            // ConnStrBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 541);
            this.Controls.Add(this.txtConnectionResult);
            this.Controls.Add(this.lbConnectionResult);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.chkSeparatePassword);
            this.Controls.Add(this.lbBase64Password);
            this.Controls.Add(this.lbPlainPassword);
            this.Controls.Add(this.lbOutConnStr);
            this.Controls.Add(this.txtBase64Password);
            this.Controls.Add(this.txtPlainPassword);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtConnStrResult);
            this.Controls.Add(this.lvConnStrKeys);
            this.Controls.Add(this.btnParseConnStr);
            this.Controls.Add(this.txtConnStr);
            this.Controls.Add(this.lbOrgConnStr);
            this.Name = "ConnStrBuilder";
            this.Text = "ConnStrBuilder";
            this.Load += new System.EventHandler(this.ConnStrBuilder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbOrgConnStr;
        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.Button btnParseConnStr;
        private System.Windows.Forms.ListView lvConnStrKeys;
        private System.Windows.Forms.ColumnHeader colKey;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.TextBox txtConnStrResult;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.TextBox txtPlainPassword;
        private System.Windows.Forms.TextBox txtBase64Password;
        private System.Windows.Forms.Label lbOutConnStr;
        private System.Windows.Forms.Label lbPlainPassword;
        private System.Windows.Forms.Label lbBase64Password;
        private System.Windows.Forms.CheckBox chkSeparatePassword;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label lbConnectionResult;
        private System.Windows.Forms.TextBox txtConnectionResult;
    }
}

