using Microsoft.EntityFrameworkCore;
using ReceitasPerfeitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasPerfeitas.Infrastructure.Context
{
    public class ReceitasPerfeitasDbContext : DbContext
    {
        public ReceitasPerfeitasDbContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReceitasPerfeitasDbContext).Assembly);
        }
    }
}
