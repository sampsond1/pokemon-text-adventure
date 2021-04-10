using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTextAdventure
{
    public class Methods
	{
		public static void PopulatePokedex()
		{
			//This is where the moves first, then the Pokemon get loaded in with all their stats and stuff.

            Dictionary<int, Move> movedex = new Dictionary<int, Move>();

            movedex.Add(1, new Move("Tackle", 20, 95 ));
            movedex.Add(2, new Move( "Ember", 30, 90 ));
            movedex.Add(3, new Move( "Water Gun", 30, 90 ));

            Dictionary<int, Pokemon> pokedex = new Dictionary<int, Pokemon>();

            pokedex.Add(0,new Pokemon(0, "missigno", 0, movedex[1], movedex[2], "glitch"))
			pokedex.Add(1, new Pokemon(1, "Charmander", 5, movedex[1], movedex[2], "fire"));
            pokedex.Add(2, new Pokemon(2, "Squirtle", 5, movedex[1], movedex[3], "water"));
		}
	}
	
	public class Move
    {
        public string moveName;
        public int moveDamage;
        public int moveAccuracy;

        public Move(string _moveName, int _moveDamage, int _moveAccuracy)
        {
            moveName = _moveName;
            moveDamage = _moveDamage;
            moveAccuracy = _moveAccuracy;

        }
    }

    public class Pokemon
    {
        public int id;
        public string name;
        public int level;
        public Move move1;
        public Move move2;
        public string type;

        public int maxHitPoints;
		public in currentHitPoints

        public Pokemon(int _id, string _name, int _level, Move _move1, Move _move2, string _type)
        {
            id = _id;
            name = _name;
            level = _level;
            move1 = _move1;
            move2 = _move2;
            type = _type;

            maxHitPoints = level * 10;
			currentHitPoints = maxHitPoints;
        }

		public Pokemon(int _id, Dictionary<int,Pokemon> _pokedex)
		{
			id = _id;
			name = _pokedex[_id].name;
			level = _pokedex[_id].level;
			move1 = _pokedex[_id].move1;
			move2 = _pokedex[_id].move2;
			type = _pokedex[_id].type;

			maxHitPoints = level * 10;
			currentHitPoints = maxHitPoints;
		}

		public Pokemon(int _id, int _level, Dictionary<int, Pokemon> _pokedex)
		{
			id = _id;
			name = _pokedex[_id].name;
			level = _level;
			move1 = _pokedex[_id].move1;
			move2 = _pokedex[_id].move2;
			type = _pokedex[_id].type;

			maxHitPoints = level * 10;
			currentHitPoints = maxHitPoints;
		}
    }

	public class Trainer
	{
		public string name;
		public string type;
		public Pokemon firstPokemon;
		public Pokemon secondPokemon;
		public Pokemon thirdPokemon;
		public string challengeMessage;
		public string defeatMessage;

		public Trainer(string _name, string _type, Pokemon _firstPokemon, Pokemon _secondPokemon, Pokemon _thirdPokemon, string _challengeMessage, string _defeatMessage)
		{
			name = _name;
			type = _type;
			firstPokemon = _firstPokemon;
			secondPokemon = _secondPokemon;
			thirdPokemon = _thirdPokemon;
			challengeMessage = _challengeMessage;
			defeatMessage = _defeatMessage;
		}
	}
}
