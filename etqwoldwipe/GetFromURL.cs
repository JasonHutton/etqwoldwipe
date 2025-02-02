using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Media;

namespace etqwoldwipe
{
    public partial class GetFromURL : Form
    {
        public GetFromURL()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!cbURLtoGet.Text.Equals(""))
            {
                this.DialogResult = DialogResult.OK;
                cbURLtoGet.Items.Add(cbURLtoGet.Text);
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }

        public string getURLText()
        {
            return cbURLtoGet.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void GetFromURL_Shown(object sender, EventArgs e)
        {
            cbURLtoGet.Select();
            cbURLtoGet.SelectAll();
        }
    }
}
