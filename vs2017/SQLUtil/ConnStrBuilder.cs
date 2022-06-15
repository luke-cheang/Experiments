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
        /// 
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
                    ListViewItem item = new ListViewItem(i.ToString());
                    item.SubItems.Add(key);
                    item.SubItems.Add(_sqlConnStrBuilder[key].ToString());
                    lvConnStrKeys.Items.Add(item);
                    i++;
                }
            }
            lvConnStrKeys.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            txtConnStrResult.Clear();
        }   // Refresh_BuilderProperties();

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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                txtConnStrResult.Text = _sqlConnStrBuilder.ConnectionString;
            }
            catch (Exception ex)
            {
                string msg = Common.GetExceptionString(ex);
                MessageBox.Show(msg, "Generate ConnStr Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

    }   // ConnStrBuilder
}   // SQLUtil
