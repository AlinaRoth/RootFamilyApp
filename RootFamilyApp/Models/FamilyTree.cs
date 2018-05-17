using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RootFamilyApp.Models
{
    public class FamilyTree
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public String Name { get; set; }

        public DateTime ChangeDate { get; set; }

        public String FilePath { get; set; }
        public String FileContents { get; set; }

        //public TreeHeader Header { get; set; } = new TreeHeader();
        public ICollection<Family> Families { get; set; }
        public ICollection<Individual> Individuals { get; set; }
        //public ICollection<TreeSource> Sources { get; set; }
        //public ICollection<TreeRepository> Repositories { get; set; }
        //public ICollection<TreeSubmitter> Submiters { get; set; }
        //public ICollection<TreeNote> Notes { get; set; }

        public Individual GetIndividual(String id)
        {
            return Individuals.FirstOrDefault(x => x.GedcomId == id);
        }

        public Family GetFamily(String id)
        {
            return Families.FirstOrDefault(x => x.GedcomId == id);
        }

        public List<String> GetContentAsLines()
        {
            return null;
        }

        public String CompressLinesToString()
        {
            return null;
        }
    }
}