using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RootFamilyApp.Models
{
    public class TreeHeader
    {
        public Guid Id { get; set; }
        public String GedcomId { get; set; }

        //public Guid FamilyTreeId { get; set; }
        //[Required]
        //public FamilyTree FamilyTree { get; set; }
    }

    public class TreeSource
    {
        public Guid Id { get; set; }
        public String GedcomId { get; set; }

        //public Guid FamilyTreeId { get; set; }
        //public FamilyTree FamilyTree { get; set; }
    }

    public class TreeRepository
    {
        public Guid Id { get; set; }
        public String GedcomId { get; set; }

        //public Guid FamilyTreeId { get; set; }
        //public FamilyTree FamilyTree { get; set; }
    }

    public class TreeSubmitter
    {
        public Guid Id { get; set; }
        public String GedcomId { get; set; }

        //public Guid FamilyTreeId { get; set; }
        //public FamilyTree FamilyTree { get; set; }
    }

    public class TreeNote
    {
        public Guid Id { get; set; }
        public String GedcomId { get; set; }

        //public Guid FamilyTreeId { get; set; }
        //public FamilyTree FamilyTree { get; set; }
    }
}