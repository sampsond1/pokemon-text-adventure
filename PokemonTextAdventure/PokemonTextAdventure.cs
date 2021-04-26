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
            bool shouldExit = false;
            string currentCommand;

            Dictionary<string, Pokemon> pokedex = new Dictionary<string, Pokemon>();
            Dictionary<string, Move> movedex = new Dictionary<string, Move>();
            Dictionary<int, Trainer> trainerdex = new Dictionary<int, Trainer>();
            Dictionary<int, Location> locationdex = new Dictionary<int, Location>();

            Methods.Populate(ref movedex, ref pokedex);
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
                Console.WriteLine("This world is inhabited by creatures called Pokémon! For some people, Pokémon are pets. Others use them for fights. \nMyself... I study Pokémon as a profession.\n");
                Console.WriteLine("First, what is your name?");

                player.name = Console.ReadLine();
                if (player.name == "") { player.name = "Red"; }

                Console.WriteLine($"\nWelcome, {player.name}!");
                Console.WriteLine("I've known you since you were a child, so I'll give you a Pokémon to start you on your journey.");
                Console.Write("Would you like ");
                Methods.WriteType("Bulbasaur", "grass");
                Console.Write(", a grass-type Pokémon, ");
                Methods.WriteType("Charmander", "fire");
                Console.Write(", a fire-type Pokémon, or ");
                Methods.WriteType("Squirtle", "water");
                Console.WriteLine(", a water-type Pokémon?");

                while(shouldExit == false)
                {
                    currentCommand = Console.ReadLine();

                    switch (currentCommand.ToLower())
                    {
                        case "squirtle":
                        case "s":
                            player.party[0] = new Pokemon("Squirtle", pokedex);
                            Methods.WriteType("Squirtle", "water"); Console.WriteLine("! A fine choice!");
                            shouldExit = true;
                            break;
                        case "charmander":
                        case "c":
                            player.party[0] = new Pokemon("Charmander", pokedex);
                            Methods.WriteType("Charmander", "fire"); Console.WriteLine("! A fine choice!");
                            shouldExit = true;
                            break;
                        case "bulbasaur":
                        case "b":
                            player.party[0] = new Pokemon("Bulbasaur", pokedex);
                            Methods.WriteType("Bulbasaur", "grass"); Console.WriteLine("! A fine choice!");
                            shouldExit = true;
                            break;
                        default:
                            Console.WriteLine("I'm sorry, I didn't understand that. Could you tell me again?");
                            break;
                    }
                }

                Console.WriteLine("Anyway, thanks for stopping by! Good luck on your adventure to become the Pokémon Master!");
                Console.ReadLine();

            }
            

        }
    }

    

    
}
