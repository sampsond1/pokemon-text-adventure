using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTextAdventure
{
    public partial class Methods
    {
        public static void Populate(ref Dictionary<int, Trainer> trainerdex, Dictionary<string, Pokemon> pokedex)
        {
            trainerdex.Add(1, new Trainer("Blue", "Rival", new Pokemon("Missingno", pokedex), new Pokemon("Missingno", pokedex), new Pokemon("Missingno", pokedex), "Let's check out our Pokémon! I'll battle you!", "What? Unbelievable! I picked the wrong Pokémon!"));
        }
    }

    public class Trainer
    {
        public string name;
        public string type;
        public List<Pokemon> trainerParty = new List<Pokemon>();
        public string challengeMessage;
        public string defeatMessage;

        public Trainer(string _name, string _type, Pokemon _firstPokemon, Pokemon _secondPokemon, Pokemon _thirdPokemon, string _challengeMessage, string _defeatMessage)
        {
            name = _name;
            type = _type;
            trainerParty.Add(_firstPokemon);
            trainerParty.Add(_secondPokemon);
            trainerParty.Add(_thirdPokemon);
            challengeMessage = _challengeMessage;
            defeatMessage = _defeatMessage;
        }
    }

    public class TrainerWrapper
    {
        public Trainer trainer;
        public string locationUnlocked;

        public TrainerWrapper(Trainer _trainer, string _locationUnlocked)
        {
            trainer = _trainer;
            locationUnlocked = _locationUnlocked;
        }
    }
}
