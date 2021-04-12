using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTextAdventure
{
    public partial class Methods
    {
        public static void Populate(Dictionary<int, Trainer> _trainerdex)
        {

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
