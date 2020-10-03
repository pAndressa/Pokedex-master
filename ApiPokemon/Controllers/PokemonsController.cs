using ApiPokemon.Models;
using ApiPokemon.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        private readonly IPokemonRepositorio _pokemonRepositorio;
        public PokemonsController(IPokemonRepositorio pokemonRepositorio)
        {
            _pokemonRepositorio = pokemonRepositorio;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var pokemons = _pokemonRepositorio.GetPokemons();
                return Ok(pokemons);
            }
            catch
            {
                return new StatusCodeResult(500);
            }
            
        }

        [HttpPost]
        public IActionResult Post([FromBody]Pokemon pokemon)
        {
            try
            {
                var pokemonNovo = _pokemonRepositorio.Add(pokemon);
                return Ok(pokemonNovo);
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
