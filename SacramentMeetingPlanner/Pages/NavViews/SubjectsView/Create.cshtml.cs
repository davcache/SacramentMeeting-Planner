using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.SubjectsView
{
    public class CreateModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public CreateModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Subjects Subjects { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Subjects.Add(Subjects);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}