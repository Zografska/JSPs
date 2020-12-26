using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSPs.Models
{
    // Model koj treba da se iskoristi za kreiranje na tiket 
    public class CreateTicketModel
    {
        public DateTime Date { get; set; }
        public int BusId { get; set; }
        public int StartBusStopId { get; set; }
        public int EndBusStopId { get; set; }
        public List<Bus> Buses { get; set; }
        public List<BusStop> StartBusStops { get; set; }
        public List<BusStop> EndBusStops { get; set; }
        public DateTime DateOfReservation { get; set; }
        public CreateTicketModel() {
            Buses = new List<Bus>();
            StartBusStops = new List<BusStop>();
            EndBusStops = new List<BusStop>();
        }
    }
}