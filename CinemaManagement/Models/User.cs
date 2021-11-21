using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        public User() { }
        public User(int uID, string fname, string lname, string log, string pwd)
        {
            UserId = uID;
            FirstName = fname;
            LastName = lname;
            Login = log;
            Password = pwd;
        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        private static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }
        private static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }
        private static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }

        private int key = 4;

        public User Decipher()
        {
            string FstNm = Decipher(this.FirstName, key);
            string LstNm = Decipher(this.LastName, key);
            User decipheredUser = new User(this.UserId, FstNm, LstNm, this.Login, this.Password);
            return decipheredUser;
        }

        public User Encipher()
        {
            string FstNm = Encipher(this.FirstName, key);
            string LstNm = Encipher(this.LastName, key);
            User encipheredUser = new User(this.UserId, FstNm, LstNm, this.Login, this.Password);
            return encipheredUser;
        }

        public string generateHash(string value)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes("bezpieczeństwo" + value);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }
    }
}
