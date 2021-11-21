using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using WebApplication1.Models;

namespace CinemaManagement
{
    public partial class Form2 : Form
    {
        protected const string API_URL = "http://localhost:49146";
        protected string username = null;
        protected bool isWorker = false;
        Worker worker = new Worker();
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string usrn, bool isWr)
        {
            InitializeComponent();
            username = usrn;
            isWorker = isWr;
            labelUsername.Text += username;
            if (!isWr)
            {
                labelWorker.Text = "Account Type: Customer";
                buttonManageFilms.Visible = false;
                buttonManageHalls.Visible = false;
                buttonManageShowings.Visible = false;
            }
            else
            {
                labelWorker.Text = "Account Type: Worker";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormChangeAccount frmChangeAccount = new FormChangeAccount(username, isWorker);
            frmChangeAccount.Tag = this;
            frmChangeAccount.Show(this);
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listBoxShowings.DataSource = worker.generateDetailedShowingsList();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openManaging(string type)
        {
            FormManaging frManaging = new FormManaging(type, username, isWorker);
            frManaging.Tag = this;
            frManaging.Show(this);
            this.Hide();
        }

        private void buttonManageHalls_Click(object sender, EventArgs e)
        {
            openManaging("halls");
        }

        private void buttonManageRevervations_Click(object sender, EventArgs e)
        {
            openManaging("reservations");
        }

        private void buttonManageShowings_Click(object sender, EventArgs e)
        {
            openManaging("showings");
        }

        private void buttonManageFilms_Click(object sender, EventArgs e)
        {
            openManaging("movies");
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            var frm1 = (Logowanie)Tag;
            frm1.Show();
            Close();
        }

        /*private List<string> generateReservationsList()
        {
            List<string> reservationList;
            var loShowings = getShowings();
            var loMovies = getMovies();
            var loHalls = getHalls();
            var loReservations = getReservation();

            return reservationList;
        }*/
    }
    }
