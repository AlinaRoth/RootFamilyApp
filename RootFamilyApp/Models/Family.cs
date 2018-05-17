using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RootFamilyApp.Extensions;

namespace RootFamilyApp.Models
{
    public class Family
    {
        public Family() { }

        public Family(String gedcomId)
        {
            GedcomId = gedcomId; 
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid FamilyTreeId { get; set; }
        public FamilyTree FamilyTree { get; set; }

        public String GedcomId { get; set; }
        
        [Required]
        public String Name { get; set; }

        public Guid? WifeId { get; set; }
        public Individual Wife { get; set; }

        public Guid? HusbandId { get; set; }
        public Individual Husband { get; set; }

        [GedcomName(Type = "Pointer", Name = "CHIL")]
        public ICollection<Individual> Children { get; set; }

        /// <summary>
        /// Gets or sets the number of children. 
        /// The known number of children of this individual from all marriages or, if subordinate to a family
        /// record, the reported number of children known to belong to this family, regardless of whether the
        /// associated children are represented in the corresponding structure.This is not necessarily the count of
        /// children listed in a family structure.
        /// </summary>
        /// <value>
        /// The number of children.
        /// </value>
        [GedcomName(Type = "Value", Name ="NCHI", MinLength = 1, MaxLength = 3)]
        public Int32 NumberOfChildren { get; set; }
    }
}