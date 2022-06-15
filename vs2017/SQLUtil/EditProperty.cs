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
        private String propValue { get; set; }

        private bool returnCode { get; set; }

        public EditProperty()
        {
            InitializeComponent();
            propValue = string.Empty;
            returnCode = false;
            Visible = false;
        }

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

        private void btnOK_Click(object sender, EventArgs e)
        {
            propValue = txtValue.Text.Trim();
            returnCode = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            returnCode = false;
            Close();
        }
    }
}
