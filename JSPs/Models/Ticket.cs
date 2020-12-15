using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSPs.Models
{
    public class Ticket
    {
        [Display(Name = "Почетна постојка")]
        public BusStop StartDestination { get; set; }
        public Bus Bus { get; set; }

        [Display(Name ="Дата на резервација")]
        [DataType(DataType.Date)]
        public DateTime DateOfReservation { get; set; }

        [Display(Name = "Крајна постојка")]
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
