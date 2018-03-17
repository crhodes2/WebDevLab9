using System;
using System.Web.Mvc;
using log4net;
using WebDevLab9.Models.View;
using WebDevLab9.Services;

namespace WebDevLab9.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonService _PokemonService;
        private readonly ILog _log = log4net.LogManager.GetLogger(typeof(PokemonController));

        public PokemonController(IPokemonService PokemonService)
        {
            _PokemonService = PokemonService;
        }

        public ActionResult List(int userId)
        {
            _log.Debug("Getting list of Pokemons for user: " + userId);

            ViewBag.UserId = userId;

            var PokemonViewModels = _PokemonService.GetPokemonsForUser(userId);

            return View(PokemonViewModels);
        }

        [HttpGet]
        public ActionResult Create(int userId)
        {
            ViewBag.UserId = userId;

            return View();
        }

        [HttpPost]
        public ActionResult Create(PokemonViewModel PokemonViewModel)
        {
            _log.Info("Creating Pokemon");

            if (ModelState.IsValid)
            {
                try
                {
                    _PokemonService.SavePokemon(PokemonViewModel);
                }
                catch (Exception ex)
                {
                    _log.Error("Failed to save Pokemon.", ex);
                    throw;
                }

                return RedirectToAction("List", new {UserId = PokemonViewModel.UserId});
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Pokemon = _PokemonService.GetPokemon(id);

            return View(Pokemon);
        }

        [HttpPost]
        public ActionResult Edit(PokemonViewModel PokemonViewModel)
        {
            if (ModelState.IsValid)
            {
                _PokemonService.UpdatePokemon(PokemonViewModel);

                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var Pokemon = _PokemonService.GetPokemon(id);

            _PokemonService.DeletePokemon(id);

            return RedirectToAction("List", new {UserId = Pokemon.UserId});
        }
    }
}