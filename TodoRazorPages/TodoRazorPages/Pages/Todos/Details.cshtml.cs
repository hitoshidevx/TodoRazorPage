using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoRazorPages.Data;
using TodoRazorPages.Models;

namespace TodoRazorPages.Pages.Todos
{
    public class DetailsModel : PageModel
    {
        private readonly TodoRazorPages.Data.TodoRazorPagesContext _context;

        public DetailsModel(TodoRazorPages.Data.TodoRazorPagesContext context)
        {
            _context = context;
        }

      public Todo Todo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Todo == null)
            {
                return NotFound();
            }

            var todo = await _context.Todo.FirstOrDefaultAsync(m => m.TodoId == id);
            if (todo == null)
            {
                return NotFound();
            }
            else 
            {
                Todo = todo;
            }
            return Page();
        }
    }
}
