using System.Collections.Generic;
using System.Linq;
using WebDevLab9.Data;
using WebDevLab9.Data.Entities;

namespace WebDevLab9.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly AppDbContext _dbContext;

        public PokemonRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Pokemon GetPokemon(int id)
        {
            return _dbContext.Pokemons.Find(id);
        }

        public IEnumerable<Pokemon> GetPokemonsForUser(int userId)
        {
            return _dbContext.Pokemons.Where(Pokemon => Pokemon.UserId == userId).ToList();
        }

        public void SavePokemon(Pokemon Pokemon)
        {
            _dbContext.Pokemons.Add(Pokemon);

            _dbContext.SaveChanges();
        }

        public void UpdatePokemon(Pokemon Pokemon)
        {
            _dbContext.SaveChanges();
        }

        public void DeletePokemon(int id)
        {
            var Pokemon = _dbContext.Pokemons.Find(id);

            if (Pokemon == null) return;

            _dbContext.Pokemons.Remove(Pokemon);
            _dbContext.SaveChanges();
        }
    }
}