using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTextAdventure
{
    public partial class Methods
	{

        public static void Populate(Dictionary<int, Move>_movedex, Dictionary<int, Pokemon> _pokedex)
		{
            //This is where the moves first, then the Pokemon get loaded in with all their stats and stuff.

            _movedex.Add(1, new Move("Tackle", 20, 95));
            _movedex.Add(2, new Move("Ember", 30, 90));
            _movedex.Add(3, new Move("Water Gun", 30, 90));

            _pokedex.Add(0, new Pokemon(0, "missingno", 0, _movedex[1], _movedex[2], "glitch"));
			_pokedex.Add(1, new Pokemon(1, "Charmander", 5, _movedex[1], _movedex[2], "fire"));
            _pokedex.Add(2, new Pokemon(2, "Squirtle", 5, _movedex[1], _movedex[3], "water"));
		}
	}
	
	

    public class Pokemon
    {
        public int id;
        public string name;
        public int level;
        public Move[] move = new Move[2];
        public string type;

        public int maxHitPoints;
        public int currentHitPoints;

        public Pokemon(int _id, string _name, int _level, Move _move1, Move _move2, string _type)
        {
            id = _id;
            name = _name;
            level = _level;
            move[0] = _move1;
            move[1] = _move2;
            type = _type;

            maxHitPoints = level * 10;
			currentHitPoints = maxHitPoints;
        }

		public Pokemon(int _id, Dictionary<int,Pokemon> _pokedex)
		{
			id = _id;
			name = _pokedex[_id].name;
			level = _pokedex[_id].level;
			move[1] = _pokedex[_id].move[0];
			move[2] = _pokedex[_id].move[1];
			type = _pokedex[_id].type;

			maxHitPoints = level * 10;
			currentHitPoints = maxHitPoints;
		}

		public Pokemon(int _id, int _level, Dictionary<int, Pokemon> _pokedex)
		{
			id = _id;
			name = _pokedex[_id].name;
			level = _level;
            move[1] = _pokedex[_id].move[0];
            move[2] = _pokedex[_id].move[1];
            type = _pokedex[_id].type;

			maxHitPoints = level * 10;
			currentHitPoints = maxHitPoints;
		}
    }

	
}
