using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WebApplication1.Models;

namespace CinemaManagement
{
    public partial class Form1 : Form
    {
        protected const string API_URL = "http://localhost:49146";
        public Form1()
        {
            InitializeComponent();
        }
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

        private void button1_Click(object sender, EventArgs e)
        {
            string api_url = API_URL;
            if (textBoxPIN.Text=="1234")
            {
                api_url += "/api/workers";
            }
            else if (textBoxPIN.Text!="")
            {
                var pinErrorProvider = new ErrorProvider();
                pinErrorProvider.SetIconAlignment(this.textBoxPIN, ErrorIconAlignment.MiddleRight);
                pinErrorProvider.SetIconPadding(this.textBoxPIN, 2);
                pinErrorProvider.BlinkRate = 1000;
                pinErrorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                pinErrorProvider.SetError(this.textBoxPIN, "PIN is wrong!");
                return;
            }
            else if (textBoxPIN.Text=="")
            {
                api_url += "/api/customers";
            }
            string first_name = textBoxFirst_Name.Text;
            string last_name = textBoxLast_Name.Text;
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            string enc_first_name = Encipher(first_name, 4);
            string enc_last_name = Encipher(last_name, 4);
            string enc_password = GenerateHash(password);

            RestClient rClient = new RestClient();
            rClient.endPoint = api_url;
            rClient.httpMethod = httpVerb.POST;
            string strResponse = string.Empty;
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"FirstName",  enc_first_name},
                {"LastName",  enc_last_name},
                {"Login",  username},
                {"Password",  enc_password}
            };
            strResponse = rClient.makePost(postData);
            labelRegisterResult.Text = strResponse;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var frm1 = (Logowanie)Tag;
            frm1.Show();
            this.Close();
        }
    }
}
