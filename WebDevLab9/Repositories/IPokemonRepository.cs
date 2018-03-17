using System.Collections.Generic;
using WebDevLab9.Data.Entities;

namespace WebDevLab9.Repositories
{
    public interface IPokemonRepository
    {
        Pokemon GetPokemon(int id);

        IEnumerable<Pokemon> GetPokemonsForUser(int userId);

        void SavePokemon(Pokemon Pokemon);

        void UpdatePokemon(Pokemon user);

        void DeletePokemon(int id);
    }
}
