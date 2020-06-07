using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyScriptureJournal.Models
{
    public class JournalEntry
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        public string Book { get; set; }
        public string Chapter { get; set; }
        public string Verse { get; set; }
        public string Note { get; set; }
    }
}
