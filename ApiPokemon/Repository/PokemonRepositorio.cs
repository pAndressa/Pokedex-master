using ApiPokemon.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPokemon.Repository
{
    public class PokemonRepositorio : IPokemonRepositorio
    {
        private readonly string _conexao;

        public PokemonRepositorio(IConfiguration configuration)
        {
            _conexao = configuration.GetConnectionString("DefaultConnection");
        }

        public int Add(Pokemon pokemon)
        {
            using var connection = new NpgsqlConnection(_conexao);
            pokemon.Id = Guid.NewGuid();
            var query = "INSERT INTO pokemons(id, pokedex_index, name, hp, attack, defense, special_attack, special_defense, speed, generation) " +
                "VALUES(@Id, @PokedexIndex, @Name, @Hp, @Attack, @Defense, @SpecialAttack, @SpecialDefense, @Speed, @Generation)";
            var result = connection.Execute(query, pokemon);
            return result;
        }

        public IEnumerable<Pokemon> GetPokemons()
        {
            using var connection = new NpgsqlConnection(_conexao);
            var pokemons = connection.Query<Pokemon>("SELECT pokedex_index as pokedexIndex, name, hp, attack, defense, special_attack as SpecialAttack, special_defense as SpecialDefense, speed, generation FROM pokemons");
            return pokemons;
        }
    }
}
