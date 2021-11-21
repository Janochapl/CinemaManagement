using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace CinemaManagement
{
    public partial class Logowanie : Form
    {
        protected const string API_URL = "http://localhost:49146";
        public Logowanie()
        {
            InitializeComponent();
        }

        private static string GenerateHash(string value)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes("bezpieczeństwo" + value);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/customers";
            if (checkBoxIfWorker.Checked)
            {
                api_url = API_URL + "/api/workers";
            }
            rClient.endPoint = api_url;
            string strResponse = string.Empty;
            strResponse = rClient.makeRequest();
            if (strResponse==string.Empty)
            {
                return;
            }
            using JsonDocument doc = JsonDocument.Parse(strResponse);
            JsonElement root = doc.RootElement;
            var users = root.EnumerateArray();
            var hash = GenerateHash(textBoxPassword.Text);
            while (users.MoveNext())
            {
                var user = users.Current;
                if ((textBoxUsername.Text == user.GetProperty("login").ToString()) && (hash == user.GetProperty("password").ToString())) 
                {
                    textBoxUsername.Text = "";
                    textBoxPassword.Text = "";
                    Form2 frm2 = new Form2(textBoxUsername.Text, checkBoxIfWorker.Checked);
                    frm2.Tag = this;
                    frm2.Show(this);
                    this.Hide();
                }
            }
            Console.WriteLine(strResponse);
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            Form1 frmRegister = new Form1();
            frmRegister.Tag = this;
            frmRegister.Show(this);
            this.Hide();
        }
    }
}
