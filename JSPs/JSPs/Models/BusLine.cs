using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSPs.Models
{
    public class BusLine
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BusStop> BusStops { get; set; }

        public BusLine()
        {
            BusStops = new List<BusStop>();
        }
    }
}
