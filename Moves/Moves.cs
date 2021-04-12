using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTextAdventure
{
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
}
