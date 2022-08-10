namespace Base64Tester
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
            this.lbPlainText = new System.Windows.Forms.Label();
            this.lbBase64Text = new System.Windows.Forms.Label();
            this.txtPlainText = new System.Windows.Forms.TextBox();
            this.txtBase64Text = new System.Windows.Forms.TextBox();
            this.btEncode = new System.Windows.Forms.Button();
            this.btDecode = new System.Windows.Forms.Button();
            this.lbPlainTextLength = new System.Windows.Forms.Label();
            this.txtPlainTextLength = new System.Windows.Forms.TextBox();
            this.lbTextBytes = new System.Windows.Forms.Label();
            this.lvTextBytes = new System.Windows.Forms.ListView();
            this.colIdx = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbByteCount = new System.Windows.Forms.Label();
            this.txtByteCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbPlainText
            // 
            this.lbPlainText.Location = new System.Drawing.Point(13, 13);
            this.lbPlainText.Name = "lbPlainText";
            this.lbPlainText.Size = new System.Drawing.Size(80, 12);
            this.lbPlainText.TabIndex = 0;
            this.lbPlainText.Text = "Plain Text:";
            this.lbPlainText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbBase64Text
            // 
            this.lbBase64Text.Location = new System.Drawing.Point(13, 323);
            this.lbBase64Text.Name = "lbBase64Text";
            this.lbBase64Text.Size = new System.Drawing.Size(80, 12);
            this.lbBase64Text.TabIndex = 1;
            this.lbBase64Text.Text = "Base64 Text:";
            this.lbBase64Text.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPlainText
            // 
            this.txtPlainText.Location = new System.Drawing.Point(95, 10);
            this.txtPlainText.Name = "txtPlainText";
            this.txtPlainText.Size = new System.Drawing.Size(200, 22);
            this.txtPlainText.TabIndex = 2;
            this.txtPlainText.TextChanged += new System.EventHandler(this.txtPlainText_TextChanged);
            // 
            // txtBase64Text
            // 
            this.txtBase64Text.Location = new System.Drawing.Point(95, 320);
            this.txtBase64Text.Name = "txtBase64Text";
            this.txtBase64Text.Size = new System.Drawing.Size(200, 22);
            this.txtBase64Text.TabIndex = 3;
            this.txtBase64Text.TextChanged += new System.EventHandler(this.txtBase64Text_TextChanged);
            // 
            // btEncode
            // 
            this.btEncode.Location = new System.Drawing.Point(15, 361);
            this.btEncode.Name = "btEncode";
            this.btEncode.Size = new System.Drawing.Size(75, 23);
            this.btEncode.TabIndex = 4;
            this.btEncode.Text = "Encode";
            this.btEncode.UseVisualStyleBackColor = true;
            this.btEncode.Click += new System.EventHandler(this.btEncode_Click);
            // 
            // btDecode
            // 
            this.btDecode.Location = new System.Drawing.Point(95, 361);
            this.btDecode.Name = "btDecode";
            this.btDecode.Size = new System.Drawing.Size(75, 23);
            this.btDecode.TabIndex = 5;
            this.btDecode.Text = "Decode";
            this.btDecode.UseVisualStyleBackColor = true;
            this.btDecode.Click += new System.EventHandler(this.btDecode_Click);
            // 
            // lbPlainTextLength
            // 
            this.lbPlainTextLength.Location = new System.Drawing.Point(301, 13);
            this.lbPlainTextLength.Name = "lbPlainTextLength";
            this.lbPlainTextLength.Size = new System.Drawing.Size(80, 12);
            this.lbPlainTextLength.TabIndex = 6;
            this.lbPlainTextLength.Text = "Text Length:";
            this.lbPlainTextLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPlainTextLength
            // 
            this.txtPlainTextLength.Location = new System.Drawing.Point(387, 10);
            this.txtPlainTextLength.Name = "txtPlainTextLength";
            this.txtPlainTextLength.ReadOnly = true;
            this.txtPlainTextLength.Size = new System.Drawing.Size(50, 22);
            this.txtPlainTextLength.TabIndex = 7;
            // 
            // lbTextBytes
            // 
            this.lbTextBytes.Location = new System.Drawing.Point(13, 43);
            this.lbTextBytes.Name = "lbTextBytes";
            this.lbTextBytes.Size = new System.Drawing.Size(80, 12);
            this.lbTextBytes.TabIndex = 8;
            this.lbTextBytes.Text = "Text Bytes:";
            this.lbTextBytes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lvTextBytes
            // 
            this.lvTextBytes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIdx,
            this.colValue});
            this.lvTextBytes.FullRowSelect = true;
            this.lvTextBytes.GridLines = true;
            this.lvTextBytes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTextBytes.HideSelection = false;
            this.lvTextBytes.Location = new System.Drawing.Point(95, 40);
            this.lvTextBytes.Name = "lvTextBytes";
            this.lvTextBytes.Size = new System.Drawing.Size(200, 256);
            this.lvTextBytes.TabIndex = 9;
            this.lvTextBytes.UseCompatibleStateImageBehavior = false;
            this.lvTextBytes.View = System.Windows.Forms.View.Details;
            // 
            // colIdx
            // 
            this.colIdx.Text = "Index";
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            // 
            // lbByteCount
            // 
            this.lbByteCount.Location = new System.Drawing.Point(301, 43);
            this.lbByteCount.Name = "lbByteCount";
            this.lbByteCount.Size = new System.Drawing.Size(80, 12);
            this.lbByteCount.TabIndex = 10;
            this.lbByteCount.Text = "Byte Count:";
            this.lbByteCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtByteCount
            // 
            this.txtByteCount.Location = new System.Drawing.Point(387, 40);
            this.txtByteCount.Name = "txtByteCount";
            this.txtByteCount.ReadOnly = true;
            this.txtByteCount.Size = new System.Drawing.Size(50, 22);
            this.txtByteCount.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 404);
            this.Controls.Add(this.txtByteCount);
            this.Controls.Add(this.lbByteCount);
            this.Controls.Add(this.lvTextBytes);
            this.Controls.Add(this.lbTextBytes);
            this.Controls.Add(this.txtPlainTextLength);
            this.Controls.Add(this.lbPlainTextLength);
            this.Controls.Add(this.btDecode);
            this.Controls.Add(this.btEncode);
            this.Controls.Add(this.txtBase64Text);
            this.Controls.Add(this.txtPlainText);
            this.Controls.Add(this.lbBase64Text);
            this.Controls.Add(this.lbPlainText);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPlainText;
        private System.Windows.Forms.Label lbBase64Text;
        private System.Windows.Forms.TextBox txtPlainText;
        private System.Windows.Forms.TextBox txtBase64Text;
        private System.Windows.Forms.Button btEncode;
        private System.Windows.Forms.Button btDecode;
        private System.Windows.Forms.Label lbPlainTextLength;
        private System.Windows.Forms.TextBox txtPlainTextLength;
        private System.Windows.Forms.Label lbTextBytes;
        private System.Windows.Forms.ListView lvTextBytes;
        private System.Windows.Forms.ColumnHeader colIdx;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.Label lbByteCount;
        private System.Windows.Forms.TextBox txtByteCount;
    }
}

