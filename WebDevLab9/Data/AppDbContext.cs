using System.Data.Entity;
using WebDevLab9.Data.Entities;

namespace WebDevLab9.Data
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Pokemon> Pokemons { get; set; }
    }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        // intentionally left blank
    }
}