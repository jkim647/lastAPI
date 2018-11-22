using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace English.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EnglishContext(
                serviceProvider.GetRequiredService<DbContextOptions<EnglishContext>>()))
            {
                // Look for any movies.
                if (context.EnglishItems.Count() > 0)
                {
                    return;   // DB has been seeded
                }

                context.EnglishItems.AddRange(
                    new EnglishItems
                    {
                       
                    }


                );
                context.SaveChanges();
            }
        }
    }
}
