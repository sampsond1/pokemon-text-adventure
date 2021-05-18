using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTextAdventure
{
    public partial class Methods
    {
        public static void Populate(Dictionary<int, Location>_locationdex)
        {

        }
    }

    public class Location
    {
        public string name;
        public string description;
        public List<Trainer> trainerBattles;
        public Dictionary<string, string> exitLocations = new Dictionary<string, string>();

        public Dictionary<string, string> descriptions = new Dictionary<string, string>();
        public Dictionary<string, string> dialogue = new Dictionary<string, string>();

        public bool hasPc;
        public bool canHeal;

        public Location(string _name, string _description, List<Trainer> _trainerBattles, Dictionary<string, string> _exitLocations)
        {
            name = _name;
            description = _description;
            trainerBattles = _trainerBattles;
            exitLocations = _exitLocations;
        }
    }
}
