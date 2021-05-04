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
            Console.Write("Go, "); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n");

            while (_opposingPokemon.isFainted == false )
            {
                if (_player.party[0].isFainted == true && _player.party[1].isFainted == true && _player.party[2].isFainted == true) { goto PartyFainted; }

                if (activePokemon.isFainted == true)
                {
                    Console.WriteLine("\nWhich Pokémon would you like to put in?");
                    if (_player.party[0].isFainted == false) { Console.Write("1. "); _player.party[0].WriteName(); Console.Write("\n"); }
                    if (_player.party[1].isFainted == false) { Console.Write("2. "); _player.party[1].WriteName(); Console.Write("\n"); }
                    if (_player.party[2].isFainted == false) { Console.Write("3. "); _player.party[2].WriteName(); Console.Write("\n"); }

                    currentCommand = Console.ReadLine();

                    switch (currentCommand)
                    {
                        case "1":
                            activePokemon = _player.party[0];
                            Console.Write("Go, "); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n");
                            continue;
                        case "2":
                            activePokemon = _player.party[1];
                            Console.Write("Go, "); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n");
                            continue;
                        case "3":
                            activePokemon = _player.party[2];
                            Console.Write("Go, "); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n");
                            continue;
                        default:
                            Console.WriteLine("Command not recognized.");
                            continue;
                    }
                }

                ppOut = false;
                useMove = false;
                chosenMove = _struggle;
                activePokemon.didParticipate = true;

                Console.WriteLine("+-----------------------+".PadLeft(53));
                Console.Write("| ".PadLeft(30));Methods.WriteType(_opposingPokemon.name.PadRight(13), _opposingPokemon.type);Console.Write($"{_opposingPokemon.currentHitPoints}/{_opposingPokemon.maxHitPoints}".PadRight(9) + "|\n");
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
                        activePokemon.WriteName();Console.WriteLine(", return!\n");
                        Console.WriteLine("Which Pokémon would you like to put in?");
                        if (_player.party[0].isFainted == false) { Console.Write("1. "); _player.party[0].WriteName(); Console.Write("\n"); }
                        if (_player.party[1].isFainted == false) { Console.Write("2. "); _player.party[1].WriteName(); Console.Write("\n"); }
                        if (_player.party[2].isFainted == false) { Console.Write("3. "); _player.party[2].WriteName(); Console.Write("\n"); }

                        currentCommand = Console.ReadLine();

                        switch (currentCommand)
                        {
                            case "1":
                                activePokemon = _player.party[0];
                                Console.Write("\nGo,"); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n");
                                continue;
                            case "2":
                                activePokemon = _player.party[1];
                                Console.Write("\nGo,"); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n");
                                continue;
                            case "3":
                                activePokemon = _player.party[2];
                                Console.Write("\nGo,"); WriteType(activePokemon.name, activePokemon.type); Console.WriteLine("!\n");
                                continue;

                        }
                        break;
                    case "4": //Catch Pokemon

                        break;
                    default:
                        Console.WriteLine("Command not recognized.");
                        break;
                }

                if (useMove == true)
                {
                    if (chosenMove.restBefore == true)
                    {
                        ApplyMove(ref _opposingPokemon, ref activePokemon);
                        if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref _opposingPokemon) == true) { continue; }
                    }

                    if (chosenMove.name == "Quick Attack")
                    {
                        ApplyMove(ref activePokemon, ref chosenMove, ref _opposingPokemon);
                        if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref _opposingPokemon) == true) { continue; }
                    }

                    if (_opposingPokemon.speedStat + _opposingPokemon.speedMod > activePokemon.speedStat + activePokemon.speedMod)
                    {
                        ApplyMove(ref _opposingPokemon, ref activePokemon);
                        if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref _opposingPokemon) == true) { continue; }
                    }

                    if (chosenMove.name != "Quick Attack" && chosenMove.name != "Mirror Move")
                    {
                        ApplyMove(ref activePokemon, ref chosenMove, ref _opposingPokemon);
                        if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref _opposingPokemon) == true) { continue; }
                    }

                    if (_opposingPokemon.speedStat + _opposingPokemon.speedMod <= activePokemon.speedStat + activePokemon.speedMod)
                    {
                        ApplyMove(ref _opposingPokemon, ref activePokemon);
                        if (CheckIfFainted(ref activePokemon) == true || CheckIfFainted(ref _opposingPokemon) == true) { continue; }
                    }
                }
            }

            PartyFainted:
            if (_opposingPokemon.isFainted == true)
            {
                foreach (Pokemon pokemon in _player.party)
                {
                    if (pokemon.didParticipate == true && pokemon.isFainted == false && pokemon.level != 100) { pokemon.level++; pokemon.WriteName(); Console.WriteLine(" gained a level!"); }
                    pokemon.hpMod = 0;
                    pokemon.attackMod = 0;
                    pokemon.defenseMod = 0;
                    pokemon.speedMod = 0;
                    pokemon.accuracyMod = 0;
                    pokemon.didParticipate = false;
                    pokemon.isFlinching = false;
                    pokemon.gripCounter = 0;
                    if (pokemon.level >= pokemon.evolvesAt)
                    {
                        pokemon.WriteName();Console.Write(" evolved into a ");Methods.WriteType(pokemon.evolvesTo, pokemon.type);Console.WriteLine("!");
                        pokemon.hasEvolved = true;
                    }
                }
                
            }

        }

        public static void ApplyMove(ref Pokemon opposingPokemon, ref Pokemon target)
        {
            int critHitMultiplier = 1;
            int damage;
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
            while (currentMove.currentPowerPoints == 0)
            {
                currentMove = opposingPokemon.move[random.Next(0, 2)];
            }
            Console.Write("\nEnemy "); Methods.WriteType(opposingPokemon.name, opposingPokemon.type); Console.WriteLine($" used {currentMove.name}!");

            for (int i = currentMove.numberTimesHit; i > 0; i--)
            {
                if (random.Next(0, 101) <= (currentMove.accuracy * (Math.Pow(.66, opposingPokemon.accuracyMod))) || currentMove.name == "Swift")
                {
                    //SPECIAL CASES

                    if (currentMove.name == "Dream Eater")
                    {
                        if (currentMove.critChance != 0 && random.NextDouble() <= (currentMove.critChance * opposingPokemon.critMod)) { critHitMultiplier = 2; }
                        damage = (((((2 * opposingPokemon.level) / 5) * currentMove.damage * (opposingPokemon.attackStat + opposingPokemon.attackMod) / (target.defenseStat + target.defenseMod)) / 50) + 2) * critHitMultiplier;
                        target.currentHitPoints -= damage;
                        currentMove.currentPowerPoints--;
                        Console.WriteLine($"It dealt {damage} damage!");
                        critHitMultiplier = 1;
                        opposingPokemon.currentHitPoints += damage / 2;
                        if (opposingPokemon.currentHitPoints >= opposingPokemon.maxHitPoints) { opposingPokemon.currentHitPoints = opposingPokemon.maxHitPoints; }
                        opposingPokemon.WriteName(); Console.Write(" healed itself by eating "); target.WriteName(); Console.WriteLine("'s dream!");
                        return;
                    }

                    if (currentMove.name == "Guillotine" || currentMove.name == "Horn Drill")
                    {
                        target.currentHitPoints = 0;
                        currentMove.currentPowerPoints--;
                        target.isFainted = true;
                        Console.WriteLine("It's a one-hit KO!");
                        target.WriteName(); Console.WriteLine(" fainted!");
                        return;
                    }

                    if (currentMove.name == "Night Shade") { currentMove.damage = target.level; }

                    if (currentMove.name == "Splash") { currentMove.currentPowerPoints--; Console.WriteLine("But nothing happened!"); return; }

                    if (currentMove.name == "Super Fang")
                    {
                        currentMove.currentPowerPoints--;
                        Console.WriteLine($"It dealt {target.currentHitPoints / 2} damage!");
                        target.currentHitPoints /= 2;
                        return;
                    }

                    //NORMAL CASES

                    if (currentMove.critChance != 0 && random.NextDouble() <= (currentMove.critChance * opposingPokemon.critMod)) { critHitMultiplier = 2; }
                    damage = (((((2 * opposingPokemon.level) / 5) * currentMove.damage * (opposingPokemon.attackStat + opposingPokemon.attackMod) / (target.defenseStat + target.defenseMod)) / 50) + 2) * critHitMultiplier;
                    target.currentHitPoints = (target.currentHitPoints - damage);
                    currentMove.powerPoints--;
                    Console.WriteLine($"It dealt {damage} damage!");
                    if (critHitMultiplier == 2) { Console.WriteLine("A critical hit!"); }
                    critHitMultiplier = 1;

                    if (currentMove.causeBurn == true && random.NextDouble() < currentMove.effectChance && target.isBurned == false) { target.isBurned = true; target.WriteName(); Console.WriteLine(" was burned!"); }
                    if (currentMove.causePoison == true && random.NextDouble() < currentMove.effectChance && target.isPoisoned == false) { target.isPoisoned = true; target.WriteName(); Console.WriteLine(" was poisoned!"); }
                    if (currentMove.causeSleep == true && random.NextDouble() < currentMove.effectChance && target.sleepCounter == 0) { target.sleepCounter = random.Next(2, 6); target.WriteName(); Console.WriteLine(" fell asleep!"); }
                    if (currentMove.causeParalysis == true && random.NextDouble() < currentMove.effectChance && target.isParalyzed == false) { target.isPoisoned = true; target.WriteName(); Console.WriteLine(" was paralyzed!"); }
                    if (currentMove.causeFlinch == true && random.NextDouble() < currentMove.effectChance && target.isFlinching == false) { target.isFlinching = true; }
                    if (currentMove.gripDamage != 0 && random.NextDouble() < currentMove.effectChance && target.gripCounter == 0) { target.gripCounter = random.Next(2, 6); target.WriteName(); Console.WriteLine(" has been gripped!"); }
                    if (currentMove.recoilDamage != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        if (currentMove.recoilDamage == 1) { opposingPokemon.WriteName(); Console.WriteLine($" dealt {opposingPokemon.currentHitPoints} damage to itself!"); opposingPokemon.currentHitPoints = 0; }
                        else { opposingPokemon.WriteName(); Console.WriteLine($" dealt {damage * currentMove.recoilDamage} to itself!"); opposingPokemon.currentHitPoints -= Convert.ToInt16(Math.Floor((damage * currentMove.recoilDamage))); }
                    }
                    if (currentMove.hpGain != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        if (currentMove.name == "Recover")
                        {
                            opposingPokemon.currentHitPoints += (opposingPokemon.maxHitPoints / 2);
                            if (opposingPokemon.currentHitPoints > opposingPokemon.maxHitPoints) { opposingPokemon.currentHitPoints = opposingPokemon.maxHitPoints; }
                            opposingPokemon.WriteName();Console.WriteLine(" healed itself!");
                        }
                        if (currentMove.name == "Rest")
                        {
                            opposingPokemon.currentHitPoints = opposingPokemon.maxHitPoints;
                            opposingPokemon.isBurned = false;
                            opposingPokemon.isParalyzed = false;
                            opposingPokemon.isPoisoned = false;
                            opposingPokemon.sleepCounter = random.Next(2, 6);
                            opposingPokemon.WriteName();Console.WriteLine(" fully healed itself!");
                            opposingPokemon.WriteName(); Console.WriteLine(" fell asleep!");
                        }
                    }
                    if (currentMove.attackBoost != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        opposingPokemon.attackMod += currentMove.attackBoost;
                        opposingPokemon.WriteName();Console.WriteLine("'s attack rose!");
                        if (opposingPokemon.attackMod > 6) { opposingPokemon.attackMod = 6; Console.WriteLine("Its attack can't go any higher!"); }
                    }
                    if (currentMove.defenseBoost != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        opposingPokemon.defenseMod += currentMove.defenseBoost;
                        opposingPokemon.WriteName(); Console.WriteLine("'s defense rose!");
                        if (opposingPokemon.defenseMod > 6) { opposingPokemon.defenseMod = 6; Console.WriteLine("Its defense can't go any higher!"); }
                    }
                    if (currentMove.critBoost != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        opposingPokemon.critMod += currentMove.critBoost;
                        opposingPokemon.WriteName(); Console.WriteLine(" is getting pumped!");
                        if (opposingPokemon.critMod > 6) { opposingPokemon.critMod = 6; Console.WriteLine("It can't get any more pumped!"); }
                    }
                    if (currentMove.speedBoost != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        opposingPokemon.speedMod += currentMove.speedBoost;
                        opposingPokemon.WriteName(); Console.WriteLine("'s speed rose!");
                        if (opposingPokemon.speedMod > 6) { opposingPokemon.speedMod = 6; Console.WriteLine("Its speed can't go any higher!"); }
                    }
                    if (currentMove.attackPenalty != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        target.attackMod -= currentMove.attackPenalty;
                        if (target.attackMod + target.attackStat <= 0)
                        {
                            target.attackMod = target.attackStat - 1;
                            target.WriteName();Console.WriteLine("'s attack can't go any lower!");
                        }
                        target.WriteName(); Console.WriteLine("'s attack fell!");
                        if (target.attackMod < -6) { opposingPokemon.attackMod = 6; Console.WriteLine("Its attack can't go any lower!"); }
                    }
                    if (currentMove.defensePenalty != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        target.defenseMod -= currentMove.defensePenalty;
                        if (target.attackMod + target.attackStat <= 0)
                        {
                            target.defenseMod = target.defenseStat - 1;
                            target.WriteName(); Console.WriteLine("'s defense can't go any lower!");
                        }
                        target.WriteName(); Console.WriteLine("'s defense fell!");
                        if (target.defenseMod < -6) { opposingPokemon.defenseMod = 6; Console.WriteLine("Its defense can't go any lower!"); }
                    }
                    if (currentMove.speedPenalty != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        target.speedMod -= currentMove.speedPenalty;
                        if (target.speedMod + target.speedStat <= 0)
                        {
                            target.attackMod = target.attackStat - 1;
                            target.WriteName(); Console.WriteLine("'s speed can't go any lower!");
                        }
                        target.WriteName(); Console.WriteLine("'s speed fell!");
                        if (target.speedMod < -6) { opposingPokemon.speedMod = 6; Console.WriteLine("Its speed can't go any lower!"); }
                    }
                    if (currentMove.accuracyPenalty != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        target.accuracyMod -= currentMove.accuracyPenalty;
                        target.WriteName(); Console.WriteLine("'s accuracy fell!");
                        if (target.accuracyMod < -6) { opposingPokemon.accuracyMod = 6; Console.WriteLine("Its accuracy can't go any lower!"); }
                    }
    
                }
                else
                {
                    Console.WriteLine("The attack missed!");
                    currentMove.currentPowerPoints--;
                }
                Console.ReadLine();
            }
        }

        public static void ApplyMove(ref Pokemon activePokemon,ref Move currentMove, ref Pokemon target)
        {
            int critHitMultiplier = 1;
            int damage;
            Random random = new Random();

            if (activePokemon.sleepCounter > 0)
            {
                activePokemon.sleepCounter--;
                Methods.WriteType(activePokemon.name, activePokemon.type); Console.WriteLine(" is fast asleep!");
                return;
            }
            if (activePokemon.isParalyzed == true && random.Next(0, 4) == 3)
            {
                Methods.WriteType(activePokemon.name, activePokemon.type); Console.WriteLine(" is paralyzed! It can't move!");
                return;
            }
            if (target.isFlinching == true)
            {
                target.isFlinching = false;
                Methods.WriteType(activePokemon.name, activePokemon.type); Console.WriteLine(" flinched!");
                return;
            }

            Console.Write("\n"); Methods.WriteType(activePokemon.name, activePokemon.type); Console.WriteLine($" used {currentMove.name}!");

            for (int i = currentMove.numberTimesHit; i > 0; i--)
            {
                if (random.Next(0, 101) <= (currentMove.accuracy * (Math.Pow(.66, activePokemon.accuracyMod))) || currentMove.name == "Swift")
                {
                    //SPECIAL CASES

                    if (currentMove.name == "Dream Eater")
                    {
                        if (currentMove.critChance != 0 && random.NextDouble() <= (currentMove.critChance * activePokemon.critMod)) { critHitMultiplier = 2; }
                        damage = (((((2 * activePokemon.level) / 5) * currentMove.damage * (activePokemon.attackStat + activePokemon.attackMod) / (target.defenseStat + target.defenseMod)) / 50) + 2) * critHitMultiplier;
                        target.currentHitPoints -= damage;
                        currentMove.currentPowerPoints--;
                        Console.WriteLine($"It dealt {damage} damage!");
                        critHitMultiplier = 1;
                        activePokemon.currentHitPoints += damage / 2;
                        if (activePokemon.currentHitPoints >= activePokemon.maxHitPoints) { activePokemon.currentHitPoints = activePokemon.maxHitPoints; }
                        activePokemon.WriteName(); Console.Write(" healed itself by eating "); target.WriteName(); Console.WriteLine("'s dream!");
                        return;
                    }

                    if (currentMove.name == "Guillotine" || currentMove.name == "Horn Drill")
                    {
                        target.currentHitPoints = 0;
                        currentMove.currentPowerPoints--;
                        target.isFainted = true;
                        Console.WriteLine("It's a one-hit KO!");
                        target.WriteName(); Console.WriteLine(" fainted!");
                        return;
                    }

                    if (currentMove.name == "Night Shade") { currentMove.damage = target.level; }

                    if (currentMove.name == "Splash") { currentMove.currentPowerPoints--; Console.WriteLine("But nothing happened!"); return; }

                    if (currentMove.name == "Super Fang")
                    {
                        currentMove.currentPowerPoints--;
                        Console.WriteLine($"It dealt {target.currentHitPoints / 2} damage!");
                        target.currentHitPoints /= 2;
                        return;
                    }

                    //NORMAL CASES

                    if (currentMove.critChance != 0 && random.NextDouble() <= (currentMove.critChance * activePokemon.critMod)) { critHitMultiplier = 2; }
                    damage = (((((2 * activePokemon.level) / 5) * currentMove.damage * (activePokemon.attackStat + activePokemon.attackMod) / (target.defenseStat + target.defenseMod)) / 50) + 2) * critHitMultiplier;
                    target.currentHitPoints -= damage;
                    currentMove.currentPowerPoints--;
                    Console.WriteLine($"It dealt {damage} damage!");
                    critHitMultiplier = 1;

                    if (currentMove.causeBurn == true && random.NextDouble() < currentMove.effectChance && target.isBurned == false) { target.isBurned = true; activePokemon.WriteName(); Console.WriteLine(" was burned!"); }
                    if (currentMove.causePoison == true && random.NextDouble() < currentMove.effectChance && target.isPoisoned == false) { target.isPoisoned = true; activePokemon.WriteName(); Console.WriteLine(" was poisoned!"); }
                    if (currentMove.causeSleep == true && random.NextDouble() < currentMove.effectChance && target.sleepCounter == 0) { target.sleepCounter = random.Next(2, 6); activePokemon.WriteName(); Console.WriteLine(" fell asleep!"); }
                    if (currentMove.causeParalysis == true && random.NextDouble() < currentMove.effectChance && target.isParalyzed == false) { target.isPoisoned = true; activePokemon.WriteName(); Console.WriteLine(" was paralyzed!"); }
                    if (currentMove.causeFlinch == true && random.NextDouble() < currentMove.effectChance && target.isFlinching == false) { target.isFlinching = true; }
                    if (currentMove.gripDamage != 0 && random.NextDouble() < currentMove.effectChance && target.gripCounter == 0) { target.gripCounter = random.Next(2, 6); activePokemon.WriteName(); Console.WriteLine(" has been gripped!"); }
                    if (currentMove.recoilDamage != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        if (currentMove.recoilDamage == 1) { activePokemon.WriteName(); Console.WriteLine($" dealt {activePokemon.currentHitPoints} damage to itself!"); activePokemon.currentHitPoints = 0; }
                        else { activePokemon.WriteName(); Console.WriteLine($" dealt {damage * currentMove.recoilDamage} to itself!"); activePokemon.currentHitPoints -= Convert.ToInt16(Math.Floor((damage * currentMove.recoilDamage))); }
                    }
                    if (currentMove.hpGain != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        if (currentMove.name == "Recover")
                        {
                            activePokemon.currentHitPoints += (activePokemon.maxHitPoints / 2);
                            if (activePokemon.currentHitPoints > activePokemon.maxHitPoints) { activePokemon.currentHitPoints = activePokemon.maxHitPoints; }
                            activePokemon.WriteName(); Console.WriteLine(" healed itself!");
                        }
                        if (currentMove.name == "Rest")
                        {
                            activePokemon.currentHitPoints = activePokemon.maxHitPoints;
                            activePokemon.isBurned = false;
                            activePokemon.isParalyzed = false;
                            activePokemon.isPoisoned = false;
                            activePokemon.sleepCounter = random.Next(2, 6);
                            activePokemon.WriteName(); Console.WriteLine(" fully healed itself!");
                            activePokemon.WriteName(); Console.WriteLine(" fell asleep!");
                        }
                    }
                    if (currentMove.attackBoost != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        activePokemon.attackMod += currentMove.attackBoost;
                        activePokemon.WriteName(); Console.WriteLine("'s attack rose!");
                        if (activePokemon.attackMod > 6) { activePokemon.attackMod = 6; Console.WriteLine("Its attack can't go any higher!"); }
                    }
                    if (currentMove.defenseBoost != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        activePokemon.defenseMod += currentMove.defenseBoost;
                        activePokemon.WriteName(); Console.WriteLine("'s defense rose!");
                        if (activePokemon.defenseMod > 6) { activePokemon.defenseMod = 6; Console.WriteLine("Its defense can't go any higher!"); }
                    }
                    if (currentMove.critBoost != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        activePokemon.critMod += currentMove.critBoost;
                        activePokemon.WriteName(); Console.WriteLine(" is getting pumped!");
                        if (activePokemon.critMod > 6) { activePokemon.critMod = 6; Console.WriteLine("It can't get any more pumped!"); }
                    }
                    if (currentMove.speedBoost != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        activePokemon.speedMod += currentMove.speedBoost;
                        activePokemon.WriteName(); Console.WriteLine("'s speed rose!");
                        if (activePokemon.speedMod > 6) { activePokemon.speedMod = 6; Console.WriteLine("Its speed can't go any higher!"); }
                    }
                    if (currentMove.attackPenalty != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        target.attackMod -= currentMove.attackPenalty;
                        if (target.attackMod + target.attackStat <= 0)
                        {
                            target.attackMod = target.attackStat - 1;
                            target.WriteName(); Console.WriteLine("'s attack can't go any lower!");
                        }
                        target.WriteName(); Console.WriteLine("'s attack fell!");
                        if (target.attackMod < -6) { activePokemon.attackMod = 6; Console.WriteLine("Its attack can't go any lower!"); }
                    }
                    if (currentMove.defensePenalty != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        target.defenseMod -= currentMove.defensePenalty;
                        if (target.attackMod + target.attackStat <= 0)
                        {
                            target.defenseMod = target.defenseStat - 1;
                            target.WriteName(); Console.WriteLine("'s defense can't go any lower!");
                        }
                        target.WriteName(); Console.WriteLine("'s defense fell!");
                        if (target.defenseMod < -6) { activePokemon.defenseMod = 6; Console.WriteLine("Its defense can't go any lower!"); }
                    }
                    if (currentMove.speedPenalty != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        target.speedMod -= currentMove.speedPenalty;
                        if (target.speedMod + target.speedStat <= 0)
                        {
                            target.attackMod = target.attackStat - 1;
                            target.WriteName(); Console.WriteLine("'s speed can't go any lower!");
                        }
                        target.WriteName(); Console.WriteLine("'s speed fell!");
                        if (target.speedMod < -6) { activePokemon.speedMod = 6; Console.WriteLine("Its speed can't go any lower!"); }
                    }
                    if (currentMove.accuracyPenalty != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        target.accuracyMod -= currentMove.accuracyPenalty;
                        target.WriteName(); Console.WriteLine("'s accuracy fell!");
                        if (target.accuracyMod < -6) { activePokemon.accuracyMod = 6; Console.WriteLine("Its accuracy can't go any lower!"); }
                    }
                }
                else
                {
                    Console.WriteLine("The attack missed!");
                    currentMove.currentPowerPoints--;
                }
                Console.ReadLine();
            }
        }

        public static bool CheckIfFainted(ref Pokemon pokemon)
        {
            if (pokemon.currentHitPoints <= 0)
            {
                pokemon.currentHitPoints = 0;
                pokemon.isFainted = true;
                pokemon.hpMod = 0;
                pokemon.accuracyMod = 0;
                pokemon.attackMod = 0;
                pokemon.defenseMod = 0;
                pokemon.speedMod = 0;
                pokemon.isBurned = false;
                pokemon.isFlinching = false;
                pokemon.isParalyzed = false;
                pokemon.isPoisoned = false;
                pokemon.sleepCounter = 0;
                Console.Write("\n"); pokemon.WriteName(); Console.WriteLine(" fainted!");
                return true;
            }
            return false;
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
