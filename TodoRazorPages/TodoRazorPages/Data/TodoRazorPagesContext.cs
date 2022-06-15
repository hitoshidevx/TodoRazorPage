using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoRazorPages.Models;

namespace TodoRazorPages.Data
{
    public class TodoRazorPagesContext : DbContext
    {
        public TodoRazorPagesContext (DbContextOptions<TodoRazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<TodoRazorPages.Models.Todo>? Todo { get; set; }
    }
}
