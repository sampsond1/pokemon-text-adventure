using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

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

        public Player()
        {

        }

        [JsonConstructor]
        public Player(bool _gameRunning, string _name, Location _currentLocation, Location _previousLocation, Pokemon[] _party, List<Pokemon> _pcPokemon)
        {
            gameRunning = _gameRunning;
            name = _name;
            currentLocation = _currentLocation;
            previousLocation = _previousLocation;
            party = _party;
            pcPokemon = _pcPokemon;
        }
    }
}
