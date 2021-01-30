using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSPs.Models
{
    public class BusStop
    {
        [Display(Name ="Постојка")]
        public string Name { get; set; }
        [Key]
        public int ID { get; set; }
        public List<Bus> Buses { get; set; }

        public BusStop() {
            Buses = new List<Bus>();
        }
        public BusStop(string name, int id,List<Bus> buses )
        {

            Name = name;
            ID = id;
            Buses = buses;
        }
    }
}