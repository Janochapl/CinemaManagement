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
    public partial class FormManaging : Form
    {
        string Type = null;
        Worker worker = new Worker();
        protected string Username = null;
        protected bool IsWorker = false;
        public FormManaging()
        {
            InitializeComponent();
        }

        public FormManaging(string type, string usrn, bool isWr)
        {
            InitializeComponent();
            this.Type = type;
            this.Username = usrn;
            this.IsWorker = isWr;
            labelTitle.Text = "Menaging " + type;
        }

        private void FormManaging_Load(object sender, EventArgs e)
        {
            refreshListBox();
        }

        private void refreshListBox()
        {
            switch (Type)
            {
                case "halls":
                    listBoxManage.DataSource = worker.generateDetailedHallsList();
                    break;

                case "movies":
                    listBoxManage.DataSource = worker.generateDetailedMoviesList();
                    break;

                case "showings":
                    listBoxManage.DataSource = worker.generateDetailedShowingsList();
                    break;

                case "reservations":
                    var fullList = worker.generateDetailedReservationsList();
                    List<DetailedReservation> personalList = new List<DetailedReservation>();
                    if (IsWorker)
                    {
                        listBoxManage.DataSource = fullList;
                    }
                    else 
                    {
                        int customerId = worker.getUserWithUsername(Username, IsWorker).UserId;
                        foreach (var item in fullList)
                        {
                            DetailedReservation TypedItem = (DetailedReservation)item;
                            if (TypedItem.Reservation.CustomerId == customerId)
                            {
                                personalList.Add(TypedItem);
                            }
                        }
                        listBoxManage.DataSource = personalList;
                    }
                    
                    break;

                default:
                    break;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var item = listBoxManage.SelectedItem;

            switch (item)
            {
                case DetailedMovie dMv:
                    worker.deleteObjectWithId("movies", dMv.Movie.MovieId);
                    break;

                case DetailedReservation dRes:
                    worker.deleteObjectWithId("reservations", dRes.Reservation.ReservationId);
                    break;

                case DetailedShowing dShow:
                    worker.deleteObjectWithId("showings", dShow.Show.ShowingId);
                    break;

                case DetailedHall dHall:
                    worker.deleteObjectWithId("halls", dHall.Hall.HallId);
                    break;

                default:
                    ShowDialog();
                    break;
            }

            refreshListBox();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddEdit frmAddEdit = new FormAddEdit(Type, false, Username, IsWorker);
            frmAddEdit.Tag = this;
            frmAddEdit.Show(this);
            this.Hide();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            FormAddEdit frmAddEdit = new FormAddEdit(Type, true, Username, IsWorker, listBoxManage.SelectedItem);
            frmAddEdit.Tag = this;
            frmAddEdit.Show(this);
            this.Hide();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            var frm2 = (Form2)Tag;
            frm2.Show();
            Close();
        }

        private void FormManaging_Shown(object sender, EventArgs e)
        {
            refreshListBox();
        }

        private void FormManaging_VisibleChanged(object sender, EventArgs e)
        {
            refreshListBox();
        }
    }
}
