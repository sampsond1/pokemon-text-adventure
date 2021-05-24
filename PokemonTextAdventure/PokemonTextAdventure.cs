using System;
using System.Collections.Generic;
using System.IO;
using System.Text.;

namespace PokemonTextAdventure
{
    class PokemonTextAdventure
    {
        static void Main(string[] args)
        {
            bool shouldExit = false;
            string currentCommand;
            string path = @"C:\PokemonTextAdventure";
            if (!File.Exists(path)) { Directory.CreateDirectory(path); }

            Dictionary<string, Pokemon> pokedex = new Dictionary<string, Pokemon>();
            Dictionary<string, Move> movedex = new Dictionary<string, Move>();
            Dictionary<int, Trainer> trainerdex = new Dictionary<int, Trainer>();
            Dictionary<string, Location> locationdex = new Dictionary<string, Location>();
            Player player = new Player();

            Methods.Populate(ref movedex, ref pokedex);
            Methods.Populate(ref trainerdex, pokedex);

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
            if (currentCommand == "debug")
            {
                player.party[0] = new Pokemon("Scyther", 50, pokedex);
                player.party[1] = new Pokemon("Missingno", 50, pokedex);
                player.party[2] = new Pokemon("Missingno", pokedex);
                Methods.WildBattle(ref player, new Pokemon("Mewtwo", 30, pokedex), movedex["Struggle"]);
                Console.ReadLine();
            }

            if (currentCommand == "n")
            {
                Console.WriteLine("OAK: Hello there! Welcome to the world of Pokémon! My name is Professor Oak."); Console.ReadLine();
                Console.WriteLine("OAK: This world is inhabited by creatures called Pokémon! For some people, Pokémon are pets. Others use them for fights. \nMyself... I study Pokémon as a profession.\n"); Console.ReadLine();
                Console.WriteLine("First, what is your name?");

                player.name = Console.ReadLine();
                if (player.name == "") { player.name = "Red"; }
                path = path + player.name;
                File.Create(path);

                Console.WriteLine($"\nWelcome, {player.name}!");
                Console.WriteLine("I'll give you a Pokémon to start you on your journey."); Console.ReadLine();
                Console.Write("Would you like ");
                Methods.WriteType("Bulbasaur", "grass");
                Console.Write(", a grass-type Pokémon, ");
                Methods.WriteType("Charmander", "fire");
                Console.Write(", a fire-type Pokémon, or ");
                Methods.WriteType("Squirtle", "water");
                Console.WriteLine(", a water-type Pokémon?");

                string bluesStarter = "";
                string bluesStarterType = "";
                while (shouldExit == false)
                {
                    currentCommand = Console.ReadLine();
                    

                    switch (currentCommand.ToLower())
                    {
                        case "squirtle":
                        case "s":
                            player.party[0] = new Pokemon("Squirtle", 5, pokedex);
                            Methods.WriteType("Squirtle", "water"); Console.WriteLine("! A fine choice!");
                            bluesStarter = "Bulbasaur";
                            bluesStarterType = "grass";
                            shouldExit = true;
                            break;
                        case "charmander":
                        case "c":
                            player.party[0] = new Pokemon("Charmander", 5, pokedex);
                            Methods.WriteType("Charmander", "fire"); Console.WriteLine("! A fine choice!");
                            bluesStarter = "Squirtle";
                            bluesStarterType = "water";
                            shouldExit = true;
                            break;
                        case "bulbasaur":
                        case "b":
                            player.party[0] = new Pokemon("Bulbasaur", 5, pokedex);
                            Methods.WriteType("Bulbasaur", "grass"); Console.WriteLine("! A fine choice!");
                            bluesStarter = "Charmander";
                            bluesStarterType = "fire";
                            shouldExit = true;
                            break;
                        default:
                            Console.WriteLine("I'm sorry, I didn't understand that. Could you tell me again?");
                            break;
                    }
                }
                Console.WriteLine("OAK: Oh! Here's Blue, my grandson! He's been your rival since you were a baby."); Console.ReadLine();
                Console.WriteLine("BLUE: What about me, Gramps?"); Console.ReadLine();
                Console.WriteLine("OAK: Be patient! You can have one!"); Console.ReadLine();
                Console.Write("BLUE: I'll choose "); Methods.WriteType(bluesStarter, bluesStarterType); Console.Write(", then!");
                trainerdex[1].trainerParty[1] = new Pokemon(bluesStarter, 5, pokedex);
                if (!Methods.TrainerBattle(ref player, trainerdex[1], movedex["Struggle"]))
                {
                    Console.WriteLine("BLUE: Yeah! Am I great or what?");
                    player.party[0].Heal();
                    Console.ReadKey();
                }
                Console.WriteLine($"I'll make my Pokémon battle to level it up! Smell ya later, {player.name}, Gramps!"); Console.ReadKey();
                Console.WriteLine("OAK: That kid... Anyway, good luck on your adventure! Try battling on Route 1!"); Console.ReadKey();
                Methods.Populate(ref locationdex, trainerdex);
                player.currentLocation = locationdex["palletTown"];
                player.previousLocation = locationdex["palletTown"];
                player.party[1] = new Pokemon("Missingno", pokedex);
                player.party[2] = new Pokemon("Missingno", pokedex);
                player.gameRunning = true;
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write();
                }
            }

            while (player.gameRunning)
            {
                Methods.DoAction(Console.ReadLine(), ref player, player.currentLocation, ref locationdex, pokedex, movedex);
            }
            //THIS IS WHERE SAVE STUFF WILL HAPPEN
        }
    }
}
