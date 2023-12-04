using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web_project.Models;

namespace web_project.Data
{
    public class web_projectContext : DbContext
    {
        public web_projectContext (DbContextOptions<web_projectContext> options)
            : base(options)
        {
        }

        public DbSet<web_project.Models.Menu> Menu { get; set; } = default!;
    }
}
