using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// 
        /// </summary>
        public ConnStrBuilder()
        {
            InitializeComponent();

            _sqlConnStrBuilder = new SqlConnectionStringBuilder();
        }   // ConnStrBuilder();

        /// <summary>
        /// Event handler for Load event of ConnStrBuilder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnStrBuilder_Load(object sender, EventArgs e)
        {
            btnParseConnStr.Enabled = false;
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParseConnStr_Click(object sender, EventArgs e)
        {
            String s = String.Empty;

            try
            {
                s = txtConnStr.Text.Trim();
                Debug.WriteLine("txtConnStr.Text=[" + s + "]");
                txtConnStrResult.Clear();
                lvConnStrKeys.Items.Clear();
                _sqlConnStrBuilder.Clear();
                _sqlConnStrBuilder.ConnectionString = txtConnStr.Text.Trim();
                Debug.WriteLine("_sqlConnStrBuilder.Keys.Count=" + _sqlConnStrBuilder.Keys.Count.ToString());
                if (_sqlConnStrBuilder.Keys.Count > 0)
                {
                    foreach (String key in _sqlConnStrBuilder.Keys)
                    {
                        Debug.WriteLine("_sqlConnStrBuilder[" + key + "]=[" + _sqlConnStrBuilder[key] + "]");
                        ListViewItem item = new ListViewItem(key);
                        item.SubItems.Add(_sqlConnStrBuilder[key].ToString());
                        lvConnStrKeys.Items.Add(item);
                    }
                }
                lvConnStrKeys.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                txtConnStrResult.Text = _sqlConnStrBuilder.ConnectionString;
            }
            catch (Exception ex)
            {
                string msg = Common.GetExceptionString(ex);
                MessageBox.Show(msg, "Parse ConnStr Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }   // ConnStrBuilder
}   // SQLUtil
