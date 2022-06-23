using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLUtil
{
    public partial class EditProperty : Form
    {
        /// <summary>
        /// 設定的屬性值內容。
        /// </summary>
        private String propValue { get; set; }

        /// <summary>
        /// 執行的結果，是否要回傳設定值。
        /// </summary>
        private bool returnCode { get; set; }

        /// <summary>
        /// 顯示EditProperty視窗，編輯設定值內容。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="inValue"></param>
        /// <param name="outValue"></param>
        /// <returns></returns>
        public bool Execute(String key, String inValue, out String outValue)
        {
            returnCode = false;
            propValue = inValue;
            lbKey.Text = key + ":";
            txtValue.Text = inValue;
            ShowDialog();
            outValue = propValue;
            return returnCode;
        }   // Execute();

        /// <summary>
        /// Default constructor of EditProperty.
        /// </summary>
        public EditProperty()
        {
            InitializeComponent();
            propValue = string.Empty;
            returnCode = false;
            Visible = false;
        }   // EditProperty();

        /// <summary>
        /// Event handler for Click event of btnOK.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// 關閉Dialog並回傳結果。
        /// </remarks>
        private void btnOK_Click(object sender, EventArgs e)
        {
            propValue = txtValue.Text.Trim();
            returnCode = true;
            Close();
        }   // btnOK_Click();

        /// <summary>
        /// Event handler for Click event of btnCancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// 關閉Dialog並回應取消 (returnCode=false)。
        /// </remarks>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            returnCode = false;
            Close();
        }   // btnCancel_Click();

        /// <summary>
        /// Event handler for KeyPress event of EditProperty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditProperty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Return == e.KeyChar)
            {
                // 按Enter視為點btnOK。
                e.Handled = true;
                btnOK_Click(sender, new EventArgs());
            }
            else if ((char)Keys.Escape == e.KeyChar)
            {
                // 按Escape視為點btnCancel。
                e.Handled = true;
                btnCancel_Click(sender, new EventArgs());
            }
            else
            {
                // 其他的pass下去給txtValue, btnOK和btnCancel處理。
                // Do nothing.
            }
        }   // EditProperty_KeyPress();

    }
}
