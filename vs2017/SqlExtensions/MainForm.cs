using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlExtensions
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 顯示狀態訊息。
        /// </summary>
        /// <param name="msg"></param>
        private void ShowStatusMessage(string msg)
        {
            toolStripMessage.Text = msg;
            statusStripMain.Refresh();
        }   // ShowStatusMessage();

        /// <summary>
        /// Default constructor of MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }   // MainForm()

        private void tabCtrlMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOpenWithRetry_Click(object sender, EventArgs e)
        {
            string msg = "";

            if (!string.IsNullOrWhiteSpace(txtReopenCnnString.Text))
            {
                int retry;
                if (!int.TryParse(txtReopenRetryCnt.Text, out retry) || (retry < 0))
                {
                    retry = 0;
                    txtReopenRetryCnt.Text = retry.ToString();    // 讓使用者知道Retry Count有修正過。
                }
                int delay;
                if (!int.TryParse(txtReopenDelay.Text, out delay) || (delay < 100))
                {
                    delay = 100;
                    txtReopenDelay.Text = delay.ToString(); // 讓使用者知道Delay有修正過。
                }
                try
                {
                    ShowStatusMessage("Open Connection");
                    using (SqlConnection cnn = new SqlConnection(txtReopenCnnString.Text.Trim()))
                    {
                        ShowStatusMessage("Calling OpenWithRetry()...");
                        cnn.OpenWithRetry(retry, delay);
                        msg = "cnn.AccessToken = [" + cnn.AccessToken + "]\n";
                        if (cnn.ClientConnectionId != null)
                            msg += "cnn.ClientConnectionId = [" + cnn.ClientConnectionId.ToString() + "]\n";
                        msg += "cnn.ConnectionTimeout = [" + cnn.ConnectionTimeout.ToString() + "]\n";
                        if (cnn.Credential != null)
                        {
                            msg += "cnn.Credential.UserId = [" + cnn.Credential.UserId + "]\n";
                            msg += "cnn.Credential.Password = [" + cnn.Credential.Password + "]\n";
                        }
                        msg += "cnn.Database = [" + cnn.Database + "]\n";
                        msg += "cnn.DataSource = [" + cnn.DataSource + "]\n";
                        msg += "cnn.FireInfoMessageEventOnUserErrors = [" + cnn.FireInfoMessageEventOnUserErrors.ToString() + "]\n";
                        msg += "cnn.PacketSize = [" + cnn.PacketSize.ToString() + "]\n";
                        msg += "cnn.ServerVersion = [" + cnn.ServerVersion + "]\n";
                        msg += "cnn.State = [" + cnn.State.ToString() + "]\n";
                        msg += "cnn.StatisticsEnabled = [" + cnn.StatisticsEnabled.ToString() + "]\n";
                        msg += "cnn.WorkstationId = [" + cnn.WorkstationId + "]\n";
                        MessageBox.Show(msg, "OpenWithRetry", MessageBoxButtons.OK, MessageBoxIcon.None);
                        cnn.Close();
                    }
                }
                catch (Exception ex)
                {
                    msg = "Exception:\n";
                    msg += "Source=[" + ex.Source + "]\n";
                    msg += "Message=[" + ex.Message + "]\n";

                    MessageBox.Show(msg, "OpenWithRetry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    ShowStatusMessage("");
                }
            }
        }
    }
}
