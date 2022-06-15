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
    public class IndexModel : PageModel
    {
        private readonly TodoRazorPages.Data.TodoRazorPagesContext context;

        public IndexModel(TodoRazorPages.Data.TodoRazorPagesContext _context)
        {
            context = _context;
        }

        public IList<Todo> Todo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (context.Todo != null)
            {
                Todo = await context.Todo.ToListAsync();
            }
        }
    }
}
