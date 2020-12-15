using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSPs.Models
{
    public class BusBusStops
    {
        public int BusStopId { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public List<BusStop> BusStops { get; set; }
        public BusBusStops()
        {
            BusStops = new List<BusStop>();
        }
    }
}