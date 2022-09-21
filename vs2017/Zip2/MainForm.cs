using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zip2
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Default constructor of MainForm.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }   // MainForm();

        /// <summary>
        /// 指定目標壓縮檔。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDestZip_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.AddExtension = true;
            this.saveFileDialog1.CreatePrompt = true;
            this.saveFileDialog1.DefaultExt = "zip";
            this.saveFileDialog1.Filter = "Zip files (*.zip)|*.zip|All files (*.*)|*.*";
            this.saveFileDialog1.FilterIndex = 1;
            this.saveFileDialog1.Title = "Save to Zip file...";

            DialogResult drc = this.saveFileDialog1.ShowDialog();

            if (DialogResult.OK == drc)
            {
                this.txtDestZip.Text = this.saveFileDialog1.FileName;
                Debug.WriteLine("DestZip=[" + this.txtDestZip.Text + "]");
            }
        }   // btnDestZip_Click();

        /// <summary>
        /// 選擇檔案加入到要壓縮的清單。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.CheckFileExists = true;
            this.openFileDialog1.Filter = "All files (*.*)|*.*";
            this.openFileDialog1.FilterIndex = 1;
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.ReadOnlyChecked = true;
            this.openFileDialog1.ShowReadOnly = true;
            this.openFileDialog1.Title = "Select files to add to zip...";
            this.openFileDialog1.ValidateNames = true;

            DialogResult drc = this.openFileDialog1.ShowDialog();

            if (DialogResult.OK == drc)
            {
                foreach (string filename in this.openFileDialog1.FileNames)
                {
                    if (!this.lvSrcFiles.Items.ContainsKey(filename))   // 檢查Key值以避免重複加入。
                    {
                        Debug.WriteLine("Add [" + filename + "] to SrcFiles");
                        this.lvSrcFiles.Items.Add(filename, filename, 0);   // 用檔名本身當Key值。
                    }
                }
            }
        }   // btnAddFile_Click();

        /// <summary>
        /// 從待壓縮清單中移除檔案。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveFiles_Click(object sender, EventArgs e)
        {
            if (this.lvSrcFiles.SelectedIndices.Count > 0)
            {
                for (int i = this.lvSrcFiles.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    Debug.WriteLine("Remove SrcFiles[" + this.lvSrcFiles.SelectedIndices[i].ToString() + "]");
                    this.lvSrcFiles.Items.RemoveAt(this.lvSrcFiles.SelectedIndices[i]);
                }
            }
        }   // btnRemoveFiles_Click();

        /// <summary>
        /// 產生(及驗證)目標壓縮檔。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZip_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtDestZip.Text) && (this.lvSrcFiles.Items.Count > 0))
            {
                if (File.Exists(this.txtDestZip.Text))
                {
                    DialogResult drc = MessageBox.Show(this.txtDestZip.Text + " already exist, overwirte?", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (DialogResult.Cancel == drc)
                        return;
                }

                List<string> files = new List<string>();

                for (int i = 0; i < this.lvSrcFiles.Items.Count; i++)
                    files.Add(this.lvSrcFiles.Items[i].Text);

                bool brc = Zip.CreateZip(this.txtDestZip.Text, files, this.chkVerifyZip.Checked);

                if (brc)
                    MessageBox.Show("Zip file created successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                else
                    MessageBox.Show("Failure createing zip file.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // btnZip_Click();

        /// <summary>
        /// 檢查目標壓縮檔是否為合法壓縮檔。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.txtDestZip.Text))
            {
                try
                {
                    bool brc = Ionic.Zip.ZipFile.CheckZip(this.txtDestZip.Text);
                    MessageBox.Show("CheckZip() = " + brc.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Common.GetExceptionString(ex), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this.txtDestZip.Text + " not found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


    }   // MainForm
}   // Zip2
