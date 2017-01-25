using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EF7
{
    public class EF7Repo : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=EF7Repo;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;");
        }

        public DbSet<Value> Values { get; set; }
    }
}
