using System.Linq;
using SacramentMeetingPlanner.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SacramentMeetingPlanner.Pages.NavViews.BishopricView
{
    public class RolePageModel : PageModel
    {
        public SelectList RoleNameSL { get; set; }

        public void PopulateRoleDropDownList(PlannerContext _context, object selectedRole = null)
        {
            var rolesQuery = from r in _context.Role
                             orderby r.RoleTypeName // Sort by name.
                             select r;

            RoleNameSL = new SelectList(rolesQuery.AsNoTracking(),
                    "RoleID", "RoleTypeName", selectedRole);
        }
    }
}