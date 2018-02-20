using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Timers;


namespace WindowsFormsApplication10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buton_Send_Click(object sender, EventArgs e)
        {
            //jaká služba se bude využít -> gmail
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            //šifrování
                client.EnableSsl = true;
            //čas trvání dokud se zpráva neodešle jinak neodejde
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //Ověření
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("testsendmailing@gmail.com", "Abc0123456789");
            //Zpráva
            MailMessage msg = new MailMessage();
            //od Koho
            msg.From = new MailAddress("testsendmailing@gmail.com");
            // Komu se doručí
            msg.To.Add(textBox_Email.Text);
            //Předmět
                msg.Subject = textBox_Subject.Text;
            //obsah zprávy
                msg.Body = textBox_Message.Text;
                client.Send(msg);
            
        }

    }
}
