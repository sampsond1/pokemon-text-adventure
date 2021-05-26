using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTextAdventure
{
    static partial class Methods
    {
        public static bool TrainerBattle(ref Player player, Trainer trainer, Move _struggle)
        {
            Pokemon activePokemon = player.party[0];
            Move chosenMove;
            Move transform = _struggle;
            string currentCommand;
            bool ppOut;
            bool useMove;
            foreach (Pokemon pokemon in player.party)
            {
                if (pokemon.name == "Ditto") { transform = pokemon.move[0]; }
                else { transform = _struggle; }
            }
            Console.WriteLine($"{trainer.name.ToUpper()}: {trainer.challengeMessage}"); Console.Read();
            Console.WriteLine($"{trainer.type} {trainer.name} challenged you to a battle!"); Console.ReadKey();
            Console.Write("Go, ");activePokemon.WriteName();Console.WriteLine("!\n"); Console.ReadKey();
            while(trainer.trainerParty[0].name == "Missingno")
            {
                trainer.trainerParty.Remove(trainer.trainerParty[0]);
            }

            for (int i = 0; i < trainer.trainerParty.Count; i++ )
            {
                Pokemon opposingPokemon = trainer.trainerParty[i];
                activePokemon.maxHitPoints = (20 * activePokemon.hpStat * activePokemon.level) / 100 + activePokemon.level + 10;

                Console.Write($"{trainer.type} {trainer.name} sent out "); opposingPokemon.WriteName(); Console.WriteLine("!"); Console.ReadKey();


                while (opposingPokemon.isFainted == false)
                {
                    if ((player.party[0].isFainted == true || player.party[0].id == 0) && (player.party[1].isFainted == true || player.party[1].id == 0) && (player.party[2].isFainted == true || player.party[2].id == 0)) { goto PartyFainted; }

                    //Switches in a new Pokemon if the active one fainted last turn
                    if (activePokemon.isFainted == true)
                    {
                        Console.WriteLine("\nWhich Pokémon would you like to put in?");
                        if (player.party[0].isFainted == false && player.party[0].id != 0) { Console.Write("1. "); player.party[0].WriteName(); Console.Write("\n"); }
                        if (player.party[1].isFainted == false && player.party[1].id != 0) { Console.Write("2. "); player.party[1].WriteName(); Console.Write("\n"); }
                        if (player.party[2].isFainted == false && player.party[2].id != 0) { Console.Write("3. "); player.party[2].WriteName(); Console.Write("\n"); }

                        currentCommand = Console.ReadLine();

                        switch (currentCommand)
                        {
                            case "1":
                                if (player.party[0].isFainted == false && player.party[0].id != 0)
                                {
                                    activePokemon = player.party[0];
                                    Console.Write("\nGo,"); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n"); Console.ReadKey();
                                }
                                continue;
                            case "2":
                                if (player.party[1].isFainted == false && player.party[1].id != 0)
                                {
                                    activePokemon = player.party[1];
                                    Console.Write("\nGo,"); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n"); Console.ReadKey();
                                }
                                continue;
                            case "3":
                                if (player.party[2].isFainted == false && player.party[2].id != 0)
                                {
                                    activePokemon = player.party[2];
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
                    opposingPokemon.isFlinching = false;

                    //Displays all the Pokemons' information and asks what to do
                    Console.Clear();
                    Console.Write("\n\n\n");
                    Console.WriteLine("+-----------------------+".PadLeft(53));
                    Console.Write("| ".PadLeft(30)); Methods.WriteType(opposingPokemon.name.PadRight(13), opposingPokemon.type); Console.Write($"{opposingPokemon.currentHitPoints}/{opposingPokemon.maxHitPoints}".PadRight(9) + "|\n");
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
                            if (player.party[0].isFainted == false && player.party[0].id != 0) { Console.Write("1. "); player.party[0].WriteName(); Console.Write("\n"); }
                            if (player.party[1].isFainted == false && player.party[1].id != 0) { Console.Write("2. "); player.party[1].WriteName(); Console.Write("\n"); }
                            if (player.party[2].isFainted == false && player.party[2].id != 0) { Console.Write("3. "); player.party[2].WriteName(); Console.Write("\n"); }

                            currentCommand = Console.ReadLine();

                            switch (currentCommand)
                            {
                                case "1":
                                    if (player.party[0].isFainted == false && player.party[0].id != 0)
                                    {
                                        activePokemon = player.party[0];
                                        Console.Write("\nGo,"); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n");
                                    }
                                    continue;
                                case "2":
                                    if (player.party[1].isFainted == false && player.party[1].id != 0)
                                    {
                                        activePokemon = player.party[1];
                                        Console.Write("\nGo,"); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n");
                                    }
                                    continue;
                                case "3":
                                    if (player.party[2].isFainted == false && player.party[2].id != 0)
                                    {
                                        activePokemon = player.party[2];
                                        Console.Write("\nGo,"); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n");
                                    }
                                    continue;
                                default:
                                    Console.Write("\nCommand not recognized.\n"); Console.ReadKey();
                                    continue;
                            }
                        case "4": //Catch Pokemon

                            break;
                        default:
                            Console.WriteLine("\nCommand not recognized.\n"); Console.ReadKey();
                            break;
                    }
                    Random random = new Random();
                    Move opposingMove = opposingPokemon.move[random.Next(0, 2)];
                    while (opposingMove.currentPowerPoints == 0)
                    {
                        opposingMove = opposingPokemon.move[random.Next(0, 2)];
                    }

                    if (chosenMove.restBefore == true && useMove == true)
                    {
                        Console.Write("\n"); activePokemon.WriteName(); Console.WriteLine($" is charging up!"); Console.ReadKey();
                        ApplyMove(ref opposingMove, ref opposingPokemon, ref activePokemon);
                        if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref opposingPokemon) == true) { continue; }
                    }

                    if (chosenMove.name == "Quick Attack" && useMove == true)
                    {
                        ApplyMove(ref activePokemon, ref chosenMove, ref opposingPokemon);
                        if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref opposingPokemon) == true) { continue; }
                    }

                    if (opposingMove.name == "Quick Attack")
                    {
                        ApplyMove(ref opposingMove, ref opposingPokemon, ref activePokemon);
                        if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref opposingPokemon) == true) { continue; }
                    }

                    if (opposingPokemon.speedStat + opposingPokemon.speedMod > activePokemon.speedStat + activePokemon.speedMod && opposingMove.name != "Quick Attack")
                    {
                        ApplyMove(ref opposingMove, ref opposingPokemon, ref activePokemon);
                        if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref opposingPokemon) == true) { continue; }
                    }

                    if (chosenMove.name != "Quick Attack" && chosenMove.name != "Mirror Move" && useMove == true)
                    {
                        ApplyMove(ref activePokemon, ref chosenMove, ref opposingPokemon);
                        if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref opposingPokemon) == true) { continue; }
                    }

                    if (opposingPokemon.speedStat + opposingPokemon.speedMod <= activePokemon.speedStat + activePokemon.speedMod && opposingMove.name != "Quick Attack")
                    {
                        ApplyMove(ref opposingMove, ref opposingPokemon, ref activePokemon);
                        if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref opposingPokemon) == true) { continue; }
                    }

                    if (chosenMove.name == "Mirror Move" && useMove == true)
                    {
                        Console.Write("\n"); Methods.WriteType(activePokemon.name, activePokemon.type); Console.WriteLine($" used Mirror Move!"); Console.ReadKey();
                        ApplyMove(ref activePokemon, ref opposingMove, ref opposingPokemon);
                        if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref opposingPokemon) == true) { continue; }
                    }

                    if (opposingPokemon.isBurned == true) { Console.Write("The enemy "); opposingPokemon.WriteName(); Console.WriteLine($" took {opposingPokemon.maxHitPoints / 8} damage from its burn!"); opposingPokemon.currentHitPoints -= (opposingPokemon.maxHitPoints / 8); Console.ReadLine(); }
                    if (opposingPokemon.isPoisoned == true) { Console.Write("The enemy "); opposingPokemon.WriteName(); Console.WriteLine($" took {opposingPokemon.maxHitPoints / 16} damage from the poison!"); opposingPokemon.currentHitPoints -= (opposingPokemon.maxHitPoints / 16); Console.ReadLine(); }
                    if (opposingPokemon.gripCounter != 0) { Console.Write("The enemy "); opposingPokemon.WriteName(); Console.WriteLine($" took damage from being gripped!"); opposingPokemon.currentHitPoints -= (((((2 * activePokemon.level) / 5) * 15 * (activePokemon.attackStat + activePokemon.attackMod) / (opposingPokemon.defenseStat + opposingPokemon.defenseMod)) / 50) + 2); Console.ReadLine(); }
                    CheckIfFainted(ref opposingPokemon);

                    if (activePokemon.isBurned == true) { activePokemon.WriteName(); Console.WriteLine($" took {activePokemon.maxHitPoints / 8} damage from its burn!"); activePokemon.currentHitPoints -= (activePokemon.maxHitPoints / 8); Console.ReadLine(); }
                    if (activePokemon.isPoisoned == true) { activePokemon.WriteName(); Console.WriteLine($" took {activePokemon.maxHitPoints / 16} damage from the poison!"); activePokemon.currentHitPoints -= (activePokemon.maxHitPoints / 16); Console.ReadLine(); }
                    if (activePokemon.gripCounter != 0) { activePokemon.WriteName(); Console.WriteLine($" took damage from being gripped!"); activePokemon.currentHitPoints -= (((((2 * activePokemon.level) / 5) * 15 * (opposingPokemon.attackStat + opposingPokemon.attackMod) / (activePokemon.defenseStat + activePokemon.defenseMod)) / 50) + 2); Console.ReadLine(); }
                    CheckIfFainted(ref activePokemon);

                }
            
                if (opposingPokemon.isFainted == true)
                {
                    foreach (Pokemon pokemon in player.party)
                    {
                        if (pokemon.didParticipate == true && pokemon.isFainted == false && pokemon.level < 100) { pokemon.level++; pokemon.WriteName(); Console.WriteLine(" gained a level!"); Console.ReadKey(); }
                        pokemon.didParticipate = false;
                    }

                }
            }

            Console.WriteLine($"{trainer.type} {trainer.name} was defeated!"); Console.ReadKey();
            Console.WriteLine($"{trainer.name}: {trainer.defeatMessage}"); Console.ReadKey();

            foreach (Pokemon pokemon in player.party)
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

                pokemon.hpMod = 0;
                pokemon.attackMod = 0;
                pokemon.defenseMod = 0;
                pokemon.speedMod = 0;
                pokemon.accuracyMod = 0;
                pokemon.critMod = 1;
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

        PartyFainted:
            Console.WriteLine($"{player.name} has no more usable Pokémon!");Console.ReadKey();
            Console.WriteLine($"{player.name} whited out!");
            return false;
        }
    }
}
