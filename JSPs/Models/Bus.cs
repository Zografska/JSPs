using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSPs.Models
{
    public class Bus
    {
        [Key]
        public int ID { get; set; }
        public string BusNo { get; set; }
        [Required]
        public int Capacity { get; set; }
        public  string BusLine { get; set; }
        public List<BusStop> BusStops { get; set; }
        //za kolku vrreme stiga do sledna postojka
        public List<int> NextStop { get; set; }

        [RegularExpression("^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]"), ]
        [Required]
        public string StartTime { get; set; }

        public Bus()
        {
            BusStops = new List<BusStop>();
        }

        public Bus(int id, int capacity, List<BusStop> busStops, string startTime)
        {
            ID = id;
            Capacity = capacity;
            BusStops = busStops;
            StartTime = startTime;
        }


    }
}