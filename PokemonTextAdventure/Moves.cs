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
        public int powerPoints;
        public int damage;
        public double accuracy;
        public double critChance;
        public int numberTimesHit;
        public bool causeBurn;
        public bool causePoison;
        public bool causeSleep;
        public bool causeParalysis;
        public bool causeFlinch;
        public bool restBefore;
        public bool restAfter;
        public int gripDamage;
        public double recoilDamage;
        public double hpGain;
        public int attackBoost;
        public int defenseBoost;
        public int critBoost;
        public int attackPenalty;
        public int defensePenalty;
        public int speedBoost;
        public int speedPenalty;
        public double effectChance;

        public Move(string _moveName, int _powerPoints, int _moveDamage, int _moveAccuracy)
        {
            name = _moveName;
            powerPoints = _powerPoints;
            damage = _moveDamage;
            accuracy = _moveAccuracy;
            critChance = .0625;
            numberTimesHit = 1;
            causeBurn = false;
            causePoison = false;
            causeSleep = false;
            causeParalysis = false;
            causeFlinch = false;
            restBefore = false;
            restAfter = false;
            gripDamage = 0;
            recoilDamage = 0;
            hpGain = 0;
            attackBoost = 0;
            defenseBoost = 0;
            critBoost = 0;
            attackPenalty = 0;
            defensePenalty = 0;
            speedBoost = 0;
            effectChance = 1;

        }
        
        public Move(string _moveName, int _powerPoints, int _damage, int _accuracy, double _critChance, int _numberTimesHit, bool _causeBurn, bool _causePoison, bool _causeSleep, bool _causeParalysis, 
            bool _causeFlinch, bool _restBefore, bool _restAfter, int _gripDamage, double _recoilDamage, double _hpGain, int _attackBoost, int _defenseBoost, int _critBoost, int _attackPenalty, int _defensePenalty, int _speedBoost, double _effectChance)
        {
            name = _moveName;
            powerPoints = _powerPoints;
            damage = _damage;
            accuracy = _accuracy;
            critChance = _critChance;
            numberTimesHit = _numberTimesHit;
            causeBurn = _causeBurn;
            causePoison = _causePoison;
            causeSleep = _causeSleep;
            causeParalysis = _causeParalysis;
            causeFlinch = _causeFlinch;
            restBefore = _restBefore;
            restAfter = _restAfter;
            gripDamage = _gripDamage;
            recoilDamage = _recoilDamage;
            hpGain = _hpGain;
            attackBoost = _attackBoost;
            defenseBoost = _defenseBoost;
            critBoost = _critBoost;
            attackPenalty = _attackPenalty;
            defensePenalty = _defensePenalty;
            speedBoost = _speedBoost;
            effectChance = _effectChance;
        }

        public Move(string _moveName, int _powerPoints, int _damage, int _accuracy, double _critChance, int _numberTimesHit, bool _causeBurn, bool _causePoison, bool _causeSleep, bool _causeParalysis,
            bool _causeFlinch, bool _restBefore, bool _restAfter, int _gripDamage, double _recoilDamage, double _hpGain, int _attackBoost, int _defenseBoost, int _critBoost, int _attackPenalty, int _defensePenalty, int _speedBoost, int _speedPenalty, double _effectChance)
        {
            name = _moveName;
            powerPoints = _powerPoints;
            damage = _damage;
            accuracy = _accuracy;
            critChance = _critChance;
            numberTimesHit = _numberTimesHit;
            causeBurn = _causeBurn;
            causePoison = _causePoison;
            causeSleep = _causeSleep;
            causeParalysis = _causeParalysis;
            causeFlinch = _causeFlinch;
            restBefore = _restBefore;
            restAfter = _restAfter;
            gripDamage = _gripDamage;
            recoilDamage = _recoilDamage;
            hpGain = _hpGain;
            attackBoost = _attackBoost;
            defenseBoost = _defenseBoost;
            critBoost = _critBoost;
            attackPenalty = _attackPenalty;
            defensePenalty = _defensePenalty;
            speedBoost = _speedBoost;
            speedPenalty = _speedPenalty;
            effectChance = _effectChance;
        }
    }
}
