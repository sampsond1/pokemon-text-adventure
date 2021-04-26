using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTextAdventure
{
    static partial class Methods
    {
        public static void Battle(ref Player _player, Pokemon _opposingPokemon, Move _struggle)
        {
            Pokemon activePokemon = _player.party[0];
            Move chosenMove;
            string currentCommand;
            bool ppOut;
            bool useMove;
            activePokemon.maxHitPoints = (2 * 30 * activePokemon.level) / 100 + activePokemon.level + 10;

            Console.Write("A wild "); WriteType(_opposingPokemon.name, _opposingPokemon.type); Console.WriteLine(" appeared!");
            Console.WriteLine("Go,"); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n");

            while (_opposingPokemon.isFainted != true && _player.party[0].isFainted != true && _player.party[1].isFainted != true && _player.party[2].isFainted != true)
            {
                ppOut = false;
                useMove = false;
                chosenMove = _struggle;

                Console.WriteLine("+-----------------------+".PadLeft(30));
                Console.Write("| ".PadLeft(30));Methods.WriteType(_opposingPokemon.name.PadRight(13), _opposingPokemon.type);Console.Write($"{_opposingPokemon.currentHitPoints}/{_opposingPokemon.maxHitPoints}".PadRight(9) + "|/n");
                Console.WriteLine("+-----------------------+/n".PadLeft(30));

                Console.WriteLine("+-----------------------+");
                Console.Write("| "); Methods.WriteType(activePokemon.name.PadRight(13), activePokemon.type); Console.Write($"{activePokemon.currentHitPoints}/{activePokemon.maxHitPoints}".PadRight(9) + "|/n");
                Console.WriteLine("+-----------------------+/n");

                Console.WriteLine("What would you like to do?");
                if (activePokemon.move[0].currentPowerPoints == 0 && activePokemon.move[1].currentPowerPoints == 0)
                {
                    ppOut = true;
                    Console.WriteLine("1. Use Struggle");
                    Console.WriteLine("3. Switch Pokémon");
                    Console.WriteLine("4. Throw a Pokéball");
                } else
                {
                    Console.WriteLine($"1. Use {activePokemon.move[0].name}");
                    Console.WriteLine($"2. Use {activePokemon.move[1].name}");
                    Console.WriteLine("3. Switch Pokémon");
                    Console.WriteLine("4. Throw a Pokéball");
                }

                

                currentCommand = Console.ReadLine();
                switch (currentCommand)
                {
                    case "1": //Move 1
                        chosenMove = activePokemon.move[0];
                        if (ppOut == true) { chosenMove = _struggle; }
                        useMove = true;
                        break;
                    case "2": //Move 2
                        chosenMove = activePokemon.move[1];
                        if (ppOut == true) { chosenMove = _struggle; }
                        useMove = true;
                        break;
                    case "3": //Switch Pokemon

                        break;
                    case "4": //Catch Pokemon

                        break;
                }

                if (useMove == true)
                {
                    if (chosenMove.restBefore == true)
                    {
                        ApplyMove();
                    }
                }
            }

        }

        public static void ApplyMove(Move move, Pokemon target)
        {

        }

        public static void ApplyMove(Pokemon opposingPokemon, Pokemon target)
        {
            Random random = new Random();
            if (opposingPokemon.sleepCounter > 0)
            {
                opposingPokemon.sleepCounter--;
                Console.Write("Enemy "); Methods.WriteType(opposingPokemon.name, opposingPokemon.type);Console.WriteLine(" is fast asleep!");
                return;
            }
            if (opposingPokemon.isParalyzed == true && random.Next(0, 4) == 3)
            {
                Console.Write("Enemy "); Methods.WriteType(opposingPokemon.name, opposingPokemon.type);Console.WriteLine(" is paralyzed! It can't move!");
                return;
            }
            if (target.isFlinching == true)
            {
                target.isFlinching = false;
                Console.Write("Enemy "); Methods.WriteType(opposingPokemon.name, opposingPokemon.type);Console.WriteLine(" flinched!");
                return;
            }
            Move currentMove = opposingPokemon.move[random.Next(0, 2)];
            Console.Write("Enemy "); Methods.WriteType(opposingPokemon.name, opposingPokemon.type); Console.WriteLine($" used {currentMove.name}!"); //SWIFT
            if (random.Next(0,101) <= (currentMove.accuracy + (10 * opposingPokemon.accuracyMod)))
            {
                //critical hit random.nextdouble
                target.currentHitPoints -= ((((2 * target.currentHitPoints) / 5) * currentMove.damage * opposingPokemon.attackStat / target.defenseStat) / 50) + 2;
            }
            else
            {
                Console.WriteLine("The attack missed!");
            }
        }

        public static void WriteType (string text, string type)
        {
            switch (type)
            {
                case "bug":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(text);
                    Console.ResetColor();
                    break;
                case "dragon":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(text);
                    Console.ResetColor();
                    break;
                case "electric":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(text);
                    Console.ResetColor();
                    break;
                case "fighting":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(text);
                    Console.ResetColor();
                    break;
                case "fire":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(text);
                    Console.ResetColor();
                    break;
                case "flying":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(text);
                    Console.ResetColor();
                    break;
                case "ghost":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(text);
                    Console.ResetColor();
                    break;
                case "grass":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(text);
                    Console.ResetColor();
                    break;
                case "ground":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(text);
                    Console.ResetColor();
                    break;
                case "ice":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(text);
                    Console.ResetColor();
                    break;
                case "normal":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(text);
                    Console.ResetColor();
                    break;
                case "poison":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(text);
                    Console.ResetColor();
                    break;
                case "psychic":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(text);
                    Console.ResetColor();
                    break;
                case "rock":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(text);
                    Console.ResetColor();
                    break;
                case "water":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(text);
                    Console.ResetColor();
                    break;
                default:
                    Console.Write("YA DONE MESSED UP AARON!");
                    break;
            }
        }
    }
}
