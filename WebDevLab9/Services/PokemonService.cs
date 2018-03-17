using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDevLab9.Data.Entities;
using WebDevLab9.Models.View;
using WebDevLab9.Repositories;

namespace WebDevLab9.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _repository;

        public PokemonService(IPokemonRepository respository)
        {
            _repository = respository;
        }

        public PokemonViewModel GetPokemon(int id)
        {
            var Pokemon = _repository.GetPokemon(id);
            return MapToPokemonViewModel(Pokemon);
        }

        public IEnumerable<PokemonViewModel> GetPokemonsForUser(int userId)
        {
            var PokemonViewModels = new List<PokemonViewModel>();

            var Pokemons = _repository.GetPokemonsForUser(userId);

            foreach (var Pokemon in Pokemons)
            {
                PokemonViewModels.Add(MapToPokemonViewModel(Pokemon));
            }

            return PokemonViewModels;
        }

        public void SavePokemon(PokemonViewModel PokemonViewModel)
        {
            //throw new Exception("Test Exception");

            var Pokemon = MapToPokemon(PokemonViewModel);

            _repository.SavePokemon(Pokemon);
        }

        public void UpdatePokemon(PokemonViewModel PokemonViewModel)
        {
            var Pokemon = _repository.GetPokemon(PokemonViewModel.Id);

            CopyToPokemon(PokemonViewModel, Pokemon);

            _repository.UpdatePokemon(Pokemon);
        }

        public void DeletePokemon(int id)
        {
            _repository.DeletePokemon(id);
        }

        private Pokemon MapToPokemon(PokemonViewModel PokemonViewModel)
        {
            return new Pokemon
            {
                Id = PokemonViewModel.Id,
                Name = PokemonViewModel.Name,
                Age = PokemonViewModel.Age,
                NextCheckup = PokemonViewModel.NextCheckup,
                VetName = PokemonViewModel.VetName,
                UserId = PokemonViewModel.UserId
            };
        }

        private PokemonViewModel MapToPokemonViewModel(Pokemon Pokemon)
        {
            var PokemonViewModel = new PokemonViewModel
            {
                Id = Pokemon.Id,
                Name = Pokemon.Name,
                Age = Pokemon.Age,
                NextCheckup = Pokemon.NextCheckup,
                VetName = Pokemon.VetName,
                UserId = Pokemon.UserId
            };

            PokemonViewModel.CheckupAlert = (PokemonViewModel.NextCheckup - DateTime.Now).Days < 14;

            return PokemonViewModel;
        }

        private void CopyToPokemon(PokemonViewModel PokemonViewModel, Pokemon Pokemon)
        {
            Pokemon.Id = PokemonViewModel.Id;
            Pokemon.Name = PokemonViewModel.Name;
            Pokemon.Age = PokemonViewModel.Age;
            Pokemon.NextCheckup = PokemonViewModel.NextCheckup;
            Pokemon.VetName = PokemonViewModel.VetName;
            Pokemon.UserId = PokemonViewModel.UserId;
        }
    }
}