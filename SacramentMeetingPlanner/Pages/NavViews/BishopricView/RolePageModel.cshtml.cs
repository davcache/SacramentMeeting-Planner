using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SacramentMeetingPlanner.Pages.NavViews.BishopricView
{
    public class RolePageModel : PageModel
    {
        public SelectList RoleNameSL { get; set; }
        public void PopulateRoleDropDownList(PlannerContext _context)
        {
            Array roleQuery = Enum.GetValues(typeof(Role));
            RoleNameSL = new SelectList(roleQuery);
        }
    }
}