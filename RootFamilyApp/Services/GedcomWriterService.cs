using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RootFamilyApp.Services
{
    public class GedcomWriterService
    {
        public void WriteHeader() { }
        public void WriteRecord() { }
        public void WriteFamilyRecord() { }
        public void WriteIndividualRecord() { }

        /// <summary>
        /// TBI - Writes the multimedia record.
        /// </summary>
        public void WriteMultimediaRecord() { }
        /// <summary>
        /// TBI - Writes the note record.
        /// </summary>
        public void WriteNoteRecord() { }
        /// <summary>
        /// TBI - Writes the repository record.
        /// </summary>
        public void WriteRepositoryRecord() { }
        /// <summary>
        /// TBI - Writes the source record.
        /// </summary>
        public void WriteSourceRecord() { }
        /// <summary>
        /// TBI - Writes the submitter recrod.
        /// </summary>
        public void WriteSubmitterRecrod() { }
    }
}