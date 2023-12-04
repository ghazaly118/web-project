using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using web_project.Data;
using web_project.Models;

namespace web_project.Pages.menu
{
    public class DetailsModel : PageModel
    {
        private readonly web_project.Data.web_projectContext _context;

        public DetailsModel(web_project.Data.web_projectContext context)
        {
            _context = context;
        }

        public Menu Menu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu.FirstOrDefaultAsync(m => m.id == id);
            if (menu == null)
            {
                return NotFound();
            }
            else
            {
                Menu = menu;
            }
            return Page();
        }
    }
}
