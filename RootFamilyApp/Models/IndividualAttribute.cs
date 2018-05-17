using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RootFamilyApp.Models
{
    public class IndividualAttribute
    {
        public Guid Id { get; set; }

        public IndividualAttributeType Type { get; set; }

        public String Text { get; set; }
        public String Location { get; set; }
        public DateTime Date { get; set; }
    }
}