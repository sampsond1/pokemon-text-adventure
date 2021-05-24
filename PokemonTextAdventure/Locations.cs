using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTextAdventure
{
    public partial class Methods
    {
        public static void Populate(ref Dictionary<string, Location> locationdex, Dictionary<int, Trainer> trainerdex)
        {
            locationdex.Add("palletTown", new Location("Pallet Town", "A small town with only a few buildings, Pallet Town is known for its simplicity. The biggest points of interest are Professor Oak's LAB, where he gave you your starter Pokémon, and your house [MY HOUSE]. Besides this, there's also another HOUSE, and a MAN and a WOMAN standing around outside. They might have something interesting to say. To the NORTH is an exit to Route 1, and to the SOUTH is Routh 21, a water route that needs a swimming Pokémon to access.", new Dictionary<string, string> { { "lab", "oaksLab" }, { "house", "bluesHouse" }, { "my house", "yourHouse" }, { "north", "route1" }, { "south", "route12" } }, new Dictionary<string, string> { }, new Dictionary<string, string> { { "man", "MAN: Wow, cool Pokémon! I'm raising Pokémon, too, so they can protect me!" }, { "woman", "WOMAN: You can tell when a place is enterable because it's name will be in all caps!" } }, false, ""));
            locationdex.Add("yourHouse", new Location("Your House", "This is the house where you grew up. Your MOM sits at the table. In the corner sits a PC and a TV. 'Hi, honey!' says your mom. 'Let me HEAL your Pokémon!'", new Dictionary<string, string> { { "out", "palletTown" }, { "my house", "palletTown" } }, new Dictionary<string, string> { { "pc", "It's a PC! You can use this to store Pokémon as data!" }, { "tv", "There's a movie on TV. Four boys are walking on railroad tracks." } }, new Dictionary<string, string> { { "mom", "Everyone leaves home someday. I wish you luck on your Pokémon journey!" } }, false, "", true, true, false, new List<TrainerWrapper>(), new List<PokemonWrapper>()));
            locationdex.Add("bluesHouse", new Location("Blue's House", "This is your rival's house. You and him grew up together, but lately he's been kind of mean to you. He has a nice house, though. In the house is his sister, DAISY.", new Dictionary<string, string> { { "out", "palletTown" }, { "house", "palletTown" } }, new Dictionary<string, string>(), new Dictionary<string, string> { { "daisy", "Blue got a Pokémon from Prof. Oak, too. He immediately went off to try to become the Pokémon Master!" } }, false, ""));
            locationdex.Add("oaksLab", new Location("Prof. Oak's Lab", "You enter a neat laboratory that belongs to Professor Oak. This is where you got your starter Pokémon! In the lab, you see an AIDE, as well as Prof. OAK himself. You also see a TABLE with one Pokéball on it.", new Dictionary<string, string> { { "out", "palletTown" }, { "lab", "palletTown" } }, new Dictionary<string, string> { { "table", "The table contains a Pokéball with the third Pokémon that did not get chosen by you or Blue. I wonder how it feels about that..." } }, new Dictionary<string, string> { { "oak", "Go train your Pokémon to get stronger at Route 1. " }, { "aide", "I help Prof. Oak research Pokémon. Did you know he's the foremost expert in the world?" } }, false, ""));
            locationdex.Add("route1", new Location("Route 1", "A jaunty tune fills the air as you step onto Route 1. There's some GRASS that is rustling! There might be Pokémon to catch. To the SOUTH is Pallet Town, while to the NORTH lies Viridian City.", new Dictionary<string, string> { { "north", "viridianCity" }, { "south", "palletTown" } }, new Dictionary<string, string>(), new Dictionary<string, string>(), false, "", false, false, true, new List<TrainerWrapper>(), new List<PokemonWrapper> { new PokemonWrapper(50, "Pidgey", 2, 5), new PokemonWrapper(100, "Rattata", 2, 4) }));
            locationdex.Add("route22", new Location("Route 22", "", new Dictionary<string, string>(), new Dictionary<string, string>(), new Dictionary<string, string>(), true, "This is a water route! Your Pokémon need to be able to surf to enter here!"));
        }
    }

    public class Location
    {
        public string name;
        public string description;

        public List<TrainerWrapper> trainerBattles = new List<TrainerWrapper>();

        public Dictionary<string, string> exitLocations = new Dictionary<string, string>();

        public Dictionary<string, string> descriptions = new Dictionary<string, string>();

        public Dictionary<string, string> dialogue = new Dictionary<string, string>();

        public bool hasPc = false;
        public bool canHeal = false;

        public bool hasGrass = false;
        public List<PokemonWrapper> wildPokemon = new List<PokemonWrapper>();

        public bool isLocked = false;
        public string lockedText;

        public Location(string _name, string _description, Dictionary<string, string> _exitLocations, Dictionary<string, string> _descriptions, Dictionary<string, string> _dialogue, bool _isLocked, string _lockedText)
        {
            name = _name;
            description = _description;

            exitLocations = _exitLocations;

            descriptions = _descriptions;

            dialogue = _dialogue;

            isLocked = _isLocked;
            lockedText = _lockedText;
        }

        public Location(string _name, string _description, Dictionary<string, string> _exitLocations, Dictionary<string, string> _descriptions, Dictionary<string, string> _dialogue, bool _isLocked, string _lockedText, bool _hasPc, bool _canHeal, bool _hasGrass, List<TrainerWrapper> _trainerBattles, List<PokemonWrapper> _wildPokemon)
        {
            name = _name;
            description = _description;

            trainerBattles = _trainerBattles;

            exitLocations = _exitLocations;

            descriptions = _descriptions;

            dialogue = _dialogue;

            isLocked = _isLocked;
            lockedText = _lockedText;
        }
    }
}
