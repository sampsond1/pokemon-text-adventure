using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTextAdventure
{
    static partial class Methods
    {
        public static bool WildBattle(ref Player _player, Pokemon _opposingPokemon, Move _struggle)
        {
            Pokemon activePokemon = _player.party[0];
            Move chosenMove;
            Move transform = _struggle;
            string currentCommand;
            bool ppOut;
            bool useMove;
            activePokemon.maxHitPoints = (20 * activePokemon.hpStat * activePokemon.level) / 100 + activePokemon.level + 10;
            foreach (Pokemon pokemon in _player.party)
            {
                if (pokemon.name == "Ditto") { transform = pokemon.move[0]; }
            }

            Console.Write("A wild "); WriteType(_opposingPokemon.name, _opposingPokemon.type); Console.WriteLine(" appeared!"); Console.ReadKey();
            Console.Write("Go, "); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n"); Console.ReadKey();

            while (_opposingPokemon.isFainted == false)
            {
                if ((_player.party[0].isFainted == true || _player.party[0].id == 0) && (_player.party[1].isFainted == true || _player.party[1].id == 0) && (_player.party[2].isFainted == true || _player.party[2].id == 0)) { goto PartyFainted; }

                //Switches in a new Pokemon if the active one fainted last turn
                if (activePokemon.isFainted == true)
                {
                    Console.WriteLine("\nWhich Pokémon would you like to put in?");
                    if (_player.party[0].isFainted == false && _player.party[0].id != 0) { Console.Write("1. "); _player.party[0].WriteName(); Console.Write("\n"); }
                    if (_player.party[1].isFainted == false && _player.party[1].id != 0) { Console.Write("2. "); _player.party[1].WriteName(); Console.Write("\n"); }
                    if (_player.party[2].isFainted == false && _player.party[2].id != 0) { Console.Write("3. "); _player.party[2].WriteName(); Console.Write("\n"); }

                    currentCommand = Console.ReadLine();

                    switch (currentCommand)
                    {
                        case "1":
                            if (_player.party[0].isFainted == false && _player.party[0].id != 0)
                            {
                                activePokemon = _player.party[0];
                                Console.Write("\nGo,"); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n"); Console.ReadKey();
                            }
                            continue;
                        case "2":
                            if (_player.party[1].isFainted == false && _player.party[1].id != 0)
                            {
                                activePokemon = _player.party[1];
                                Console.Write("\nGo,"); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n"); Console.ReadKey();
                            }
                            continue;
                        case "3":
                            if (_player.party[2].isFainted == false && _player.party[2].id != 0)
                            {
                                activePokemon = _player.party[2];
                                Console.Write("\nGo,"); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n"); Console.ReadKey();
                            }
                            continue;
                        default:
                            Console.Write("Command not recognized."); Console.ReadKey();
                            continue;

                    }
                }

                ppOut = false;
                useMove = false;
                chosenMove = _struggle;
                activePokemon.didParticipate = true;
                activePokemon.isFlinching = false;
                _opposingPokemon.isFlinching = false;

                //Displays all the Pokemons' information and asks what to do
                Console.Clear();
                Console.Write("\n\n\n");
                Console.WriteLine("+-----------------------+".PadLeft(53));
                Console.Write("| ".PadLeft(30)); Methods.WriteType(_opposingPokemon.name.PadRight(13), _opposingPokemon.type); Console.Write($"{_opposingPokemon.currentHitPoints}/{_opposingPokemon.maxHitPoints}".PadRight(9) + "|\n");
                Console.WriteLine("+-----------------------+\n".PadLeft(54));

                Console.WriteLine("+-----------------------+");
                Console.Write("| "); Methods.WriteType(activePokemon.name.PadRight(13), activePokemon.type); Console.Write($"{activePokemon.currentHitPoints}/{activePokemon.maxHitPoints}".PadRight(9) + "|\n");
                Console.WriteLine("+-----------------------+\n");

                Console.WriteLine("What would you like to do?");
                if (activePokemon.move[0].currentPowerPoints == 0 && activePokemon.move[1].currentPowerPoints == 0)
                {
                    ppOut = true;
                    Console.WriteLine("1. Use Struggle");
                    Console.WriteLine("3. Switch Pokémon");
                    Console.WriteLine("4. Throw a Pokéball");
                }
                else
                {
                    Console.WriteLine($"1. Use {activePokemon.move[0].name} | {activePokemon.move[0].currentPowerPoints} / {activePokemon.move[0].powerPoints} PP");
                    Console.WriteLine($"2. Use {activePokemon.move[1].name} | {activePokemon.move[1].currentPowerPoints} / {activePokemon.move[1].powerPoints} PP");
                    Console.WriteLine("3. Switch Pokémon");
                    Console.WriteLine("4. Throw a Pokéball");
                }

                currentCommand = Console.ReadLine();
                switch (currentCommand)
                {
                    case "1": //Move 1
                        chosenMove = activePokemon.move[0];
                        if (ppOut == true || chosenMove.currentPowerPoints == 0) { chosenMove = _struggle; }
                        useMove = true;
                        break;
                    case "2": //Move 2
                        chosenMove = activePokemon.move[1];
                        if (ppOut == true || chosenMove.currentPowerPoints == 0) { chosenMove = _struggle; }
                        useMove = true;
                        break;
                    case "3": //Switch Pokemon
                        activePokemon.WriteName(); Console.WriteLine(", return!\n"); Console.ReadKey();
                        Console.WriteLine("\nWhich Pokémon would you like to put in?");
                        if (_player.party[0].isFainted == false && _player.party[0].id != 0) { Console.Write("1. "); _player.party[0].WriteName(); Console.Write("\n"); }
                        if (_player.party[1].isFainted == false && _player.party[1].id != 0) { Console.Write("2. "); _player.party[1].WriteName(); Console.Write("\n"); }
                        if (_player.party[2].isFainted == false && _player.party[2].id != 0) { Console.Write("3. "); _player.party[2].WriteName(); Console.Write("\n"); }

                        currentCommand = Console.ReadLine();

                        switch (currentCommand)
                        {
                            case "1":
                                if (_player.party[0].isFainted == false && _player.party[0].id != 0)
                                {
                                    activePokemon = _player.party[0];
                                    Console.Write("\nGo,"); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n");
                                }
                                continue;
                            case "2":
                                if (_player.party[1].isFainted == false && _player.party[1].id != 0)
                                {
                                    activePokemon = _player.party[1];
                                    Console.Write("\nGo,"); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n");
                                }
                                continue;
                            case "3":
                                if (_player.party[2].isFainted == false && _player.party[2].id != 0)
                                {
                                    activePokemon = _player.party[2];
                                    Console.Write("\nGo,"); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n");
                                }
                                continue;
                            default:
                                Console.Write("\nCommand not recognized.\n"); Console.ReadKey();
                                continue;
                        }
                    case "4": //Catch Pokemon
                        Console.WriteLine($"{_player.name} threw a Pokéball!"); Console.ReadKey();
                        Random randomOne = new Random();
                        if (randomOne.Next(101) > Convert.ToInt32((Convert.ToDouble(_opposingPokemon.currentHitPoints) / Convert.ToDouble(_opposingPokemon.maxHitPoints)) * 100))
                        {
                            Console.Write("Gotcha! The enemy "); _opposingPokemon.WriteName(); Console.WriteLine(" was caught!"); Console.ReadKey();
                            if (_player.party[1].id == 0)
                            {
                                _player.party[1] = _opposingPokemon;
                                _player.party[1].WriteName(); Console.WriteLine(" has been added to your party."); Console.ReadKey();
                                return true;
                            }
                            else if (_player.party[2].id == 0)
                            {
                                _player.party[1] = _opposingPokemon;
                                _player.party[1].WriteName(); Console.WriteLine(" has been added to your party."); Console.ReadKey();
                                return true;
                            }
                            else
                            {
                                _opposingPokemon.Heal();
                                _player.pcPokemon.Add(_opposingPokemon);
                                _opposingPokemon.WriteName();Console.WriteLine(" was sent to your PC.");
                                return true;
                            }
                        }
                        else { Console.Write("The enemy ");_opposingPokemon.WriteName();Console.WriteLine(" broke free!"); }
                        break;
                    default:
                        Console.WriteLine("\nCommand not recognized.\n"); Console.ReadKey();
                        break;
                }

                Random random = new Random();
                Move opposingMove = _opposingPokemon.move[random.Next(0, 2)];
                while (opposingMove.currentPowerPoints == 0)
                {
                    opposingMove = _opposingPokemon.move[random.Next(0, 2)];
                }

                if (chosenMove.restBefore == true && useMove == true)
                {
                    Console.Write("\n"); activePokemon.WriteName(); Console.WriteLine($" is charging up!"); Console.ReadKey();
                    ApplyMove(ref opposingMove, ref _opposingPokemon, ref activePokemon);
                    if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref _opposingPokemon) == true) { continue; }
                }

                if (chosenMove.name == "Quick Attack" && useMove == true)
                {
                    ApplyMove(ref activePokemon, ref chosenMove, ref _opposingPokemon);
                    if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref _opposingPokemon) == true) { continue; }
                }

                if (opposingMove.name == "Quick Attack")
                {
                    ApplyMove(ref opposingMove, ref _opposingPokemon, ref activePokemon);
                    if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref _opposingPokemon) == true) { continue; }
                }

                if (_opposingPokemon.speedStat + _opposingPokemon.speedMod > activePokemon.speedStat + activePokemon.speedMod && opposingMove.name != "Quick Attack")
                {
                    ApplyMove(ref opposingMove, ref _opposingPokemon, ref activePokemon);
                    if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref _opposingPokemon) == true) { continue; }
                }

                if (chosenMove.name != "Quick Attack" && chosenMove.name != "Mirror Move" && useMove == true)
                {
                    ApplyMove(ref activePokemon, ref chosenMove, ref _opposingPokemon);
                    if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref _opposingPokemon) == true) { continue; }
                }

                if (_opposingPokemon.speedStat + _opposingPokemon.speedMod <= activePokemon.speedStat + activePokemon.speedMod && opposingMove.name != "Quick Attack")
                {
                    ApplyMove(ref opposingMove, ref _opposingPokemon, ref activePokemon);
                    if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref _opposingPokemon) == true) { continue; }
                }

                if (chosenMove.name == "Mirror Move" && useMove == true)
                {
                    Console.Write("\n"); Methods.WriteType(activePokemon.name, activePokemon.type); Console.WriteLine($" used Mirror Move!"); Console.ReadKey();
                    ApplyMove(ref activePokemon, ref opposingMove, ref _opposingPokemon);
                    if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref _opposingPokemon) == true) { continue; }
                }

        

                if (_opposingPokemon.isBurned == true) { Console.Write("The enemy "); _opposingPokemon.WriteName(); Console.WriteLine($" took {_opposingPokemon.maxHitPoints / 8} damage from its burn!"); _opposingPokemon.currentHitPoints -= (_opposingPokemon.maxHitPoints / 8); Console.ReadLine(); }
                if (_opposingPokemon.isPoisoned == true) { Console.Write("The enemy "); _opposingPokemon.WriteName(); Console.WriteLine($" took {_opposingPokemon.maxHitPoints / 16} damage from the poison!"); _opposingPokemon.currentHitPoints -= (_opposingPokemon.maxHitPoints / 16); Console.ReadLine(); }
                if (_opposingPokemon.gripCounter != 0) { Console.Write("The enemy "); _opposingPokemon.WriteName(); Console.WriteLine($" took damage from being gripped!"); _opposingPokemon.currentHitPoints -= (((((2 * activePokemon.level) / 5) * 15 * (activePokemon.attackStat + activePokemon.attackMod) / (_opposingPokemon.defenseStat + _opposingPokemon.defenseMod)) / 50) + 2); Console.ReadLine(); }
                CheckIfFainted(ref _opposingPokemon);

                if (activePokemon.isBurned == true) { activePokemon.WriteName(); Console.WriteLine($" took {activePokemon.maxHitPoints / 8} damage from its burn!"); activePokemon.currentHitPoints -= (activePokemon.maxHitPoints / 8); Console.ReadLine(); }
                if (activePokemon.isPoisoned == true) { activePokemon.WriteName(); Console.WriteLine($" took {activePokemon.maxHitPoints / 16} damage from the poison!"); activePokemon.currentHitPoints -= (activePokemon.maxHitPoints / 16); Console.ReadLine(); }
                if (activePokemon.gripCounter != 0) { activePokemon.WriteName(); Console.WriteLine($" took damage from being gripped!"); activePokemon.currentHitPoints -= (((((2 * activePokemon.level) / 5) * 15 * (_opposingPokemon.attackStat + _opposingPokemon.attackMod) / (activePokemon.defenseStat + activePokemon.defenseMod)) / 50) + 2); Console.ReadLine(); }
                CheckIfFainted(ref activePokemon);
                

            }

            if (_opposingPokemon.isFainted == true)
            {
                foreach (Pokemon pokemon in _player.party)
                {
                    if (pokemon.name == "Ditto")
                    {
                        pokemon.type = "normal";
                        pokemon.move[0] = transform;
                        pokemon.move[1] = transform;
                        pokemon.move[0].currentPowerPoints = 10;
                        pokemon.move[1].currentPowerPoints = 10;
                        pokemon.attackStat = 3;
                        pokemon.defenseStat = 2;
                        pokemon.speedStat = 3;
                        pokemon.hpStat = 2;
                    }
                    if (pokemon.didParticipate == true && pokemon.isFainted == false && pokemon.level != 100) { pokemon.level++; pokemon.WriteName(); Console.WriteLine(" gained a level!"); Console.ReadKey(); }
                    pokemon.hpMod = 0;
                    pokemon.attackMod = 0;
                    pokemon.defenseMod = 0;
                    pokemon.speedMod = 0;
                    pokemon.accuracyMod = 0;
                    pokemon.didParticipate = false;
                    pokemon.isFlinching = false;
                    pokemon.gripCounter = 0;
                    if (pokemon.level >= pokemon.evolvesAt && pokemon.id != 0)
                    {
                        pokemon.WriteName(); Console.Write(" evolved into a "); Methods.WriteType(pokemon.evolvesTo, pokemon.type); Console.WriteLine("!");
                        pokemon.hasEvolved = true;
                        Console.ReadKey();
                    }
                }
                return true;

            }
        PartyFainted:
            Console.WriteLine($"{_player.name} has no more usable Pokémon!"); Console.ReadKey();
            Console.WriteLine($"{_player.name} whited out!");
            return false;
        }
    }
}
