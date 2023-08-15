using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PartTimeJobLogApp.Models;

namespace PartTimeJobLogApp.Data
{
    public class PartTimeJobLogAppContext : DbContext
    {
        public PartTimeJobLogAppContext (DbContextOptions<PartTimeJobLogAppContext> options)
            : base(options)
        {
        }

        public DbSet<PartTimeJobLogApp.Models.Parttime> Parttime { get; set; } = default!;
    }
}
