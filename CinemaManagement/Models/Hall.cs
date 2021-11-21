using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Hall
    {
        public Hall() { }
        
        public Hall(int Hid, int Ccount, int RCount)
        {
            this.HallId = Hid;
            this.ColumsCount = Ccount;
            this.RowsCount = RCount;
        }
        public int HallId { get; set; }
        public int ColumsCount { get; set; }
        public int RowsCount { get; set; }
    }

    public class DetailedHall
    {
        public DetailedHall() { }
        public DetailedHall(Hall hall)
        {
            this.Hall = hall;
        }
        public Hall Hall { get; set; }
        public string MovieName { get; set; }

        public override string ToString()
        {
            return "Hall #" + Hall.HallId + ", seats: " + (Hall.ColumsCount*Hall.RowsCount).ToString();
        }
    }
}
