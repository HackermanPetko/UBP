using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace Daemon
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string token = GetToken(new User() { Username = this.textBox1.Text, Password = this.textBox2.Text });
            this.label3.Text = token;
        }

        private static async Task<string> Login(User user)
        {
            HttpClient client = new HttpClient();


            // předání tokenu
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyNDU3OTk5MiwiZXhwIjoxNTMzMjE5OTkyLCJpYXQiOjE1MjQ1Nzk5OTIsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.fL0lsgNQ4I-eMtCxCcA_9BPzFhoxOk8F0OWLxqrCr5Y");

            HttpResponseMessage response = await client.PostAsJsonAsync($"http://localhost:63699/api/config/",user);
            string token = response.Content.ToString();


            return token;

        }

        public static string GetToken(User user)
        {
            var task = Login(user);
            task.Wait();
            string config = task.Result;

            return config;
        }
    }
}
