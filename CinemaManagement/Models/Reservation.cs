using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Reservation
    {
        public Reservation(int Resid, int Sid, int Cid, int Rid, int Cmrid, int CrAt)
        {
            this.ReservationId = Resid;
            this.ShowingId = Sid;
            this.ColumnId = Cid;
            this.RowId = Rid;
            this.CustomerId = Cmrid;
            this.CreatedAt = CrAt;
        }
        public Reservation()
        {

        }
        public int ReservationId { get; set; }
        public int ShowingId { get; set; }
        public int ColumnId { get; set; }
        public int RowId { get; set; }
        public int CustomerId { get; set; }
        public int CreatedAt { get; set; }
    }

    public class DetailedReservation
    {
        public DetailedReservation() { }
        public DetailedReservation(Reservation res, User usr, Movie mv, Showing show)
        {
            this.Reservation = res;
            this.User = usr;
            this.Movie = mv;
            this.Showing = show;
        }
        public Reservation Reservation { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }
        public Showing Showing { get; set; }

        public override string ToString()
        {
            return "#" + Reservation.ReservationId + 
                ", Date: " + DateTimeOffset.FromUnixTimeSeconds(Showing.Time).DateTime.ToLocalTime() +
                ", Movie: " + Movie.Name +
                ", Last Name: " + User.Decipher().LastName +
                ", Column: " + Reservation.ColumnId +
                ", Row: " + Reservation.RowId +
                ", Hall: " + Showing.HallId;
        }
    }
}
