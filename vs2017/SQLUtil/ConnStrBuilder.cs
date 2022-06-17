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
            txtConnectionResult.Clear();
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
                    _sqlConnStrBuilder.Password = String.Empty;
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
        private void lvConnStrKeys_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewHitTestInfo hitTestInfo = lvConnStrKeys.HitTest(e.X, e.Y);
                if (hitTestInfo != null)
                {
                    String key = hitTestInfo.Item.SubItems[1].Text;
                    Debug.Print("lvConnStrkeys[" + key + "] double-clicked");
                    switch (key)
                    {
                        case "Password":
                            EditProperty form = new EditProperty();
                            bool brc = form.Execute(key, _sqlConnStrBuilder.Password, out String s);
                            if (brc)
                            {
                                _sqlConnStrBuilder.Password = s.Trim();
                                Refresh_BuilderProperties();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = Common.GetExceptionString(ex);
                MessageBox.Show(msg, "Edit ConnStr Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler for TextChanged event of txtConnStrResult.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtConnStrResult_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtConnStrResult.Text))
                btnTestConnection.Enabled = true;
            else
                btnTestConnection.Enabled = false;
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
            txtConnectionResult.Clear();

        }

    }   // ConnStrBuilder
}   // SQLUtil
