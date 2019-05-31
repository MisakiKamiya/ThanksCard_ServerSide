using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ThanksCard1.Models
{
    public class ThanksCardContext : DbContext
    {
        public ThanksCardContext(DbContextOptions<ThanksCardContext>options)
            : base (options)
        {

        }
        public DbSet<TNKCD> TNKCDs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Busyo> Busyoes { get; set; }
        public DbSet<Ka> Kas { get; set; }
        public DbSet<Work> Works { get; set; }

    }
}
