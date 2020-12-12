using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSPs.Models
{
    public class BusBusStops
    {
        [Key]
        public int BusId { get; set; }
        public int BusStopId { get; set; }
        public List<BusStop> BusStops { get; set; }
        public Bus Bus { get; set; }
        public BusBusStops()
        {
            BusStops = new List<BusStop>();
        }
    }
}