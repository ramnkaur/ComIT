using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SoftToys.Models
{
    public class SoftToysContext : DbContext
    {
        public SoftToysContext (DbContextOptions<SoftToysContext> options)
            : base(options)
        {
        }

        public DbSet<SoftToys.Models.Toys> Toys { get; set; }
    }
}
