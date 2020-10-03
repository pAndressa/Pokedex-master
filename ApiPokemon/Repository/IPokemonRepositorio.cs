using ApiPokemon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPokemon.Repository
{
    public interface IPokemonRepositorio
    {
        int Add(Pokemon pokemon);
        IEnumerable<Pokemon> GetPokemons();
    }
}
