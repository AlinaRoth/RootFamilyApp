using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using RootFamilyApp.Models;

namespace RootFamilyApp.Services
{
    public static class GedcomReaderService
    {
        public static FamilyTree Load(Stream fileStream)
        {
            var familyTree = new FamilyTree();
            List<String> lines = new List<String>();

            var encoding = Encoding.UTF8;
            StreamReader reader = new StreamReader(fileStream, encoding);
            do
            {
                string textLine = reader.ReadLine();
                lines.Add(textLine);

            } while (reader.Peek() != -1);
            reader.Close();

            var root = new List<Models.TreeNode>();
            var childrenLists = Enumerable.Range(1, 11).Select(i => new List<Models.TreeNode>()).ToList();
            childrenLists[0] = root;

            foreach (var line in lines)
            {
                int newlevel;
                if (line.Length > 2 && line[0] >= '0' && line[0] <= '9' && line[1] == ' ')
                {
                    newlevel = (line[0] - '0');
                }
                else
                    throw new Exception("Unable to parse level");

                var newNode = new Models.TreeNode(line.Trim());
                familyTree.FileContents += String.Concat(line, "\r\n");

                childrenLists[newlevel].Add(newNode);
                childrenLists[newlevel + 1] = newNode.Children;
            }

            //The tree is done 
            var tasks = new List<Task>();
            if (root.Count < 2)
            {
                throw new Exception("File must contain Header and Trailer");
            }

            //Get header
            var node = root[0];
            if (!node.RawLine.Equals("0 HEAD"))
            {
                throw new Exception("Header not found");
            }
            //tasks.Add(new Task(() => { ReadHeader(gedcom, gedcom.Header, node.Children); }));
            root.Remove(node);

            //Get trailer
            node = root[root.Count - 1];
            if (!node.RawLine.Equals("0 TRLR"))
                throw new Exception("Trailer not found");
            root.Remove(node);

            //all other have an Id
            foreach (var levelZeroNode in root)
            {
                //Must be always 3 parameter 0 / Id / Type

                //Get Id
                var position = levelZeroNode.RawLine.IndexOf(' ', 2);
                if (position < 0)
                    throw new Exception("Root element malformed");
                var id = levelZeroNode.RawLine.Substring(2, position - 2);

                //Get Tag                
                var tag = levelZeroNode.RawLine.Substring(3 + id.Length);

                if (tag.Equals("INDI"))
                {
                    var individual = new Individual(id);
                    tasks.Add(new Task(() => { ReadIndividualRecord(familyTree, individual, levelZeroNode.Children); }));
                    if (familyTree.Individuals == null)
                    {
                        familyTree.Individuals = new List<Individual>();
                    }
                    familyTree.Individuals.Add(individual);
                }
                else if (tag.Equals("FAM"))
                {
                    var family = new Family(id);
                    tasks.Add(new Task(() => { ReadFamilyRecord(familyTree, family, levelZeroNode.Children); }));
                    if (familyTree.Families == null)
                    {
                        familyTree.Families = new List<Family>();
                    }
                    familyTree.Families.Add(family);
                }
                //else if (tag.Equals("SOUR"))
                //{
                //    var source = new Source(id);
                //    tasks.Add(new Task(() => { ParseSource(gedcom, source, levelZeroNode.Children); }));
                //    gedcom.Sources.Add(source);
                //}
                //else if (tag.Equals("SUBM"))
                //{
                //    var submiter = new Submiter(id);
                //    tasks.Add(new Task(() => { ParseSubmiter(gedcom, submiter, levelZeroNode.Children); }));
                //    gedcom.Submiters.Add(submiter);
                //}
                //else if (tag.Equals("REPO"))
                //{
                //    var repository = new Repository(id);
                //    tasks.Add(new Task(() => { ParseRepository(gedcom, repository, levelZeroNode.Children); }));
                //    gedcom.Repositories.Add(repository);
                //}
                //else if (tag.Equals("NOTE"))
                //{
                //    var note = new Note(id);
                //    tasks.Add(new Task(() => { ParseNote(gedcom, note, levelZeroNode.Children); }));
                //    gedcom.Notes.Add(note);
                //}
                else
                {
                    //Console.WriteLine(tag);
                }
            }

            //Run all tasks
            foreach (var task in tasks)
            {
                task.Start();
            }

            //Wait all thread
            Task.WaitAll(tasks.ToArray());

            return familyTree;
        }
        public static void ReadHeader() { }
        public static void ReadRecord() { }

        public static void ReadFamilyRecord(FamilyTree gedcom, Family family, List<Models.TreeNode> children)
        {
            foreach (var child in children)
            {
                switch (child.Tag)
                {
                    case "HUSB":
                        if (child.HasValue)
                        {
                            var husband = gedcom.GetIndividual(child.GetTextValue());
                            if (husband != null)
                            {
                                family.Husband = husband;
                            }
                        }
                        break;
                    case "WIFE":
                        if (child.HasValue)
                        {
                            var wife = gedcom.GetIndividual(child.GetTextValue());
                            if (wife != null)
                            {
                                family.Wife = wife;
                            }

                        }
                        break;
                    case "CHIL":
                        if (child.HasValue)
                        {
                            var familyChildren = gedcom.GetIndividual(child.GetTextValue());
                            if (familyChildren != null)
                            {
                                if (family.Children == null)
                                {
                                    family.Children = new List<Individual>();
                                }
                                family.Children.Add(familyChildren);
                            }

                        }
                        break;
                    case "NCHI":
                        if (child.HasValue)
                        {
                            family.NumberOfChildren = (int)child.GetInt32Value();
                        }
                        break;
                }
            }
        }

