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
    public partial class FormAddEdit : Form
    {
        protected string Type = null;
        protected bool EditMode = false;
        protected string Username = null;
        protected bool IsWorker = false;
        protected object CurrentObject;
        Worker worker = new Worker();

        ComboBox showing = new ComboBox();
        NumericUpDown row = new NumericUpDown();
        NumericUpDown column = new NumericUpDown();
        TextBox movie = new TextBox();
        NumericUpDown duration = new NumericUpDown();
        NumericUpDown hall = new NumericUpDown();
        ComboBox movieCB = new ComboBox();
        ComboBox hallCB = new ComboBox();
        DateTimePicker dateTime = new DateTimePicker();
        public FormAddEdit(string type, bool edit_mode, string usrn, bool iswrk, object obj = null)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Type = type;
            this.EditMode = edit_mode;
            this.CurrentObject = obj;
            SelectType(type);
        }

        public void SelectType(string t)
        {
            switch (t)
            {
                case "reservations":
                    if (!EditMode) CurrentObject = new DetailedReservation();
                    initializeReservations();
                    break;

                case "movies":
                    if (!EditMode) CurrentObject = new DetailedMovie();
                    initializeMovies();
                    break;

                case "halls":
                    if (!EditMode) CurrentObject = new DetailedHall();
                    initializeHalls();
                    break;

                case "showings":
                    if (!EditMode) CurrentObject = new DetailedShowing();
                    initializeShowings();
                    break;

                default:
                    break;
                   
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            switch (Type)
            {
                case "reservations":
                    saveReservation();
                    break;

                case "movies":
                    saveMovie();
                    break;

                case "halls":
                    saveHalls();
                    break;

                case "showings":
                    saveShowings();
                    break;

                default:
                    break;

            }
            var frmManaging = (FormManaging)Tag;
            frmManaging.Show();
            Close();
        }


        public void initializeReservations()
        {
            label1.Text = "Showing";
            showing.Dock = DockStyle.Fill;
            showing.Anchor = AnchorStyles.None;
            var Shows = worker.generateDetailedShowingsList();
            showing.DataSource = Shows;
            tableLayoutPanel1.Controls.Add(showing, 2, 0);

            label2.Text = "Row";
            row.Dock = DockStyle.Fill;
            row.Anchor = AnchorStyles.None;
            row.Minimum = 1;
            row.DecimalPlaces = 0;
            tableLayoutPanel1.Controls.Add(row, 2, 1);

            label3.Text = "Column";
            column.Dock = DockStyle.Fill;
            column.Anchor = AnchorStyles.None;
            column.Minimum = 1;
            column.DecimalPlaces = 0;
            tableLayoutPanel1.Controls.Add(column, 2, 2);

            if (EditMode && CurrentObject.GetType() == typeof(DetailedReservation))
            {
                DetailedReservation TypedCurrentObject = (DetailedReservation)CurrentObject;
                var actualShowing = new DetailedShowing(TypedCurrentObject.Showing, TypedCurrentObject.Movie.Name);
                showing.SelectedIndex = showing.Items.IndexOf(actualShowing.ToString());
                row.Value = TypedCurrentObject.Reservation.RowId;
                column.Value = TypedCurrentObject.Reservation.ColumnId;
                var currentHall = worker.getObjectWithId("halls", TypedCurrentObject.Showing.HallId);
                if (currentHall.GetType() == typeof(Hall))
                {
                    Hall TypedCurrentHall = (Hall)currentHall;
                    row.Maximum = TypedCurrentHall.RowsCount;
                    column.Maximum = TypedCurrentHall.ColumsCount;
                }
                else objectIsIncorrent();
            }
        }

        public void initializeMovies()
        {
            label1.Text = "Movie";
            movie.Dock = DockStyle.Fill;
            movie.Anchor = AnchorStyles.None;
            tableLayoutPanel1.Controls.Add(movie, 2, 0);

            label2.Text = "Duration";
            duration.Dock = DockStyle.Fill;
            duration.Anchor = AnchorStyles.None;
            duration.Minimum = 1;
            duration.DecimalPlaces = 0;
            tableLayoutPanel1.Controls.Add(duration, 2, 1);

            label3.Text = "";

            if (EditMode)
            {
                DetailedMovie TypedCurrentObject = (DetailedMovie)CurrentObject;
                movie.Text = TypedCurrentObject.Movie.Name;
                duration.Value = TypedCurrentObject.Movie.Duration;
            }
        }

        public void initializeHalls()
        {
            label1.Text = "Hall";
            hall.Dock = DockStyle.Fill;
            hall.Anchor = AnchorStyles.None;
            hall.Minimum = 1;
            hall.DecimalPlaces = 0;
            tableLayoutPanel1.Controls.Add(hall, 2, 0);

            label2.Text = "Rows";
            row.Dock = DockStyle.Fill;
            row.Anchor = AnchorStyles.None;
            row.Minimum = 1;
            row.DecimalPlaces = 0;
            tableLayoutPanel1.Controls.Add(row, 2, 1);

            label3.Text = "Columns";
            column.Dock = DockStyle.Fill;
            column.Anchor = AnchorStyles.None;
            column.Minimum = 1;
            column.DecimalPlaces = 0;
            tableLayoutPanel1.Controls.Add(column, 2, 2);

            if (EditMode)
            {
                DetailedHall TypedCurrentObject = (DetailedHall)CurrentObject;
                hall.Value = TypedCurrentObject.Hall.HallId;
                row.Value = TypedCurrentObject.Hall.RowsCount;
                column.Value = TypedCurrentObject.Hall.ColumsCount;
            }
        }

        public void initializeShowings()
        {
            label1.Text = "Movie";
            movieCB.Dock = DockStyle.Fill;
            movieCB.Anchor = AnchorStyles.None;
            var movies = worker.generateDetailedMoviesList();
            var bindingDataSource = new BindingSource();
            bindingDataSource.DataSource = movies;
            movieCB.BindingContext = new BindingContext();
            movieCB.DataSource = bindingDataSource;
            tableLayoutPanel1.Controls.Add(movieCB, 2, 0);

            label2.Text = "Hall";
            hallCB.Dock = DockStyle.Fill;
            hallCB.Anchor = AnchorStyles.None;
            var halls = worker.generateDetailedHallsList();
            var bindingDataSourceHL = new BindingSource();
            bindingDataSourceHL.DataSource = halls;
            hallCB.BindingContext = new BindingContext();
            hallCB.DataSource = bindingDataSourceHL;
            tableLayoutPanel1.Controls.Add(hallCB, 2, 1);

            label3.Text = "Date";
            dateTime.Dock = DockStyle.Fill;
            dateTime.Anchor = AnchorStyles.None;
            dateTime.Format = DateTimePickerFormat.Custom;
            dateTime.CustomFormat = "dd/MM/yyyy HH:mm";
            tableLayoutPanel1.Controls.Add(dateTime, 2, 2);
            dateTime.Value = DateTime.Now.ToLocalTime();
            if (EditMode)
            {
                DetailedShowing TypedCurrentObject = (DetailedShowing)CurrentObject;

                var actualMovie = worker.getObjectWithId("movies", TypedCurrentObject.Show.MovieId);
                DetailedMovie TypedActualMovie = new DetailedMovie((Movie)actualMovie);
                foreach (var item in movieCB.Items)
                { 
                    DetailedMovie TypedItem = (DetailedMovie)item;
                    if (TypedItem.Movie.MovieId == TypedCurrentObject.Show.MovieId)
                    {
                        movieCB.SelectedItem = item;
                        
                    }
                }

                var actualHall = worker.getObjectWithId("halls", TypedCurrentObject.Show.HallId);
                DetailedHall TypedActualHall = new DetailedHall((Hall)actualHall);
                foreach (var item in hallCB.Items)
                {
                    DetailedHall TypedItem = (DetailedHall)item;
                    if (TypedItem.Hall.HallId == TypedCurrentObject.Show.HallId)
                    {
                        hallCB.SelectedItem = item;

                    }
                }

                dateTime.Value = DateTimeOffset.FromUnixTimeSeconds(TypedCurrentObject.Show.Time).DateTime.ToLocalTime();
            }
        }

        public void saveReservation()
        {
            DetailedReservation TypedCurrentObject = (DetailedReservation)CurrentObject;
            if (EditMode)
            {
                TypedCurrentObject.Reservation.RowId = Convert.ToInt32(row.Value);
                TypedCurrentObject.Reservation.ColumnId = Convert.ToInt32(column.Value);
                var loRes = worker.generateDetailedReservationsList();
                foreach(DetailedReservation res in loRes)
                {
                    if (res.Reservation.ColumnId==TypedCurrentObject.Reservation.ColumnId && 
                        res.Reservation.RowId==TypedCurrentObject.Reservation.RowId && 
                        (res.Reservation.ReservationId!=TypedCurrentObject.Reservation.ReservationId))
                    {
                        var rowErrorProvider = new ErrorProvider();
                        rowErrorProvider.SetIconAlignment(this.row, ErrorIconAlignment.MiddleRight);
                        rowErrorProvider.SetIconPadding(this.row, 2);
                        rowErrorProvider.BlinkRate = 1000;
                        rowErrorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;

                        var columnErrorProvider = new ErrorProvider();
                        columnErrorProvider.SetIconAlignment(this.column, ErrorIconAlignment.MiddleRight);
                        columnErrorProvider.SetIconPadding(this.column, 2);
                        columnErrorProvider.BlinkRate = 1000;
                        columnErrorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;

                        rowErrorProvider.SetError(this.row, "Seat is occupied!");
                        columnErrorProvider.SetError(this.column, "Seat is occupied!");
                        return;

                    }
                }
                var loShow = worker.generateDetailedShowingsList();
                foreach(DetailedShowing show in loShow)
                {
                    if (show.ToString() == showing.SelectedItem.ToString())
                    {
                        TypedCurrentObject.Showing = show.Show;
                    }
                }
                Reservation reservation = new Reservation(TypedCurrentObject.Reservation.ReservationId,
                    TypedCurrentObject.Showing.ShowingId,
                    TypedCurrentObject.Reservation.ColumnId,
                    TypedCurrentObject.Reservation.RowId,
                    TypedCurrentObject.Reservation.CustomerId,
                    TypedCurrentObject.Reservation.CreatedAt);
                buttonSave.Text = worker.putReservation(reservation);
            }
            else
            {
                Reservation reservation = new Reservation();
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                reservation.CreatedAt = unixTimestamp;

                int customerId = worker.getUserWithUsername(Username, IsWorker).UserId;

                reservation.RowId = Convert.ToInt32(row.Value);

                reservation.ColumnId = Convert.ToInt32(column.Value);

                var loRes = worker.generateDetailedReservationsList();
                foreach (DetailedReservation res in loRes)
                {
                    if (res.Reservation.ColumnId == reservation.ColumnId &&
                        res.Reservation.RowId == reservation.RowId &&
                        (res.Reservation.ReservationId != reservation.ReservationId) &&
                        (res.Reservation.ShowingId==reservation.ShowingId))
                    {
                        var rowErrorProvider = new ErrorProvider();
                        rowErrorProvider.SetIconAlignment(this.row, ErrorIconAlignment.MiddleRight);
                        rowErrorProvider.SetIconPadding(this.row, 2);
                        rowErrorProvider.BlinkRate = 1000;
                        rowErrorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;

                        var columnErrorProvider = new ErrorProvider();
                        columnErrorProvider.SetIconAlignment(this.column, ErrorIconAlignment.MiddleRight);
                        columnErrorProvider.SetIconPadding(this.column, 2);
                        columnErrorProvider.BlinkRate = 1000;
                        columnErrorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;

                        rowErrorProvider.SetError(this.row, "Seat is occupied!");
                        columnErrorProvider.SetError(this.column, "Seat is occupied!");
                        return;

                    }
                }

                reservation.ShowingId = 1;
                var loShow = worker.generateDetailedShowingsList();
                foreach (DetailedShowing show in loShow)
                {
                    if (show.ToString() == showing.SelectedItem.ToString())
                    {
                        reservation.ShowingId = show.Show.ShowingId;
                    }
                }
                reservation.CustomerId = customerId;
                worker.postReservation(reservation);


            }
            

        }
        public void saveMovie()
        {
            //movie duration
            DetailedMovie TypedCurrentObject = (DetailedMovie)CurrentObject;
            Movie Movie = new Movie();
            Movie.Duration = Convert.ToInt32(duration.Value);
            Movie.Name = movie.Text;

            if (EditMode)
            {
                Movie.MovieId = TypedCurrentObject.Movie.MovieId;
                worker.putMovie(Movie);
            }
            else
            {
                worker.postMovie(Movie);
            }
        }
        public void saveHalls()
        {
            DetailedHall TypedCurrentObject = (DetailedHall)CurrentObject;
            Hall Hall = new Hall();
            Hall.RowsCount = Convert.ToInt32(row.Value);
            Hall.ColumsCount = Convert.ToInt32(column.Value);
            if (EditMode)
            {
                Hall.HallId = TypedCurrentObject.Hall.HallId;
                worker.putHall(Hall);
            }
            else
            {
                worker.postHall(Hall); 
            }
        }
        public void saveShowings()
        {
            DetailedShowing TypedCurrentObject = (DetailedShowing)CurrentObject;

            Showing showing = new Showing();

            var itemMovie = movieCB.SelectedItem;
            DetailedMovie TypedItemMovie = (DetailedMovie)itemMovie;
            showing.MovieId = TypedItemMovie.Movie.MovieId;

            var itemHall = hallCB.SelectedItem;
            DetailedHall TypedItemHall = (DetailedHall)itemHall;
            showing.HallId = TypedItemHall.Hall.HallId;

            var time = dateTime.Value.ToLocalTime();
            showing.Time = Convert.ToInt32(((DateTimeOffset)time).ToUnixTimeSeconds());

            if (EditMode)
            {
                showing.ShowingId = TypedCurrentObject.Show.ShowingId;
                worker.putShowing(showing);
            }
            else 
            {
                worker.postShowing(showing);
            }
        }

        public void objectIsIncorrent()
        {

        }

        public void exitForm()
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frmManaging = (FormManaging)Tag;
            frmManaging.Show();
            Close();
        }
    }
}
