using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XMLTool
{
    public partial class MainForm : Form
    {
        XmlDocument _xmlDoc = new XmlDocument();
        XmlNamespaceManager _xmlNSMgr;

        /// <summary>
        /// 顯示作業進度訊息。
        /// </summary>
        /// <param name="message"></param>
        private void AddProgressMessage(string message)
        {
            txtProgressMessage.Text += message + "\r\n";
        }   // AddProgressMessage();

        /// <summary>
        /// 顯示狀態訊息。
        /// </summary>
        /// <param name="message"></param>
        private void ShowStatusMessage(string message)
        {
            statusMessage.Text = message;
        }   // ShowStatusMessage();

        /// <summary>
        /// 以文字表示XML節點及其下所有節點。
        /// </summary>
        /// <param name="node"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        private string GetNodeTree(XmlNode node, string prefix)
        {
            string strTree = string.Empty;
            if (null != node)
            {
                string me;
                if (string.IsNullOrWhiteSpace(prefix))
                    me = node.Name;
                else
                    me = prefix + "." + node.Name;
                strTree += me + "\r\n";
                if (node.HasChildNodes)
                {
                    for (int i = 0; i < node.ChildNodes.Count; i++)
                        strTree += GetNodeTree(node.ChildNodes[i], me);
                }
            }
            return strTree;
        }   // GetNodeTree();

        /// <summary>
        /// 從檔案載入XML內容。
        /// </summary>
        /// <param name="filename"></param>
        private void LoadXML(string filename)
        {
            if (File.Exists(filename))
            {
                _xmlDoc.RemoveAll();
                _xmlDoc.Load(filename);
                AddProgressMessage("LoadXML(" + filename + ")");
                AddProgressMessage("_xmlDoc.HasChildNodes=[" + _xmlDoc.HasChildNodes.ToString() + "]");
                AddProgressMessage("_xmlDoc.ChildNodes.Count=[" + _xmlDoc.ChildNodes.Count.ToString() + "]");
                for (int i = 0; i < _xmlDoc.ChildNodes.Count; i++) 
                {
                    AddProgressMessage(GetNodeTree(_xmlDoc.ChildNodes[i], ""));
                }

                _xmlNSMgr = new XmlNamespaceManager(_xmlDoc.NameTable);
                Regex reg = new Regex("xmlns[:]?(?<prefix>.*?)\\s*=\\s*\"(?<uri>.*?)\"", RegexOptions.IgnoreCase);
                Match match = reg.Match(_xmlDoc.OuterXml);
                while (match.Success)
                {
                    string prefix = match.Groups["prefix"].Value;
                    string uri = match.Groups["uri"].Value;
                    AddProgressMessage("prefix=[" + prefix + "], uri=[" + uri + "]");
                    match = match.NextMatch();
                }

                statusFilename.Text = Path.GetFileName(filename);
                ShowStatusMessage("已從檔案" + filename + "載入。");
            }
        }   // LoadXML();

        private void SelectSingleNode(string xPath)
        {
            AddProgressMessage("SelectSingleNode(" + xPath + ")");
            XmlNode root = _xmlDoc.DocumentElement;
            XmlNode node = root.SelectSingleNode(xPath);
            if (null != node)
            {
                AddProgressMessage("node [" + node.Name + "] found.");
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.statusFilename.Text = "N/A";
        }

        /// <summary>
        /// 處理功能表Exit。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuLoadXML_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.CheckFileExists = true;
            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.ReadOnlyChecked = true;
            this.openFileDialog1.ShowReadOnly = true;
            DialogResult drc = this.openFileDialog1.ShowDialog();
            if (DialogResult.OK == drc)
            {
                LoadXML(this.openFileDialog1.FileName);
            }
        }

        private void txtSelectXPath1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                SelectSingleNode(txtSelectXPath1.Text);
            }
        }
    }
}
