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
    public class DeleteModel : PageModel
    {
        private readonly TodoRazorPages.Data.TodoRazorPagesContext _context;

        public DeleteModel(TodoRazorPages.Data.TodoRazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Todo == null)
            {
                return NotFound();
            }
            var todo = await _context.Todo.FindAsync(id);

            if (todo != null)
            {
                Todo = todo;
                _context.Todo.Remove(Todo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
