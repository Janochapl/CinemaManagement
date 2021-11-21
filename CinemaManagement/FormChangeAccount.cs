using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.Json;
using WebApplication1.Models;

namespace CinemaManagement
{
    public partial class FormChangeAccount : Form
    {
        protected const string API_URL = "http://localhost:49146";
        protected string username = null;
        protected bool isWorker = false;
        public User actualUser;

        private static string GenerateHash(string value)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes("bezpieczeństwo" + value);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }

        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }
        public static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }
        public static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }
        public FormChangeAccount()
        {
            InitializeComponent();
        }

        public FormChangeAccount(string usrn, bool isWr)
        {
            InitializeComponent();
            username = usrn;
            isWorker = isWr;
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/customers";
            if (isWr)
            {
                api_url = API_URL + "/api/workers";
            }
            rClient.endPoint = api_url;
            string strResponse = string.Empty;
            strResponse = rClient.makeRequest();

            using JsonDocument doc = JsonDocument.Parse(strResponse);
            JsonElement root = doc.RootElement;
            var users = root.EnumerateArray();
            while (users.MoveNext())
            {
                var user = users.Current;
                if ((username == user.GetProperty("login").ToString()))
                {
                    var first_name = Decipher( user.GetProperty("first_name").ToString(), 4);
                    var last_name = Decipher( user.GetProperty("last_name").ToString(), 4);
                    actualUser = new User(Int32.Parse(user.GetProperty("id").ToString()), first_name, last_name, user.GetProperty("login").ToString(), user.GetProperty("password").ToString());
                    textBoxFirst_Name.Text = actualUser.FirstName;
                    textBoxLast_Name.Text = actualUser.LastName;
                    textBoxUsername.Text = actualUser.Login;
                    labelID.Text = actualUser.UserId.ToString();
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User newDataUser;
            var hash = GenerateHash(textBoxPassword.Text);
            if (hash != actualUser.Password)
            {
                ErrorProvider errorProvider = new ErrorProvider();
                errorProvider.SetError(textBoxPassword, "Incorrect password");
                return;
            }
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"UserId",  actualUser.UserId},
                {"FirstName",  Encipher(textBoxFirst_Name.Text, 4)},
                {"LastName",  Encipher(textBoxLast_Name.Text, 4)},
                {"Login",  textBoxUsername.Text},
                {"Password",  hash}
            };
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/customers";
            if (isWorker) api_url = API_URL + "/api/workers";
            rClient.endPoint = api_url;
            rClient.httpMethod = httpVerb.PUT;
            string strResponse = string.Empty;
            strResponse = rClient.makePost(postData);
            labelResponse.Text = strResponse;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            this.Hide();
            frm2.Show();
        }

        private void buttonDeleteAccount_Click(object sender, EventArgs e)
        {
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/customers";
            if (isWorker) api_url = API_URL + "/api/workers";
            rClient.endPoint = api_url;
            rClient.httpMethod = httpVerb.DELETE;
            string strResponse = string.Empty;
            strResponse = rClient.deleteRecord(actualUser.UserId.ToString());
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }
    }
}
