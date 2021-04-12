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
        public List<Location> exitLocations;
    }
}
