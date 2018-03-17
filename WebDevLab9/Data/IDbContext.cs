using System.Data.Entity;
using WebDevLab9.Data.Entities;

namespace WebDevLab9.Data
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Pokemon> Pokemons { get; set; }
    }
}
