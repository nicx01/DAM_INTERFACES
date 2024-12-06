using FirstAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : Controller
    {
        private readonly ILogger<PokemonDTO> _logger;

        private static List<PokemonDTO> Pokemons = new List<PokemonDTO>();

        public PokemonController(ILogger<PokemonDTO> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllBattleRecords")]
        public IEnumerable<PokemonDTO> Get()
        {
            return Pokemons;
        }

        [HttpGet("{id}")]
        public ActionResult<PokemonDTO> GetOne(int id)
        {
            var pokemon = Pokemons.FirstOrDefault(x => x.Id == id);
            if (pokemon == null)
                return NotFound();

            return pokemon;
        }

        [HttpPost]
        public ActionResult<PokemonDTO> Post([FromBody] PokemonDTO pokemon)
        {
            if (Pokemons.Any(x => x.Id == pokemon.Id))
                return Conflict("A record with this ID already exists.");

            Pokemons.Add(pokemon);
            return CreatedAtAction(nameof(GetOne), new { id = pokemon.Id }, pokemon);
        }

        [HttpPut("{id}")]
        public ActionResult<PokemonDTO> Put([FromBody] PokemonDTO pokemon, int id)
        {
            if (id != pokemon?.Id)
                return BadRequest("ID mismatch.");

            var existingPokemon = Pokemons.FirstOrDefault(x => x.Id == id);
            if (existingPokemon == null)
                return NotFound();

            existingPokemon.DataStart = pokemon.DataStart;
            existingPokemon.DateEnd = pokemon.DateEnd;
            existingPokemon.PokeName = pokemon.PokeName;
            existingPokemon.DamageDoneTrainer = pokemon.DamageDoneTrainer;
            existingPokemon.DamageReceivedTrainer = pokemon.DamageReceivedTrainer;
            existingPokemon.DamageDonePokemon = pokemon.DamageDonePokemon;
            existingPokemon.Image = pokemon.Image;
            existingPokemon.Catch = pokemon.Catch;
            existingPokemon.Shiny = pokemon.Shiny;

            return existingPokemon;
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var pokemon = Pokemons.FirstOrDefault(x => x.Id == id);
            if (pokemon == null)
                return NotFound();

            Pokemons.Remove(pokemon);
            return NoContent();
        }
    }
}
