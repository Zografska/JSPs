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
        [Range(0, 50, ErrorMessage = "Автобусите со кои ние располагаме имаат максимален капацитет 50")]
        
        public int Capacity { get; set; }

        [Required]
        public string BusLine { get; set; }
        public List<BusStop> BusStops { get; set; }
        //za kolku vrreme stiga do sledna postojka
        public List<int> NextStop { get; set; }
        [Required]
        [Display(Name ="Hour")]
        public DateTime StartTime { get; set; }

        public Bus()
        {
            BusStops = new List<BusStop>();
        }

        public Bus(int id, int capacity, List<BusStop> busStops, DateTime startTime)
        {
            ID = id;
            Capacity = capacity;
            BusStops = busStops;
            StartTime = startTime;
        }


    }
}
