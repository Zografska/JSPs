using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSPs.Models
{
    public class Ticket
    {
        [Display(Name ="Start Destination")]
        public BusStop StartDestination { get; set; }
        public Bus Bus { get; set; }
        public DateTime DateOfReservation { get; set; }

        [Display(Name = "End Destination")]
        public BusStop EndDestination { get; set; }
        [Key] 
        public int ID { get; set; }
        public Ticket() { }

        public Ticket(int id, BusStop start, BusStop end, Bus bus, DateTime dateOfReservation)
        {
            ID = id;
            StartDestination = start;
            EndDestination = end;
            Bus = bus;
            DateOfReservation = dateOfReservation;
        }
    }
}