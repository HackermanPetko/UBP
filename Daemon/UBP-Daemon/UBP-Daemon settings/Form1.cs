using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            Settings.Get();
            tbserver.Text = Settings.server;

            tbuser.Text = Settings.user;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(@"C:\UBP");
            Settings.server = tbserver.Text;
            Settings.user = tbuser.Text;
            Settings.password = tbpw.Text;
            Settings.token = null;
            Settings.Upload();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
