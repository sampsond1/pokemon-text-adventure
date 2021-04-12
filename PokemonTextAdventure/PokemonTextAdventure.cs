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
            string currentCommand;

            Dictionary<int, Pokemon> pokedex = new Dictionary<int, Pokemon>();
            Dictionary<int, Move> movedex = new Dictionary<int, Move>();
            Dictionary<int, Trainer> trainerdex = new Dictionary<int, Trainer>();
            Dictionary<int, Location> locationdex = new Dictionary<int, Location>();

            Methods.Populate(movedex, pokedex);
            Methods.Populate(locationdex);
            Methods.Populate(trainerdex);

            Console.WriteLine("                                  ,'\\");
            Console.WriteLine("    _.----.        ____         ,'  _\\   ___    ___     ____");
            Console.WriteLine("_,-'       `.     |    |  /`.   \\,-'    |   \\  /   |   |    \\  |`.");
            Console.WriteLine("\\      __    \\    '-.  | /   `.  ___    |    \\/    |   '-.   \\ |  |");
            Console.WriteLine(" \\.    \\ \\   |  __  |  |/    ,','_  `.  |          | __  |    \\|  |");
            Console.WriteLine("   \\    \\/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  |");
            Console.WriteLine("    \\     ,-'/  /   \\    ,'   | \\/ / ,`.|         /  /   \\  |     |");
            Console.WriteLine("     \\    \\ |   \\_/  |   `-.  \\    `'  /|  |    ||   \\_/  | |\\    |");
            Console.WriteLine("      \\    \\ \\      /       `-.`.___,-' |  |\\  /| \\      /  | |   |");
            Console.WriteLine("       \\    \\ `.__,'|  |`-._    `|      |__| \\/ |  `.__,'|  | |   |");
            Console.WriteLine("        \\_.-'       |__|    `-._ |              '-.|     '-.| |   |");
            Console.WriteLine("                                `'                            ' -._|");
            Console.WriteLine("                     R E D / B L U E   D E M A K E");
            Console.WriteLine("                          by Daniel Sampson");
            Console.WriteLine("\n                      (press enter to continue)");
            Console.ReadLine();

            Console.WriteLine("To start a new save, enter 'n'. To load a previous one, enter 'l'.");
            currentCommand = Console.ReadLine();
            if (currentCommand == "n")
            {
                Player player = new Player();

                Console.WriteLine("Hello there! Welcome to the world of Pokémon! My name is Professor Oak.");
                Console.WriteLine("What is your name?");
            }
            

        }
    }

    

    
}
