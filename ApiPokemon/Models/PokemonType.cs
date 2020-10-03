using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPokemon.Models
{
    public class PokemonType
    {
        public Guid Id { get; set; }
        public int PokemonId { get; set; }
        public int TypeId { get; set; }
    }
}
