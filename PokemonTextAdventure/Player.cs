using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTextAdventure
{
    public class Player
    {
        public bool gameRunning;

        public string name;

        public Location currentLocation;
        public Location previousLocation;

        public Pokemon[] party = new Pokemon[3];
        public List<Pokemon> pcPokemon = new List<Pokemon>();

        public static class Flags
        {
            static bool routeOne = false;
        }
    }
}
