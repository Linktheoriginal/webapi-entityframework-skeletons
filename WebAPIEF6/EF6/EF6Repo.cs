namespace EF6 {
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class EF6Repo : DbContext {
        public EF6Repo()
            : base("name=EF6Repo") {
        }

        public DbSet<Value> Values { get; set; }
    }
}