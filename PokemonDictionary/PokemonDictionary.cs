using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDictionary
{
    public class PokemonDictionary
    {
        public static void Main(string[] args)
        {
            //This is where the moves first, then the Pokemon get loaded in with all their stats and stuff.

            Dictionary<int, Move> movedex = new Dictionary<int, Move>();

            movedex.Add(1, new Move("Tackle", 20, 95 ));
            movedex.Add(2, new Move( "Ember", 30, 90 ));
            movedex.Add(3, new Move( "Water Gun", 30, 90 ));

            Dictionary<int, Pokemon> pokedex = new Dictionary<int, Pokemon>();

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

        public int hitPoints;

        public Pokemon(int _id, string _name, int _level, Move _move1, Move _move2, string _type)
        {
            id = _id;
            name = _name;
            level = _level;
            move1 = _move1;
            move2 = _move2;
            type = _type;

            hitPoints = level * 10;
        }
    }
}
