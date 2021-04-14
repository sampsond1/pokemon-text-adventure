using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTextAdventure
{
    public class Move
    {
        public string name;
        public int damage;
        public int accuracy;
        public int numberTimesHit;
        public int repeatingDamage;
        public int turnsInactive;
        public int attackBoost;

        public Move(string _moveName, int _moveDamage, int _moveAccuracy)
        {
            name = _moveName;
            damage = _moveDamage;
            accuracy = _moveAccuracy;

        }
        
        public Move(string _moveName, int _moveDamage, int _moveAccuracy, int _numberTimesHit, int _repeatingDamage, int turnsInactive, int attackBoost)
        {
            moveName = _moveName;
            moveDamage = _moveDamage;
            moveAccuracy = _moveAccuracy;
            numberTimesHit = _numberTimesHit;
            repeatingDamage = _repeatingDamage;
            turnsInactive = _turnsInactive;
            attackBoost = _attackBoost;
        }
    }
}
