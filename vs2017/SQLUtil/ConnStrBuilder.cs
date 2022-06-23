using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Common.Utility;

namespace SQLUtil
{
    public partial class ConnStrBuilder : Form
    {
        private SqlConnectionStringBuilder _sqlConnStrBuilder;

        /// <summary>
        /// Default constructor of ConnStrBuilder.
        /// </summary>
        public ConnStrBuilder()
        {
            InitializeComponent();

            _sqlConnStrBuilder = new SqlConnectionStringBuilder();
        }   // ConnStrBuilder();

        /// <summary>
        /// 把_sqlConnStrBuilder中的每一個Property內容都顯示在lvConnStrKeys中。
        /// </summary>
        private void Refresh_BuilderProperties()
        {
            Debug.WriteLine("Refresh_BuilderProperties()");
            Debug.WriteLine("_sqlConnStrBuilder.Keys.Count=" + _sqlConnStrBuilder.Keys.Count.ToString());
            lvConnStrKeys.Items.Clear();
            if (_sqlConnStrBuilder.Keys.Count > 0)
            {
                int i = 1;
                foreach (String key in _sqlConnStrBuilder.Keys)
                {
                    Debug.WriteLine("_sqlConnStrBuilder[" + key + "]=[" + _sqlConnStrBuilder[key] + "]");
                    ListViewItem item = new ListViewItem(i.ToString());     // 第1欄是第幾個(從1開始)
                    item.SubItems.Add(key);                                 // 第2欄是key (Property名稱)
                    item.SubItems.Add(_sqlConnStrBuilder[key].ToString());  // 第3欄是value
                    lvConnStrKeys.Items.Add(item);
                    i++;
                }
            }
            lvConnStrKeys.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }   // Refresh_BuilderProperties();

        /// <summary>
        /// 清除各輸出字串的內容。
        /// </summary>
        private void Clear_OutputStrings()
        {
            txtConnStrResult.Clear();
            txtPlainPassword.Clear();
            txtBase64Password.Clear();
        }   // Clear_OutputStrings();

        /// <summary>
        /// Event handler for Load event of ConnStrBuilder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnStrBuilder_Load(object sender, EventArgs e)
        {
            String connStr = ConfigurationManager.AppSettings["ConnStr"];

            btnParseConnStr.Enabled = false;
            btnTestConnection.Enabled = false;
            btnExport2Ini.Enabled = false;
            if (!String.IsNullOrWhiteSpace(connStr))
                txtConnStr.Text = connStr.Trim();
        }   // ConnStrBuilder_Load();

        /// <summary>
        /// Event handler for TextChanged event of txtConnStr.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtConnStr_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtConnStr.Text))
                btnParseConnStr.Enabled = true;
            else
                btnParseConnStr.Enabled = false;
        }   // txtConnStr_TextChanged();

