using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Showing
    {
        public Showing() { }
        public Showing(int Sid, int unixTime, int Hid, int Mid)
        {
            this.ShowingId = Sid;
            this.Time = unixTime;
            this.HallId = Hid;
            this.MovieId = Mid;
        }
        public int ShowingId { get; set; }
        public int Time { get; set; }
        public int HallId { get; set; }
        public int MovieId { get; set; }
    }

    public class DetailedShowing
    {
        public DetailedShowing() { }
        public DetailedShowing(Showing show, string MvName)
        {
            this.Show = show;
            this.MovieName = MvName;
        }
        public Showing Show { get; set; }
        public string MovieName { get; set; }

        public override string ToString()
        {
            return DateTimeOffset.FromUnixTimeSeconds(Show.Time).DateTime.ToLocalTime() + "  " + MovieName;
        }
    }
    
}
