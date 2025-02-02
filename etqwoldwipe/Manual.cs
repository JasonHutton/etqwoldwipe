using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace etqwoldwipe
{
    public partial class Manual : Form
    {
        public Manual()
        {
            InitializeComponent();
        }

        private void Manual_Load(object sender, EventArgs e)
        {
            txtManual.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                "ETQW Old Wipe\r\n",
                "Search searches for valid files in GamePath and UserPath.\r\n",
                "Compute calculates md5sums of all the found files.\r\n",
                "Load a set of MD5 hashes to compare them against the calculated hashes.\r\n",
                "Green files are official ETQW files and should not be touched. (Hidden from searches by default.)\r\n",
                "Yellow files are ambiguous: a hash has not been loaded for them to be compared with.\r\n",
                "Red files are hash conflicts. The loaded md5 hash and the computed md5 hash do not match.\r\n",
                "Black files are valid files. Their computed and loaded hashes match\r\n");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