        /// <summary>
        /// Event handler for Click event of btnParseConnStr.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// 用_sqlConnStrBuilder來解析連線字串，再顯示解析結果(_sqlConnStrBuilder的Properties)。
        /// </remarks>
        private void btnParseConnStr_Click(object sender, EventArgs e)
        {
            String s = String.Empty;
            Debug.WriteLine("btnParseConnStr_Click()");
            try
            {
                s = txtConnStr.Text.Trim();
                Debug.WriteLine("txtConnStr.Text=[" + s + "]");
                Clear_OutputStrings();
                _sqlConnStrBuilder.Clear();
                _sqlConnStrBuilder.ConnectionString = s;
                Refresh_BuilderProperties();
            }
            catch (Exception ex)
            {
                string msg = Common.GetExceptionString(ex);
                MessageBox.Show(msg, "Parse ConnStr Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // btnParseConnStr_Click();

        /// <summary>
        /// Event handler for Click event of btnGenerate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// 用_sqlConnStrBuilder來產生新的連線字串。
        /// </remarks>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                Clear_OutputStrings();
                if (chkSeparatePassword.Checked)
                {
                    // 要把密碼分離出來。
                    String pswd = _sqlConnStrBuilder.Password;
                    // 先產生沒有密碼的連線字串。
                    _sqlConnStrBuilder.Remove("Password");
                    txtConnStrResult.Text = _sqlConnStrBuilder.ConnectionString;
                    // 產生明碼的密碼及換成Base64的密碼。
                    txtPlainPassword.Text = pswd;
                    byte[] b64pswd = Encoding.ASCII.GetBytes(pswd);
                    txtBase64Password.Text = Convert.ToBase64String(b64pswd);
                    // 把密碼放回ConnectionStringBuilder。
                    _sqlConnStrBuilder.Password = pswd;
                }
                else
                {
                    // 不用把密碼分離出來，直接產生連線字串。
                    txtConnStrResult.Text = _sqlConnStrBuilder.ConnectionString;
                }
            }
            catch (Exception ex)
            {
                string msg = Common.GetExceptionString(ex);
                MessageBox.Show(msg, "Generate ConnStr Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // btnGenerate_Click();

        /// <summary>
        /// Event handler for MouseDoubleClick event of lvConnStrKeys.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// 編輯_sqlConnStrBuilder的設定值。
        /// </remarks>
        private void lvConnStrKeys_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("lvConnStrKeys_MouseDoubleClick()");
            try
            {
                ListViewHitTestInfo hitTestInfo = lvConnStrKeys.HitTest(e.X, e.Y);
                if (hitTestInfo != null)
                {
                    String key = hitTestInfo.Item.SubItems[1].Text;
                    Debug.Print("lvConnStrkeys[" + key + "] double-clicked");
                    switch (key)
                    {
                        // 內容為字串的設定值。
                        #region String_Params
                        case "Data Source":
                        case "Initial Catalog":
                        case "User ID":
                        case "Password":
                        case "Network Library":
                            // 用EditProperty來編輯字串。
                            EditProperty form = new EditProperty();
                            bool brc = form.Execute(key, _sqlConnStrBuilder[key].ToString(), out String s);
                            if (brc)
                            {
                                _sqlConnStrBuilder[key] = s.Trim();
                                Refresh_BuilderProperties();
                            }
                            break;
                        #endregion  // String_Params

                        // 內容為T/F的設定值。
                        #region Bool_Params
                        case "Integrated Security":
                        case "Persist Security Info":
                        case "MultiSubnetFailover":
                            break;
                        #endregion  // Bool_Params

                        // 還未處理的設定值。
                        #region Unknown_Params
                        case "Failover Partner":
                        case "AttachDbFilename":
                        case "Enlist":
                        case "Pooling":
                        case "Min Pool Size":
                        case "Max Pool Size":
                        case "PoolBlockingPeriod":
                        case "Asynchronous Processing":
                        case "Connection Reset":
                        case "MultipleActiveResultSets":
                        case "Replication":
                        case "Connect Timeout":
                        case "Encrypt":
                        case "TrustServerCertificate":
                        case "Load Balance Timeout":
                        case "Packet Size":
                        case "Type System Version":
                        case "Authentication":
                        case "Application Name":
                        case "Current Language":
                        case "Workstation ID":
                        case "User Instance":
                        case "Context Connection":
                        case "Transaction Binding":
                        case "ApplicationIntent":
                        case "TransparentNetworkIPResolution":
                        case "ConnectRetryCount":
                        case "ConnectRetryInterval":
                        case "Column Encryption Setting":
                        case "Enclave Attestation Url":
                        default:
                            break;
                        #endregion  // Unknown_Params

                    }   // switch (key)
                }
            }
            catch (Exception ex)
            {
                string msg = Common.GetExceptionString(ex);
                MessageBox.Show(msg, "Edit ConnStr Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // lvConnStrKeys_MouseDoubleClick();

        /// <summary>
        /// Event handler for TextChanged event of txtConnStrResult.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtConnStrResult_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtConnStrResult.Text))
            {
                btnTestConnection.Enabled = true;
                btnExport2Ini.Enabled = true;
            }
            else
            {
                btnTestConnection.Enabled = false;
                btnExport2Ini.Enabled = false;
            }
        }   // txtConnStrResult_TextChanged();

        /// <summary>
        /// Event handler for Click event of btnTestConnection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// 測試產生的連線字串是否可以連上資料庫。
        /// </remarks>
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("btnTestConnection_Click()");
            using (SqlConnection cnn = new SqlConnection())
            {
                // 組成完整的連線字串。
                String cnn_str = txtConnStrResult.Text.Trim();
                if (!String.IsNullOrWhiteSpace(txtBase64Password.Text))
                {
                    // 把Base64轉回一般文字。
                    Byte[] pswd_byte = Convert.FromBase64String(txtBase64Password.Text.Trim());
                    String pswd_str = Encoding.ASCII.GetString(pswd_byte).Trim();

                    // 最後固定用雙引號把密碼括起來加入至連線字串。
                    cnn_str += ";Password=" + "\"" + pswd_str + "\"" + ";";
                }
                // 嘗試連線。
                try
                {
                    Debug.WriteLine("cnn_str=[" + cnn_str + "]");
                    cnn.ConnectionString = cnn_str;
                    cnn.Open();
                    MessageBox.Show(
                        "Connect to\n\n" + cnn_str + "\n\nSuccess",
                        "Test Conneciton",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.None);
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    string msg = Common.GetExceptionString(ex);
                    MessageBox.Show(
                        "Connect to\n\n" + cnn_str + "\n\nFail\n\n" + msg,
                        "Test Conneciton",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }   // btnTestConnection_Click();

        /// <summary>
        /// Event handler for Click event of btnExport2Ini.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// 把連線字串資料寫到INI檔。
        /// </remarks>
        private void btnExport2Ini_Click(object sender, EventArgs e)
        {
            Debug.Write("btnExport_Click()");
            saveFileDialog1.ShowHelp = false;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = "ini";
            saveFileDialog1.Filter = "Ini files (*.ini)|*.ini|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (DialogResult.OK == dr)
            {
                Debug.WriteLine("Export connection string to [" + saveFileDialog1.FileName + "]");
                try
                {
                    IniFile iniFile = new IniFile(saveFileDialog1.FileName);
                    iniFile.SetString("DBInfo", "ConnStr", txtConnStrResult.Text);
                    iniFile.SetString("DBInfo", "EncodedPswd", txtBase64Password.Text);

                    MessageBox.Show(
                        "Exported to [" + iniFile.Filename + "]", 
                        "Export to INI", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.None);
                }
                catch (Exception ex)
                {
                    string msg = Common.GetExceptionString(ex);
                    MessageBox.Show(msg, "Export to INI Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }   // ConnStrBuilder
}   // SQLUtil
