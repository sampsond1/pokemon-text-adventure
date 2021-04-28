using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonTextAdventure;

namespace PokemonTextAdventure
{
    public partial class Methods
    {

        public static void Populate(ref Dictionary<string, Move> _movedex, ref Dictionary<string, Pokemon> _pokedex)
        {
            //This is where the moves first, then the Pokemon get loaded in with all their stats and stuff.

            // .0625, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1
            //  ^    NoT   ^   Poison    ^  Paralysis  ^    Before   ^    ^  ^  ^  ^  ^  ^  ^  ^  ^  ^
            //CritHit    Burn          Sleep         Flinch        After  | rcol|atkB |critB|DefP | EffectChance
            //                                                           Grip  Heal  DefB AtkP  SpdB

            _movedex.Add("Absorb", new Move("Absorb", 20, 20, 100));
            _movedex.Add("Acid", new Move("Acid", 30, 40, 100, .0625, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 1, 0, .3));
            _movedex.Add("Acid Armor", new Move("Acid Armor", 40, 0, 100, .0625, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 2, 0, 0, 0, 0, 1));
            _movedex.Add("Agility", new Move("Agility", 30, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1));
            _movedex.Add("Aurora Beam", new Move("Aurora Beam", 20, 65, 100, .0625, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Barrage", new Move("Barrage", 20, 15, 85, .0625, 5, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Barrier", new Move("Barrier", 30, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 2, 0, 0, 0, 0, 1));
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
            _movedex.Add("Defense Curl", new Move("Defense Curl", 40, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Dig", new Move("Dig", 10, 100, 100, .0625, 1, false, false, false, false, false, true, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)); //SPECIAL CASE
            _movedex.Add("Dizzy Punch", new Move("Dizzy Punch", 10, 70, 100));
            _movedex.Add("Double Edge", new Move("Double Edge", 15, 100, 100, .0625, 1, false, false, false, false, false, false, false, 0, .25, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Double Kick", new Move("Double Kick", 30, 30, 100, .0625, 2, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Double Slap", new Move("Double Slap", 10, 15, 85, .0625, 5, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Dragon Rage", new Move("Dragon Rage", 10, 50, 100));
            _movedex.Add("Dream Eater", new Move("Dream Eater", 15, 100, 100)); //SPECIAL CASE DONE
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
            _movedex.Add("Growl", new Move("Growl", 30, 0, 75, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1));
            _movedex.Add("Guillotine", new Move("Guillotine", 5, 0, 30, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)); //SPECIAL CASE DONE
            _movedex.Add("Gust", new Move("Gust", 35, 40, 100));
            _movedex.Add("Harden", new Move("Harden", 30, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Headbutt", new Move("Headbutt", 15, 70, 100));
            _movedex.Add("Horn Attack", new Move("Horn Attack", 25, 65, 100));
            _movedex.Add("Horn Drill", new Move("Horn Drill", 5, 0, 30, .0625, 0, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)); //SPECIAL CASE DONE
            _movedex.Add("Hydro Pump", new Move("Hydro Pump", 5, 120, 80));
            _movedex.Add("Hyper Beam", new Move("Hyper Beam", 5, 120, 80, .0625, 1, false, false, false, false, false, false, true, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Hyper Fang", new Move("Hyper Fang", 15, 80, 90, .0625, 1, false, false, false, false, true, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .1));
            _movedex.Add("Hypnosis", new Move("Hypnosis", 20, 0, 60, .0625, 0, false, false, true, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Ice Beam", new Move("Ice Beam", 10, 95, 100, .0625, 1, false, false, true, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .1));
            _movedex.Add("Ice Punch", new Move("Ice Punch", 15, 75, 100, .0625, 1, false, false, true, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .1));
            _movedex.Add("Karate Chop", new Move("Karate Chop", 25, 50, 100));
            _movedex.Add("Leer", new Move("Leer", 30, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1));
            _movedex.Add("Lick", new Move("Lick", 30, 20, 100, .0625, 1, false, false, false, true, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .33));
            _movedex.Add("Lovely Kiss", new Move("Lovely Kiss", 10, 0, 75, 0, 1, false, false, true, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Low Kick", new Move("Low Kick", 20, 50, 90, .0625, 1, false, false, false, false, true, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .33));
            _movedex.Add("Meditate", new Move("Meditate", 40, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Mega Punch", new Move("Mega Punch", 20, 80, 85));
            _movedex.Add("Metronome", new Move("Metronome", 10, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)); //VERY SPECIAL CASE
            _movedex.Add("Mirror Move", new Move("Mirror Move", 20, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)); // SIMILAR VERY SPECIAL CASE
            _movedex.Add("Night Shade", new Move("Night Shade", 15, 0, 100)); //SPECIAL CASE DONE
            _movedex.Add("Pay Day", new Move("Pay Day", 20, 40, 100));
            _movedex.Add("Peck", new Move("Peck", 35, 35, 100));
            _movedex.Add("Petal Dance", new Move("Petal Dance", 20, 70, 100));
            _movedex.Add("Poison Gas", new Move("Poison Gas", 40, 0, 55, .0625, 1, false, true, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Poison Powder", new Move("Poison Powder", 35, 0, 75, .0625, 1, false, true, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Poison Sting", new Move("Poison Sting", 35, 15, 100, .0625, 1, false, true, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .2));
            _movedex.Add("Pound", new Move("Pound", 35, 40, 100));
            _movedex.Add("Psybeam", new Move("Psybeam", 20, 65, 100));
            _movedex.Add("Psychic", new Move("Psychic", 10, 90, 100));
            _movedex.Add("Quick Attack", new Move("Quick Attack", 30, 40, 100)); //SPECIAL CASE
            _movedex.Add("Razor Leaf", new Move("Razor Leaf", 25, 55, 95, .125, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Recover", new Move("Recover", 20, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, .5, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Rest", new Move("Rest", 10, 0, 100, .0, 1, false, false, false, false, false, false, false, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1)); //SPECIAL CASE DONE
            _movedex.Add("Rock Throw", new Move("Rock Throw", 15, 50, 65));
            _movedex.Add("Rolling Kick", new Move("Rolling Kick", 15, 60, 85, .0625, 1, false, false, false, false, true, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .3));
            _movedex.Add("Sand Attack", new Move("Sand Attack", 15, 0, 100, .0625, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 1));
            _movedex.Add("Scratch", new Move("Scratch", 35, 40, 100));
            _movedex.Add("Screech", new Move("Screech", 40, 0, 85, .0625, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 1));
            _movedex.Add("Self Destruct", new Move("Self Destruct", 5, 130, 100, .0625, 1, false, false, false, false, false, false, false, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Sharpen", new Move("Sharpen", 30, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Sing", new Move("Sing", 15, 0, 55, 0, 1, false, false, true, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Sky Attack", new Move("Sky Attack", 5, 140, 90, .0625, 1, false, false, false, false, false, true, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Slam", new Move("Slam", 20, 80, 75));
            _movedex.Add("Slash", new Move("Slash", 20, 70, 100, .125, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Sleep Powder", new Move("Sleep Powder", 15, 0, 75, 0, 1, false, false, true, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Sludge", new Move("Sludge", 20, 65, 100, .0625, 1, false, true, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .5));
            _movedex.Add("Smog", new Move("Smog", 20, 20, 70, .0625, 1, false, true, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .5));
            _movedex.Add("Smokescreen", new Move("Smokescreen", 20, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 1));
            _movedex.Add("Solar Beam", new Move("Solar Beam", 10, 120, 100, .0625, 1, false, false, false, false, false, true, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Sonic Boom", new Move("Sonic Boom", 20, 20, 90));
            _movedex.Add("Spike Cannon", new Move("Spike Cannon", 15, 20, 100, .0625, 5, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Splash", new Move("Splash", 40, 0, 100)); //SPECIAL CASE DONE
            _movedex.Add("Spore", new Move("Spore", 15, 0, 100, 0, 1, false, false, true, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Stomp", new Move("Stomp", 20, 65, 100, .0625, 1, false, false, false, false, true, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .3));
            _movedex.Add("String Shot", new Move("String Shot", 40, 0, 95, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1));
            _movedex.Add("Stun Spore", new Move("Stun Spore", 30, 0, 75, .0625, 1, false, false, false, true, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Submission", new Move("Submission", 25, 80, 80, .0625, 1, false, false, false, false, false, false, false, 0, .25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Super Fang", new Move("Super Fang", 10, 0, 90, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)); //SPECIAL CASE
            _movedex.Add("Swift", new Move("Swift", 20, 60, 100));
            _movedex.Add("Swords Dance", new Move("Swords Dance", 30, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Tackle", new Move("Tackle", 35, 35, 95));
            _movedex.Add("Tail Whip", new Move("Tail Whip", 30, 0, 100, 0, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1));
            _movedex.Add("Take Down", new Move("Take Down", 20, 90, 85, .0625, 1, false, false, false, false, false, false, false, 0, .25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Thunder", new Move("Thunder", 10, 120, 70, .0625, 1, false, false, false, true, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .1));
            _movedex.Add("Thunder Punch", new Move("Thunder Punch", 15, 75, 100, .0625, 1, false, false, false, true, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .1));
            _movedex.Add("Thunder Shock", new Move("Thunder Shock", 30, 40, 100, .0625, 1, false, false, false, true, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .1));
            _movedex.Add("Thunder Wave", new Move("Thunder Wave", 20, 0, 100, .0625, 1, false, false, false, true, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Transform", new Move("Transform", 10, 0, 100)); //VEEEEERY SPECIAL CASE
            _movedex.Add("Tri Attack", new Move("Tri Attack", 10, 80, 100));
            _movedex.Add("Twineedle", new Move("Twineedle", 20, 25, 100, .0625, 2, false, true, false, false, false, false, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .2));
            _movedex.Add("Vice Grip", new Move("Vice Grip", 30, 55, 100));
            _movedex.Add("Vine Whip", new Move("Vine Whip", 10, 35, 100));
            _movedex.Add("Water Gun", new Move("Water Gun", 25, 40, 100));
            _movedex.Add("Waterfall", new Move("Waterfall", 15, 80, 100));
            _movedex.Add("Wing Attack", new Move("Wing Attack", 35, 35, 100));
            _movedex.Add("Withdraw", new Move("Withdraw", 40, 0, 100, .0625, 1, false, false, false, false, false, false, false, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1));
            _movedex.Add("Wrap", new Move("Wrap", 20, 15, 85, .0625, 1, false, false, false, false, false, false, false, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));

            _movedex.Add("Struggle", new Move("Struggle", 10, 50, 100, .0625, 1, false, false, false, false, false, false, false, 0, .25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));


            _pokedex.Add("Bulbasaur", new Pokemon(1, "Bulbasaur", "grass", 5, _movedex["Tackle"], _movedex["Vine Whip"], 1, 1, 1, 3));


            _pokedex.Add("Charmander", new Pokemon(4, "Charmander", "fire", 5, _movedex["Scratch"], _movedex["Ember"], 1, 1, 1, 4));


            _pokedex.Add("Squirtle", new Pokemon(7, "Squirtle", "water", 5, _movedex["Tackle"], _movedex["Water Gun"], 1, 1, 1, 2));




        }
    }



    public class Pokemon
    {
        public int id;
        public string name;
        public int level;
        public Move[] move = new Move[2];
        public string type;

        public int hpStat;
        public int attackStat;
        public int defenseStat;
        public int speedStat;

        public int hpMod;
        public int attackMod;
        public int defenseMod;
        public int speedMod;
        public int accuracyMod;
        public int critMod;

        public int maxHitPoints;
        public int currentHitPoints;

        public bool isFainted;

        public bool isParalyzed;
        public int sleepCounter;
        public bool isBurned;
        public bool isPoisoned;
        public bool isFlinching;

        public int gripCounter;

        public Pokemon(int _id, string _name, string _type, int _level, Move _move1, Move _move2, int _hpStat, int _attackStat, int _defenseStat, int _speedStat)
        {
            id = _id;
            name = _name;
            level = _level;
            move[0] = _move1;
            move[1] = _move2;
            hpStat = _hpStat;
            attackStat = _attackStat;
            defenseStat = _defenseStat;
            speedStat = _speedStat;
            type = _type;

            maxHitPoints = level * 10;
            currentHitPoints = maxHitPoints;
        }

        public Pokemon(int _id, string _name, string _type, int _level, Move _move1, int _hpStat, int _attackStat, int _defenseStat, int _speedStat)
        {
            id = _id;
            name = _name;
            level = _level;
            move[0] = _move1;
            hpStat = _hpStat;
            attackStat = _attackStat;
            defenseStat = _defenseStat;
            speedStat = _speedStat;
            type = _type;

            maxHitPoints = level * 10;
            currentHitPoints = maxHitPoints;
        }

        public Pokemon(string _name, Dictionary<string, Pokemon> _pokedex)
        {
            id = _pokedex[_name].id;
            name = _pokedex[_name].name;
            level = _pokedex[_name].level;
            move[0] = _pokedex[_name].move[0];
            move[1] = _pokedex[_name].move[1];
            type = _pokedex[_name].type;

            maxHitPoints = level * 10;
            currentHitPoints = maxHitPoints;
        }

        public Pokemon(string _name, int _level, Dictionary<string, Pokemon> _pokedex)
        {
            id = _pokedex[_name].id;
            name = _pokedex[_name].name;
            level = _level;
            move[0] = _pokedex[_name].move[0];
            move[1] = _pokedex[_name].move[1];
            type = _pokedex[_name].type;

            maxHitPoints = level * 10;
            currentHitPoints = maxHitPoints;
        }

        public void WriteName()
        {
            switch (type)
            {
                case "bug":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(name);
                    Console.ResetColor();
                    break;
                case "dragon":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(name);
                    Console.ResetColor();
                    break;
                case "electric":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(name);
                    Console.ResetColor();
                    break;
                case "fighting":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(name);
                    Console.ResetColor();
                    break;
                case "fire":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(name);
                    Console.ResetColor();
                    break;
                case "flying":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(name);
                    Console.ResetColor();
                    break;
                case "ghost":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(name);
                    Console.ResetColor();
                    break;
                case "grass":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(name);
                    Console.ResetColor();
                    break;
                case "ground":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(name);
                    Console.ResetColor();
                    break;
                case "ice":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(name);
                    Console.ResetColor();
                    break;
                case "normal":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(name);
                    Console.ResetColor();
                    break;
                case "poison":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(name);
                    Console.ResetColor();
                    break;
                case "psychic":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(name);
                    Console.ResetColor();
                    break;
                case "rock":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(name);
                    Console.ResetColor();
                    break;
                case "water":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(name);
                    Console.ResetColor();
                    break;
                default:
                    Console.Write("YA DONE MESSED UP AARON!");
                    break;
            }
        }

    }

}
