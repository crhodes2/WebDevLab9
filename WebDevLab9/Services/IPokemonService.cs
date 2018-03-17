using System.Collections.Generic;
using WebDevLab9.Models.View;

namespace WebDevLab9.Services
{
    public interface IPokemonService
    {
        PokemonViewModel GetPokemon(int id);

        IEnumerable<PokemonViewModel> GetPokemonsForUser(int userId);

        void SavePokemon(PokemonViewModel Pokemon);

        void UpdatePokemon(PokemonViewModel user);

        void DeletePokemon(int id);
    }
}
