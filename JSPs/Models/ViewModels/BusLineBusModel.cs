using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSPs.Models.ViewModels
{
    public class BusLineBusModel
    {
        public List<BusLine> BusLines { get; set; }
        public BusLine ChosenLine { get; set; }

        public BusLineBusModel() => BusLines = new List<BusLine>();

    }
}