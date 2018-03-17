using System.Web.Http;
using WebApi.Data;
using WebApi.Data.Entities;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Pokemon")]
    public class PokemonController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetPokemons()
        {
            return Ok(InMemoryDatabase.Pokemons);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetPokemon(int id)
        {
            if (id >= InMemoryDatabase.Pokemons.Count)
            {
                return NotFound();
            }
            else
            {
                return Ok(InMemoryDatabase.Pokemons[id]);
            }

        }


    }
}