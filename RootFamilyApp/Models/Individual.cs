using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RootFamilyApp.Models
{
    public class Individual
    {
        public Individual() { }

        public Individual(String gedcomId)
        {
            GedcomId = gedcomId;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid FamilyTreeId { get; set; }
        public FamilyTree FamilyTree { get; set; }

        public String GedcomId { get; set; }

        /// <summary>
        /// Gets or sets the individual names. 
        /// +1 &lt;&lt;PERSONAL_NAME_STRUCTURE&gt;&gt; {0:M}
        /// </summary>
        /// <value>
        /// The individual names.
        /// </value>
        public ICollection<IndividualName> IndividualNames { get; set; }

        /// <summary>
        /// Gets or sets the sex.
        /// +1 SEX &lt;SEX_VALUE&gt; {0:1}
        /// </summary>
        /// <value>
        /// The sex.
        /// </value>
        public IndividualSex Sex { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// +1 &lt;&lt;INDIVIDUAL_EVENT_STRUCTURE&gt;&gt; {0:M}
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public ICollection<IndividualEvent> Events { get; set; }

        /// <summary>
        /// Gets or sets the attributes.
        /// +1 &lt;&lt;INDIVIDUAL_ATTRIBUTE_STRUCTURE&gt;&gt; {0:M}
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        public ICollection<IndividualAttribute> Attributes { get; set; }

        /// <summary>
        /// Gets or sets the child in families.
        /// +1 &lt;&lt;CHILD_TO_FAMILY_LINK&gt;&gt; {0:M}
        /// </summary>
        /// <value>
        /// The child in families.
        /// </value>
        public ICollection<Family> ChildInFamilies { get; set; }

        /// <summary>
        /// Gets or sets the parent in families.
        /// +1 &lt;&lt;SPOUSE_TO_FAMILY_LINK&gt;&gt; {0:M}
        /// </summary>
        /// <value>
        /// The parent in families.
        /// </value>
        public ICollection<Family> ParentInFamilies { get; set; }
    }
}