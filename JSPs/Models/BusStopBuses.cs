using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSPs.Models
{
    public class BusStopBuses
    {
        //[Key]
        public int BusStopId { get; set; }
        public int BusId { get; set; }
        public BusStop BusStop { get; set; }
        public List<Bus> Buses { get; set; }
        public BusStopBuses() {
            Buses = new List<Bus>();
        }

    }
}