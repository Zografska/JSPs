using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSPs.Models
{
    // Model koj treba da se iskoristi za kreiranje na tiket 
    public class CreateTicketModel
    {

        [Display(Name ="Датум")]
        [Required]
        public DateTime Date { get; set; }

        //MISLAM DEKA TUKA TREBA STRING? poshto linija koa vnesuvame mislime na busLine

        [Required]
        public string LineName { get; set; }
        public int BusLineId { get; set; }

        public Bus Bus { get; set; }
        [Required]
        public int BusId { get; set; }
        [Required]
        public int StartBusStopId { get; set; }
        [Required]
        public int EndBusStopId { get; set; }
        public List<Bus> Buses { get; set; }
        public List<BusStop> StartBusStops { get; set; }
        public List<BusStop> EndBusStops { get; set; }
        public List<BusLine> BusLines { get; set; }
        public DateTime DateOfReservation { get; set; }
        public string StartName { get; set; }
        public string EndName { get; set; }

        [Display(Name = "Изберете линија")]
        public BusLineStartTime BusLineStartTime { get; set; }
        public CreateTicketModel() {
            Buses = new List<Bus>();
            StartBusStops = new List<BusStop>();
            EndBusStops = new List<BusStop>();
            BusLines = new List<BusLine>();
        }
    }
}