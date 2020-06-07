using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Entries
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<JournalEntry> JournalEntry { get;set; }

        public async Task OnGetAsync()
        {
            Console.WriteLine("GET request");
            JournalEntry = await _context.JournalEntry.ToListAsync();
        }

        public async Task OnPostAsync()
        {
            string searchTerm = Request.Form["searchTerm"];
            searchTerm = searchTerm.ToLower();
            Console.WriteLine("Search Term " + searchTerm);
            Console.WriteLine("Order By " + Request.Form["orderBy"]);
            IList<JournalEntry> AllJournals = await _context.JournalEntry.ToListAsync();
            var filteredJournals = AllJournals.Where( e => e.Book.ToLower().Contains(searchTerm) || e.Note.ToLower().Contains(searchTerm));
            if (Request.Form["orderBy"] == "date")
            {
                JournalEntry = filteredJournals.OrderBy(e => e.DateCreated).ToList();
            } else
            {
                JournalEntry = filteredJournals.OrderBy(e => e.Book).ToList();
            }
            
        }
    }
}
