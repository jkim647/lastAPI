using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace English.Models
{
    public class EnglishContext : DbContext
    {
        public EnglishContext (DbContextOptions<EnglishContext> options)
            : base(options)
        {
        }

        public DbSet<English.Models.EnglishItems> EnglishItems { get; set; }
    }
}
