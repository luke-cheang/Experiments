using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base64Tester
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }   // MainForm();

        /// <summary>
        /// Event handler for Load event of MainForm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.txtPlainText.Text = "";
            this.txtBase64Text.Text = "";
            this.txtPlainTextLength.Text = "0";
            this.txtByteCount.Text = "0";
            this.lvTextBytes.Items.Clear();
            this.btEncode.Enabled = false;
            this.btDecode.Enabled = false;
        }   // MainForm_Load();

        /// <summary>
        /// Event handler for TextChanged event of txtPlainText.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPlainText_TextChanged(object sender, EventArgs e)
        {
            if (this.txtPlainText.Text.Length > 0)
                this.btEncode.Enabled = true;
            else
                this.btEncode.Enabled = false;
            this.txtPlainTextLength.Text = this.txtPlainText.Text.Length.ToString();
        }   // txtPlainText_TextChanged();

        /// <summary>
        /// Event handler for TextChanged event of txtBase64Text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBase64Text_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtBase64Text.Text))
                this.btDecode.Enabled = true;
            else
                this.btDecode.Enabled = false;
        }   // txtBase64Text_TextChanged();

        /// <summary>
        /// Event handler for Click event of btEncode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btEncode_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtBase64Text.Text = string.Empty;
                this.lvTextBytes.Items.Clear();

                string srcStr = this.txtPlainText.Text;
                byte[] srcByte = Encoding.ASCII.GetBytes(srcStr);
                this.txtByteCount.Text = srcByte.Length.ToString();
                for (int i = 0; i < srcByte.Length; i++)
                {
                    this.lvTextBytes.Items.Add(i.ToString());
                    this.lvTextBytes.Items[i].SubItems.Add(string.Format("0x{0:X}", Convert.ToInt32(srcByte[i])));
                }

                this.txtBase64Text.Text = Convert.ToBase64String(srcByte);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:\n" + ex.Source + "\n" + ex.Message, "btEncode_Click()");
            }
        }   // btEncode_Click();

        /// <summary>
        /// Event handler for Click event of btDecode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDecode_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtPlainText.Text = string.Empty;
                this.lvTextBytes.Items.Clear();

                string srcStr = this.txtBase64Text.Text.Trim();
                byte[] trgByte = Convert.FromBase64String(srcStr);
                this.txtByteCount.Text = trgByte.Length.ToString();
                for (int i = 0; i < trgByte.Length; i++)
                {
                    this.lvTextBytes.Items.Add(i.ToString());
                    this.lvTextBytes.Items[i].SubItems.Add(string.Format("0x{0:X}", Convert.ToInt32(trgByte[i])));
                }

                this.txtPlainText.Text = Encoding.ASCII.GetString(trgByte);
                this.txtPlainTextLength.Text = this.txtPlainText.Text.Length.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:\n" + ex.Source + "\n" + ex.Message, "btDecode_Click()");
            }
        }   // btDecode_Click();

    }   // MainForm
}   // Base64Tester