        public static void ReadIndividualRecord(FamilyTree gedcom, Individual individual, List<Models.TreeNode> children)
        {
            foreach (var child in children)
            {
                switch (child.Tag)
                {
                    case "NAME":
                        if (child.HasValue)
                        {
                            var name = new IndividualName();
                            name.FullName = child.GetTextValue();
                            ReadeName(gedcom, name, child.Children);
                            if (individual.IndividualNames == null)
                            {
                                individual.IndividualNames = new List<IndividualName>();
                            }
                            individual.IndividualNames.Add(name);
                        }
                        break;
                    case "SEX":
                        if (child.HasValue)
                        {
                            switch (child.GetTextValue())
                            {
                                case "M":
                                    individual.Sex = IndividualSex.M;
                                    break;
                                case "F":
                                    individual.Sex = IndividualSex.F;
                                    break;
                                case "U":
                                    individual.Sex = IndividualSex.U;
                                    break;
                            }
                        }
                        break;
                    case "DEAT":
                    case "BIRT":
                        var individualEvent = new IndividualEvent();
                        individualEvent.Type = IndividualEventType.Birth;
                        ReadEvent(gedcom, individualEvent, child.Children);
                        if (individual.Events == null)
                        {
                            individual.Events = new List<IndividualEvent>();
                        }
                        individual.Events.Add(individualEvent);
                        break;
                    //case "OCCU":
                    //    if (!child.HasValue)
                    //        break;
                    //    var individualAttribute = new IndividualAttribute();
                    //    individualAttribute.Text = child.GetTextValue();
                    //    individualAttribute.Type = child.Tag;
                    //    ParseAttribute(gedcom, individualAttribute, child.Childs);
                    //    individual.Attributes.Add(individualAttribute);
                    //    break;
                    /*case "ADOP" :
                        Console.WriteLine(child.RawLine);
                        foreach (var ch in child.Childs) {
                            Console.WriteLine("\t{0}",ch.RawLine);
                        }
                        break; */
                    case "FAMC":
                        if (child.HasValue)
                        {
                            var family = gedcom.GetFamily(child.GetTextValue());
                            if (family != null)
                            {
                                if (individual.ChildInFamilies == null)
                                {
                                    individual.ChildInFamilies = new List<Family>();
                                }
                                individual.ChildInFamilies.Add(family);
                            }
                        }
                        break;
                    case "FAMS":
                        if (child.HasValue)
                        {
                            var family = gedcom.GetFamily(child.GetTextValue());
                            if (family != null)
                            {
                                if (individual.ParentInFamilies == null)
                                {
                                    individual.ParentInFamilies = new List<Family>();
                                }
                                individual.ParentInFamilies.Add(family);

                            }
                        }
                        break; //NMR
                    //case "NCHI":
                    //    if (child.HasValue)
                    //        individual.KnowChilds = child.GetInt32Value();

                    //    break;
                    //case "NMR":
                    //    if (child.HasValue)
                    //        individual.KnowMarriages = child.GetInt32Value();
                    //    break;
                }

            }
        }

        public static void ReadEvent(FamilyTree gedcom, IndividualEvent individualEvent, List<Models.TreeNode> children)
        {
            foreach (var child in children)
            {
                switch (child.Tag)
                {
                    case "DATE":
                        if (child.HasValue)
                        {
                            //individualEvent.Date = DateTime.Parse(child.GetTextValue());
                            individualEvent.Date = child.GetTextValue();
                        }
                        break;
                    case "PLAC":
                        if (child.HasValue)
                        {
                            individualEvent.Location = child.GetTextValue();
                        }
                        break;
                }
            }
        }

        public static void ReadeName(FamilyTree gedcom, IndividualName name, List<Models.TreeNode> children)
        {
            foreach (var child in children)
            {
                switch (child.Tag)
                {
                    case "TYPE":
                        if (child.HasValue)
                            switch (child.GetTextValue())
                            {
                                case "AKA":
                                    name.Type = IndividualNameType.Aka;
                                    break;
                                case "BIRTH":
                                    name.Type = IndividualNameType.Birth;
                                    break;
                            }
                            //name.Type = child.GetTextValue();
                        break;
                    case "NPFX":
                        if (child.HasValue)
                            name.Prefix = child.GetTextValue();
                        break;
                    case "GIVN":
                        if (child.HasValue)
                            name.Given = child.GetTextValue();
                        break;
                    case "NICK":
                        if (child.HasValue)
                            name.Nickname = child.GetTextValue();
                        break;
                    case "SPFX":
                        if (child.HasValue)
                            name.SurnamePrefix = child.GetTextValue();
                        break;
                    case "SURN":
                        if (child.HasValue)
                            name.Surname = child.GetTextValue();
                        break;
                    case "NSFX":
                        if (child.HasValue)
                            name.Suffix = child.GetTextValue();
                        break;
                }
            }
        }

        /// <summary>
        /// TBI - Reads the multimedia record.
        /// </summary>
        public static void ReadMultimediaRecord() { }
        /// <summary>
        /// TBI - Reads the note record.
        /// </summary>
        public static void ReadNoteRecord() { }
        /// <summary>
        /// TBI - Reads the repository record.
        /// </summary>
        public static void ReadRepositoryRecord() { }
        /// <summary>
        /// TBI - Reads the source record.
        /// </summary>
        public static void ReadSourceRecord() { }
        /// <summary>
        /// TBI - Reads the submitter recrod.
        /// </summary>
        public static void ReadSubmitterRecrod() { }
    }
}