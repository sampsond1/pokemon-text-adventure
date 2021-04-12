using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTextAdventure
{
    class PokemonTextAdventure
    {
        static void Main(string[] args)
        {
            Dictionary<int, Pokemon> pokedex = new Dictionary<int, Pokemon>();
            Dictionary<int, Move> movedex = new Dictionary<int, Move>();
            Dictionary<int, Location> locationdex = new Dictionary<int, Location>();

            Methods.Populate(movedex, pokedex);
            Console.ReadLine();
            Console.WriteLine(movedex[1].moveName);
            Console.WriteLine(pokedex[1].name);
            Console.ReadLine();
        }
    }

    

    
}
