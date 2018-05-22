using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UBP_Daemon_settings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tbserver.Text = Settings1.Default.server;

            tbuser.Text = Settings1.Default.user;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings1.Default.server = tbserver.Text;
            Settings1.Default.user = tbuser.Text;
            Settings1.Default.password = tbpw.Text;
            Settings1.Default.Save();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
