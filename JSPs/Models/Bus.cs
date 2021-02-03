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
        
        [Display(Name ="Капацитет")]
        public int Capacity { get; set; }

        [Required]
        [Display(Name ="Линија")]
        public string BusLine { get; set; }

        [Display(Name ="Постојки")]
        public List<BusStop> BusStops { get; set; }
        //za kolku vrreme stiga do sledna postojka
        public List<int> NextStop { get; set; }

        [Required]
        [Display(Name ="Време на поаѓање")]
        [DisplayFormat(DataFormatString = "0:HH\\:mm")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        public Bus()
        {
            BusStops = new List<BusStop>();
        }

        public Bus(int id, int capacity, List<BusStop> busStops)
        {
            ID = id;
            Capacity = capacity;
            BusStops = busStops;
        }


    }
}
