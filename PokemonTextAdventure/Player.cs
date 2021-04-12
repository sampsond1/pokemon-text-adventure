using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTextAdventure
{
    public class Player
    {
        public string name;

        public Location currentLocation;
        public Location previousLocation;

        public Pokemon[] party = new Pokemon[3];
        public List<Pokemon> pcPokemon = new List<Pokemon>();

        public static class Flags
        {
            static bool routeOne;
        }
    }
}
