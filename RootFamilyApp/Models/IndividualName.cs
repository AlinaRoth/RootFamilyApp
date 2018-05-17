using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RootFamilyApp.Models
{
    public class IndividualName
    {
        public Guid Id { get; set; }

        public Guid IndividualId { get; set; }

        public Individual Individual { get; set; }

        public String FullName { get; set; }

        public IndividualNameType Type { get; set; }

        public String Prefix { get; set; }

        public String Given { get; set; }

        public String Nickname { get; set; }

        public String SurnamePrefix { get; set; }

        public String Surname { get; set; }

        public String Suffix { get; set; }
    }
}