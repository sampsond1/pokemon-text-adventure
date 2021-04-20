﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonTextAdventure;

namespace PokemonTextAdventure
{
    public partial class Methods
	{

        public static void Populate(Dictionary<string, Move>_movedex, Dictionary<string, Pokemon> _pokedex)
		{
            //This is where the moves first, then the Pokemon get loaded in with all their stats and stuff.
            // .0625, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1
            //  ^    NoT   ^   Poison    ^  Paralysis  ^    Before   ^    ^  ^  ^  ^  ^  ^  ^  ^  ^  ^
            //CritHit    Burn          Sleep         Flinch        After  | rcol|atkB |critB|DefP | EffectChance
            //                                                           Grip  Heal  DefB AtkP  SpdB

            _movedex.Add("Absorb", new Move("Absorb", 20, 20, 100));
            _movedex.Add("Acid", new Move("Acid", 30, 40, 100, .0625, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 15, 0, .3));
            _movedex.Add("Acid Armor", new Move("Acid Armor", 40, 0, 100, .0625, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 30, 0, 0, 0, 0, 1));
            _movedex.Add("Agility", new Move("Agility", 30, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1));
            _movedex.Add("Aurora Beam", new Move("Aurora Beam", 20, 65, 100, .0625, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Barrage", new Move("Barrage", 20, 15, 85, .0625, 5, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Barrier", new Move("Barrier", 30, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 30, 0, 0, 0, 0, 1));
            _movedex.Add("Bind", new Move("Bind", 20, 25, 75, .0625, 1, false, false, false, false, false, false, false, 15, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Bite", new Move("Bite", 25, 60, 100, .0625, 1, false, false, false, false, true, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, .3));
            _movedex.Add("Blizzard", new Move("Blizzard", 5, 120, 90, .0625, 1, false, false, true, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, .1));
            _movedex.Add("Body Slam", new Move("Body Slam", 15, 85, 100, .0625, 1, false, false, false, true, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, .3));
            _movedex.Add("Bone Club", new Move("Bone Club", 20, 65, 85, .0625, 1, false, false, false, false, true, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, .1));
            _movedex.Add("Bonemerang", new Move("Bonemerang", 10, 50, 90, .0625, 2, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Bubble", new Move("Bubble", 30, 20, 100, .0625, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1));
            _movedex.Add("Clamp", new Move("Clamp", 10, 35, 75, .0625, 1, false, false, false, false, false, false, false, 15, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Comet Punch", new Move("Comet Punch", 15, 18, 85, .0625, 5, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Confusion", new Move("Confusion", 25, 50, 100));
            _movedex.Add("Crabhammer", new Move("Crabhammer", 10, 90, 85, .125, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Defense Curl", new Move("Defense Curl", 40, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 15, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Dig", new Move("Dig", 10, 100, 100, .0625, 1, false, false, false, false, false, true, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)); //SPECIAL CASE
            _movedex.Add("Dizzy Punch", new Move("Dizzy Punch", 10, 70, 100));
            _movedex.Add("Double Edge", new Move("Double Edge", 15, 100, 100, .0625, 1, false, false, false, false, false, false, false, 0, .25, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Double Kick", new Move("Double Kick", 30, 30, 100, .0625, 2, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Double Slap", new Move("Double Slap", 10, 15, 85, .0625, 5, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Dragon Rage", new Move("Dragon Rage", 10, 50, 100));
            _movedex.Add("Dream Eater", new Move("Dream Eater", 15, 100, 100)); //SPECIAL CASE
            _movedex.Add("Drill Peck", new Move("Drill Peck", 20, 80, 100));
            _movedex.Add("Earthquake", new Move("Earthquake", 10, 100, 100));
            _movedex.Add("Ember", new Move("Ember", 25, 40, 100, .0625, 1, true, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .1));
            _movedex.Add("Explosion", new Move("Explosion", 5, 170, 100, .0625, 1, false, false, false, false, false, false, false, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Fire Punch", new Move("Fire Punch", 15, 75, 100, .0625, 1, true, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .1));
            _movedex.Add("Fire Spin", new Move("Fire Spin", 15, 15, 70, .0625, 1, false, false, false, false, false, false, false, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Flamethrower", new Move("Flamethrower", 15, 95, 100, .0625, 1, true, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .1));
            _movedex.Add("Focus Energy", new Move("Focus Energy", 30, 0, 100, .0625, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 1));
            _movedex.Add("Fury Attack", new Move("Fury Attack", 20, 15, 85, .0625, 5, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Fury Swipes", new Move("Fury Swipes", 15, 18, 80, .0625, 5, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Glare", new Move("Glare", 30, 0, 75, 0, 1, false, false, false, true, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Growl", new Move("Growl", 30, 0, 75, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 15, 0, 0, 0, 1));
            _movedex.Add("Guillotine", new Move("Guillotine", 5, 0, 30, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)); //SPECIAL CASE
            _movedex.Add("Gust", new Move("Gust", 35, 40, 100));
            _movedex.Add("Harden", new Move("Harden", 30, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 15, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Headbutt", new Move("Headbutt", 15, 70, 100));
            _movedex.Add("Horn Attack", new Move("Horn Attack", 25, 65, 100));
            _movedex.Add("Horn Drill", new Move("Horn Drill", 5, 0, 30, .0625, 0, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Hydro Pump", new Move("Hydro Pump", 5, 120, 80));
            _movedex.Add("Hyper Beam", new Move("Hyper Beam", 5, 120, 80, .0625, 1, false, false, false, false, false, false, true, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Hyper Fang", new Move("Hyper Fang", 15, 80, 90, .0625, 1, false, false, false, false, true, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .1));
            _movedex.Add("Hypnosis", new Move("Hypnosis", 20, 0, 60, .0625, 0, false, false, true, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Ice Beam", new Move("Ice Beam", 10, 95, 100, .0625, 1, false, false, true, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .1));
            _movedex.Add("Ice Punch", new Move("Ice Punch", 15, 75, 100, .0625, 1, false, false, true, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .1));
            _movedex.Add("Karate Chop", new Move("Karate Chop", 25, 50, 100));
            _movedex.Add("Leer", new Move("Leer", 30, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 15, 0, 0, 1));
            _movedex.Add("Lick", new Move("Lick", 30, 20, 100, .0625, 1, false, false, false, true, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .33));
            _movedex.Add("Lovely Kiss", new Move("Lovely Kiss", 10, 0, 75, 0, 1, false, false, true, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Low Kick", new Move("Low Kick", 20, 50, 90, .0625, 1, false, false, false, false, true, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .33));
            _movedex.Add("Meditate", new Move("Meditate", 40, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 150, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Mega Punch", new Move("Mega Punch", 20, 80, 85));
            _movedex.Add("Metronome", new Move("Metronome", 10, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)); //VERY SPECIAL CASE
            _movedex.Add("Mirror Move", new Move("Mirror Move", 20, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)); // SIMILAR VERY SPECIAL CASE
            _movedex.Add("Night Shade", new Move("Night Shade", 15, 0, 100)); //SPECIAL CASE
            _movedex.Add("Pay Day", new Move("Pay Day", 20, 40, 100));



            //                                                         .0625, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1
            //                                                          ^    NoT   ^   Poison    ^  Paralysis  ^    Before   ^    ^  ^  ^  ^  ^  ^  ^  ^  ^  ^  ^
            //                                                        CritHit    Burn          Sleep         Flinch        After  | rcol|atkB |critB|DefP |SpdP EffectChance
            //                                                                                                                   Grip  Heal  DefB AtkP  SpdB



            /*_pokedex.Add(0, new Pokemon(0, "missingno", 0, _movedex[1], _movedex[2], "glitch"));
			_pokedex.Add(1, new Pokemon(1, "Charmander", 5, _movedex[1], _movedex[2], "fire"));
            _pokedex.Add(2, new Pokemon(2, "Squirtle", 5, _movedex[1], _movedex[3], "water"));*/
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
