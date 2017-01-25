using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Models;

namespace EF6
{
    public class EF6Repo : DbContext
    {
        private static string ConnectionString = @"data source=(LocalDb)\MSSQLLocalDB;initial catalog=EF6Repo;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;";

        public EF6Repo() : base(ConnectionString) {
            Database.SetInitializer<EF6Repo>(new DropCreateDatabaseIfModelChanges<EF6Repo>());
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Value> Values { get; set; }
    }
}
