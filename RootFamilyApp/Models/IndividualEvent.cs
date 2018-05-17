using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RootFamilyApp.Models
{
    public class IndividualEvent
    {
        public Guid Id { get; set; }

        public Guid IndividualId { get; set; }
        public Individual Individual { get; set; }

        public IndividualEventType Type { get; set; }

        public String Location { get; set; }

        //public DateTime Date { get; set; }
        public String Date { get; set; }
    }
}