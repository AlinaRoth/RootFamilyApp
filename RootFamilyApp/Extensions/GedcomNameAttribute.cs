using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RootFamilyApp.Extensions
{
    public class GedcomNameAttribute : Attribute
    {
        public String Type { get; set; }
        public String Name { get; set; }
        public Int32 MinLength { get; set; }
        public Int32 MaxLength { get; set; }
    }
}