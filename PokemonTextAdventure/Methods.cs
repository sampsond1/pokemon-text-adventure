using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTextAdventure
{
    static partial class Methods
    {

        public static void DoAction(string currentCommand, ref Player player, Location currentLocation, ref Dictionary<string, Location> locationdex, Dictionary<string, Pokemon> pokedex, Dictionary<string, Move> movedex)
        {
            if (currentCommand == "") { return; }

            //QUIT
            if (currentCommand == "quit" || currentCommand == "q")
            {
                //save stuff here
                player.gameRunning = false;
            }

            char[] charSeparators = new char[] { ' ' };
            string[] splitCommand = currentCommand.ToLower().Split(charSeparators, 2);

            //LOOK
            if (splitCommand[0] == "look" || splitCommand[0] == "l")
            {
                if (splitCommand[1] == null) { Console.WriteLine(currentLocation.description); return; }
                else
                {
                    try { Console.WriteLine(currentLocation.descriptions[splitCommand[1]]); }
                    catch
                    {
                        Console.WriteLine("What are you looking at? There's nothing like that here.");
                        return;
                    }
                }
            }

            //TALK
            if (splitCommand[0] == "talk" || splitCommand[0] == "t")
            {
                try { Console.WriteLine(currentLocation.dialogue[splitCommand[1]]); return; }
                catch
                {
                    Console.WriteLine("Who are you talking to? There's no one here like that.");
                    return;
                }
            }

            //EXIT/ENTER
            if (splitCommand[0] == "exit" || splitCommand[0] == "enter" || splitCommand[0] == "e")
            {
                try
                {
                    if (player.currentLocation.canHeal) { player.previousLocation = player.currentLocation; }
                    player.currentLocation = locationdex[currentLocation.exitLocations[splitCommand[1]]];

                    Console.WriteLine(currentLocation.name.ToUpper());
                    Console.WriteLine("-------------------------------------------------------\n");
                    Console.WriteLine(currentLocation.description);
                    
                }
                catch
                {
                    Console.WriteLine("Where are you exiting? Try using a direction ('north').");
                }
            }

            //PARTY
            if (splitCommand[0] == "party" || splitCommand[0] == "p")
            {
                foreach (Pokemon pokemon in player.party)
                {
                    if (pokemon.name != "Missingno")
                    {
                        pokemon.WriteName(); Console.Write($"  |  Lv. {pokemon.level}  |  {pokemon.currentHitPoints} / {pokemon.maxHitPoints}");
                    }
                }
            }
            //HEAL
            if (splitCommand[0] == "heal" && currentLocation.canHeal)
            {
                Console.WriteLine("The nice lady at the counter fully healed all your Pokémon!");
                for (int i = 0; i < 3; i++)
                {
                    player.party[i].currentHitPoints = player.party[i].maxHitPoints;
                    player.party[i].isParalyzed = false;
                    player.party[i].isBurned = false;
                    player.party[i].isPoisoned = false;
                    player.party[i].sleepCounter = 0;
                    player.party[i].isFainted = false;
                }
            }
            //PC
            if (splitCommand[0] == "pc" && currentLocation.hasPc)
            { 
                bool keepRunning = true;
                while (keepRunning)
                {
                    Console.WriteLine("PARTY:");
                    foreach (Pokemon pokemon in player.party)
                    {
                        if (pokemon.name != "Missingno")
                        {
                            pokemon.WriteName(); Console.Write($"  |  Lv. {pokemon.level}  |  {pokemon.currentHitPoints} / {pokemon.maxHitPoints}\n");
                        }
                    }
                    Console.WriteLine("POKÉMON IN PC:");
                    for (int i = 0; i < player.pcPokemon.Count; i++)
                    {
                        Console.Write((i + 1) + ". "); player.pcPokemon[i].WriteName(); Console.WriteLine($"  Lv. {player.pcPokemon[i].level}");
                    }

                    Console.WriteLine("\nWhat would you like to do?");
                    Console.WriteLine("1. Withdraw Pokémon");
                    Console.WriteLine("2. Exit");
                    currentCommand = Console.ReadLine();
                    switch (currentCommand)
                    {
                        case "1":
                            Console.WriteLine("Which Pokémon would you like to withdraw? (Type a number.)");
                            currentCommand = Console.ReadLine();
                            try
                            {
                                int pokemonId = int.Parse(currentCommand);
                                Pokemon withdrawnPokemon = player.pcPokemon[pokemonId - 1];
                                player.pcPokemon.Remove(withdrawnPokemon);
                                Console.WriteLine("Which party member would you like to deposit? (Type a number.)");
                                currentCommand = Console.ReadLine();
                                pokemonId = int.Parse(currentCommand);
                                player.party[pokemonId - 1].Heal();
                                player.pcPokemon.Add(player.party[pokemonId - 1]);
                                player.party[pokemonId - 1] = withdrawnPokemon;
                                Console.Write("All done!"); Console.ReadKey();
                                Console.Clear();
                            }
                            catch
                            {
                                Console.WriteLine("Something went wrong, please try again.");
                            }
                            break;
                        case "2":
                            Console.WriteLine("Ok, booting down."); Console.ReadKey();
                            keepRunning = false;
                            break;
                    }
                }
            }

            //BATTLE
            if (splitCommand[0] == "battle" || splitCommand[0] == "b")
            {
                if (currentLocation.trainerBattles.Count > 0)
                {
                    if (!Methods.TrainerBattle(ref player, currentLocation.trainerBattles[0].trainer, movedex["struggle"]))
                    {
                        player.currentLocation = player.previousLocation;
                        Console.WriteLine("You wake up in the last Pokémon center you visited, with all your Pokémon healed. Let's try again!");
                        foreach (Pokemon pokemon in player.party)
                        {
                            pokemon.Heal();
                        }
                    }
                    else
                    {
                        currentLocation.trainerBattles.Remove(currentLocation.trainerBattles[0]);
                        Console.WriteLine(currentLocation.name.ToUpper());
                        Console.WriteLine("-------------------------------------------------------\n");
                        Console.WriteLine(currentLocation.description);
                    }
                }
            }

            //GRASS
            if (splitCommand[0] == "grass" || splitCommand[0] == "g")
            {
                Random random = new Random();
                Pokemon encounteredPokemon = new Pokemon(currentLocation.wildPokemon[0].pokemon, pokedex);
                int randomNumber = random.Next(0, 100);

                foreach (PokemonWrapper pokemon in currentLocation.wildPokemon)
                {
                    if (randomNumber < pokemon.rate)
                    {
                        encounteredPokemon = new Pokemon(pokemon.pokemon, random.Next(pokemon.minLevel, pokemon.maxLevel + 1), pokedex);
                        break;
                    }
                }

                if (!Methods.WildBattle(ref player, encounteredPokemon, movedex["Struggle"]))
                {
                    player.currentLocation = player.previousLocation;
                    Console.WriteLine("You wake up in the last Pokémon center you visited, with all your Pokémon healed. Let's try again!");
                    foreach (Pokemon pokemon in player.party)
                    {
                        pokemon.Heal();
                    }
                }
                else
                {
                    Console.WriteLine(currentLocation.name.ToUpper());
                    Console.WriteLine("-------------------------------------------------------\n");
                    Console.WriteLine(currentLocation.description);
                }
            }
        }

        public static void ApplyMove(ref Move currentMove, ref Pokemon opposingPokemon, ref Pokemon target)
        {
            int critHitMultiplier = 1;
            int damage;
            Random random = new Random();

            if (opposingPokemon.sleepCounter > 0)
            {
                opposingPokemon.sleepCounter--;
                Console.Write("Enemy "); Methods.WriteType(opposingPokemon.name, opposingPokemon.type); Console.WriteLine(" is fast asleep!"); Console.ReadKey();
                return;
            }
            if (opposingPokemon.isParalyzed == true && random.Next(0, 4) == 3)
            {
                Console.Write("Enemy "); Methods.WriteType(opposingPokemon.name, opposingPokemon.type); Console.WriteLine(" is paralyzed! It can't move!"); Console.ReadKey();
                return;
            }
            if (opposingPokemon.isFlinching == true)
            {
                opposingPokemon.isFlinching = false;
                Console.Write("Enemy "); Methods.WriteType(opposingPokemon.name, opposingPokemon.type); Console.WriteLine(" flinched!"); Console.ReadKey();
                return;
            }
            
            Console.Write("\nEnemy "); Methods.WriteType(opposingPokemon.name, opposingPokemon.type); Console.WriteLine($" used {currentMove.name}!"); Console.ReadKey();

            for (int i = currentMove.numberTimesHit; i > 0; i--)
            {
                if (random.Next(0, 101) <= (currentMove.accuracy * (Math.Pow(.66, opposingPokemon.accuracyMod))) || currentMove.name == "Swift")
                {
                    //SPECIAL CASES

                    if (currentMove.name == "Dream Eater")
                    {
                        if (currentMove.critChance != 0 && random.NextDouble() <= (currentMove.critChance * opposingPokemon.critMod)) { critHitMultiplier = 2; }
                        damage = Convert.ToInt32((((((2 * opposingPokemon.level) / 5) * currentMove.damage * (opposingPokemon.attackStat + opposingPokemon.attackMod) / (target.defenseStat + target.defenseMod)) / 50) + 2) * critHitMultiplier * (Convert.ToDouble(random.Next(85, 101)) / 100));
                        target.currentHitPoints -= damage;
                        currentMove.currentPowerPoints--;
                        Console.WriteLine($"It dealt {damage} damage!"); Console.ReadKey();
                        critHitMultiplier = 1;
                        opposingPokemon.currentHitPoints += damage / 2;
                        if (opposingPokemon.currentHitPoints >= opposingPokemon.maxHitPoints) { opposingPokemon.currentHitPoints = opposingPokemon.maxHitPoints; }
                        opposingPokemon.WriteName(); Console.Write(" healed itself by eating "); target.WriteName(); Console.WriteLine("'s dream!"); Console.ReadKey();
                        return;
                    }

                    if (currentMove.name == "Guillotine" || currentMove.name == "Horn Drill")
                    {
                        target.currentHitPoints = 0;
                        currentMove.currentPowerPoints--;
                        target.isFainted = true;
                        Console.WriteLine("It's a one-hit KO!"); Console.ReadKey();
                        target.WriteName(); Console.WriteLine(" fainted!"); Console.ReadKey();
                        return;
                    }

                    if (currentMove.name == "Night Shade") { currentMove.damage = target.level; }

                    if (currentMove.name == "Splash") { currentMove.currentPowerPoints--; Console.WriteLine("But nothing happened!"); Console.ReadKey(); return; }

                    if (currentMove.name == "Super Fang")
                    {
                        currentMove.currentPowerPoints--;
                        Console.WriteLine($"It dealt {target.currentHitPoints / 2} damage!"); Console.ReadKey();
                        target.currentHitPoints /= 2;
                        return;
                    }

                    if (currentMove.name == "Transform")
                    {
                        Console.Write("Enemy "); opposingPokemon.WriteName(); Console.Write(" transformed into "); target.WriteName(); Console.Write("."); Console.WriteLine();Console.ReadKey();
                        opposingPokemon.type = target.type;
                        opposingPokemon.move[0] = target.move[1];
                        opposingPokemon.move[1] = target.move[2];
                        opposingPokemon.move[0].currentPowerPoints = 5;
                        opposingPokemon.move[1].currentPowerPoints = 5;
                        opposingPokemon.attackStat = target.attackStat;
                        opposingPokemon.attackMod = target.attackMod;
                        opposingPokemon.defenseStat = target.defenseStat;
                        opposingPokemon.defenseMod = target.defenseMod;
                        opposingPokemon.critMod = target.critMod;
                        opposingPokemon.speedStat = target.speedStat;
                        opposingPokemon.speedMod = target.speedMod;
                        opposingPokemon.hpStat = target.hpStat;
                        opposingPokemon.hpMod = target.hpMod;
                    }

                    //NORMAL CASES

                    if (currentMove.critChance != 0 && random.NextDouble() <= (currentMove.critChance * opposingPokemon.critMod)) { critHitMultiplier = 2; }
                    if (currentMove.damage != 0)
                    {
                        damage = Convert.ToInt32((((((2 * opposingPokemon.level) / 5) * currentMove.damage * (opposingPokemon.attackStat + opposingPokemon.attackMod) / (target.defenseStat + target.defenseMod)) / 50) + 2) * critHitMultiplier * (Convert.ToDouble(random.Next(85, 101)) / 100));
                        target.currentHitPoints = (target.currentHitPoints - damage);
                        currentMove.currentPowerPoints--;
                        Console.WriteLine($"It dealt {damage} damage!"); Console.ReadKey();
                        if (critHitMultiplier == 2) { Console.WriteLine("A critical hit!"); Console.ReadKey(); }
                    }
                    else
                    {
                        damage = 0;
                    }
                    critHitMultiplier = 1;

                    if (currentMove.causeBurn == true && random.NextDouble() < currentMove.effectChance && target.isBurned == false) { target.isBurned = true; target.WriteName(); Console.WriteLine(" was burned!"); Console.ReadKey(); }
                    if (currentMove.causePoison == true && random.NextDouble() < currentMove.effectChance && target.isPoisoned == false) { target.isPoisoned = true; target.WriteName(); Console.WriteLine(" was poisoned!"); Console.ReadKey(); }
                    if (currentMove.causeSleep == true && random.NextDouble() < currentMove.effectChance && target.sleepCounter == 0) { target.sleepCounter = random.Next(2, 6); target.WriteName(); Console.WriteLine(" fell asleep!"); Console.ReadKey(); }
                    if (currentMove.causeParalysis == true && random.NextDouble() < currentMove.effectChance && target.isParalyzed == false) { target.isPoisoned = true; target.WriteName(); Console.WriteLine(" was paralyzed!"); Console.ReadKey(); }
                    if (currentMove.causeFlinch == true && random.NextDouble() < currentMove.effectChance && target.isFlinching == false) { target.isFlinching = true; }
                    if (currentMove.gripDamage != 0 && random.NextDouble() < currentMove.effectChance && target.gripCounter == 0) { target.gripCounter = random.Next(2, 6); target.WriteName(); Console.WriteLine(" has been gripped!"); Console.ReadKey(); }
                    if (currentMove.recoilDamage != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        if (currentMove.recoilDamage == 1) { opposingPokemon.WriteName(); Console.WriteLine($" dealt {opposingPokemon.currentHitPoints} damage to itself!"); opposingPokemon.currentHitPoints = 0; Console.ReadKey(); }
                        else { opposingPokemon.WriteName(); Console.WriteLine($" dealt {damage * currentMove.recoilDamage} to itself!"); opposingPokemon.currentHitPoints -= Convert.ToInt16(Math.Floor((damage * currentMove.recoilDamage))); Console.ReadKey(); }
                    }
                    if (currentMove.hpGain != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        if (currentMove.name == "Recover")
                        {
                            opposingPokemon.currentHitPoints += (opposingPokemon.maxHitPoints / 2);
                            if (opposingPokemon.currentHitPoints > opposingPokemon.maxHitPoints) { opposingPokemon.currentHitPoints = opposingPokemon.maxHitPoints; }
                            opposingPokemon.WriteName(); Console.WriteLine(" healed itself!"); Console.ReadKey();
                        }
                        if (currentMove.name == "Rest")
                        {
                            opposingPokemon.currentHitPoints = opposingPokemon.maxHitPoints;
                            opposingPokemon.isBurned = false;
                            opposingPokemon.isParalyzed = false;
                            opposingPokemon.isPoisoned = false;
                            opposingPokemon.sleepCounter = random.Next(2, 6);
                            opposingPokemon.WriteName(); Console.WriteLine(" fully healed itself!"); Console.ReadKey();
                            opposingPokemon.WriteName(); Console.WriteLine(" fell asleep!"); Console.ReadKey();
                        }
                    }
                    if (currentMove.attackBoost != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        opposingPokemon.attackMod += currentMove.attackBoost;
                        opposingPokemon.WriteName(); Console.WriteLine("'s attack rose!"); Console.ReadKey();
                        if (opposingPokemon.attackMod > 6) { opposingPokemon.attackMod = 6; Console.WriteLine("Its attack can't go any higher!"); Console.ReadKey(); }
                    }
                    if (currentMove.defenseBoost != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        opposingPokemon.defenseMod += currentMove.defenseBoost;
                        opposingPokemon.WriteName(); Console.WriteLine("'s defense rose!"); Console.ReadKey();
                        if (opposingPokemon.defenseMod > 6) { opposingPokemon.defenseMod = 6; Console.WriteLine("Its defense can't go any higher!"); Console.ReadKey(); }
                    }
                    if (currentMove.critBoost != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        opposingPokemon.critMod += currentMove.critBoost;
                        opposingPokemon.WriteName(); Console.WriteLine(" is getting pumped!"); Console.ReadKey();
                    }
                        if (opposingPokemon.critMod > 6)
                        {
                            opposingPokemon.critMod = 6; Console.WriteLine("It can't get any more pumped!"); Console.ReadKey();
                        }
                        if (currentMove.speedBoost != 0 && random.NextDouble() < currentMove.effectChance)
                        {
                            opposingPokemon.speedMod += currentMove.speedBoost;
                            opposingPokemon.WriteName(); Console.WriteLine("'s speed rose!"); Console.ReadKey();
                            if (opposingPokemon.speedMod > 6) { opposingPokemon.speedMod = 6; Console.WriteLine("Its speed can't go any higher!"); Console.ReadKey(); }
                        }
                        if (currentMove.attackPenalty != 0 && random.NextDouble() < currentMove.effectChance)
                        {
                            target.attackMod -= currentMove.attackPenalty;
                            if (target.attackMod + target.attackStat <= 0)
                            {
                                target.attackMod = target.attackStat - 1;
                                target.WriteName(); Console.WriteLine("'s attack can't go any lower!"); Console.ReadKey();
                            }
                            target.WriteName(); Console.WriteLine("'s attack fell!");
                            if (target.attackMod < -6) { opposingPokemon.attackMod = 6; Console.WriteLine("Its attack can't go any lower!"); Console.ReadKey(); }
                        }
                        if (currentMove.defensePenalty != 0 && random.NextDouble() < currentMove.effectChance)
                        {
                            target.defenseMod -= currentMove.defensePenalty;
                            if (target.attackMod + target.attackStat <= 0)
                            {
                                target.defenseMod = target.defenseStat - 1;
                                target.WriteName(); Console.WriteLine("'s defense can't go any lower!"); Console.ReadKey();
                            }
                            target.WriteName(); Console.WriteLine("'s defense fell!"); Console.ReadKey();
                            if (target.defenseMod < -6) { opposingPokemon.defenseMod = 6; Console.WriteLine("Its defense can't go any lower!"); Console.ReadKey(); }
                        }
                        if (currentMove.speedPenalty != 0 && random.NextDouble() < currentMove.effectChance)
                        {
                            target.speedMod -= currentMove.speedPenalty;
                            if (target.speedMod + target.speedStat <= 0)
                            {
                                target.attackMod = target.attackStat - 1;
                                target.WriteName(); Console.WriteLine("'s speed can't go any lower!"); Console.ReadKey();
                            }
                            target.WriteName(); Console.WriteLine("'s speed fell!"); Console.ReadKey();
                            if (target.speedMod < -6) { opposingPokemon.speedMod = 6; Console.WriteLine("Its speed can't go any lower!"); Console.ReadKey(); }
                        }
                        if (currentMove.accuracyPenalty != 0 && random.NextDouble() < currentMove.effectChance)
                        {
                            target.accuracyMod -= currentMove.accuracyPenalty;
                            target.WriteName(); Console.WriteLine("'s accuracy fell!"); Console.ReadKey();
                            if (target.accuracyMod < -6) { opposingPokemon.accuracyMod = 6; Console.WriteLine("Its accuracy can't go any lower!"); Console.ReadKey(); }
                        }

                    }
                    else
                    {
                        Console.WriteLine("The attack missed!"); Console.ReadKey();
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
                if (activePokemon.sleepCounter > 0) { Methods.WriteType(activePokemon.name, activePokemon.type); Console.WriteLine(" is fast asleep!"); Console.ReadKey(); }
                if (activePokemon.sleepCounter == 0) { activePokemon.WriteName(); Console.WriteLine("woke up!"); Console.ReadKey(); }
                return;
            }
            if (activePokemon.isParalyzed == true && random.Next(0, 4) == 3)
            {
                Methods.WriteType(activePokemon.name, activePokemon.type); Console.WriteLine(" is paralyzed! It can't move!"); Console.ReadKey();
                return;
            }
            if (activePokemon.isFlinching == true)
            {
                activePokemon.isFlinching = false;
                Methods.WriteType(activePokemon.name, activePokemon.type); Console.WriteLine(" flinched!"); Console.ReadKey();
                return;
            }

            Console.Write("\n"); Methods.WriteType(activePokemon.name, activePokemon.type); Console.WriteLine($" used {currentMove.name}!"); Console.ReadKey();

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
                        Console.WriteLine($"It dealt {damage} damage!"); Console.ReadKey();
                        critHitMultiplier = 1;
                        activePokemon.currentHitPoints += damage / 2;
                        if (activePokemon.currentHitPoints >= activePokemon.maxHitPoints) { activePokemon.currentHitPoints = activePokemon.maxHitPoints; }
                        activePokemon.WriteName(); Console.Write(" healed itself by eating "); target.WriteName(); Console.WriteLine("'s dream!"); Console.ReadKey();
                        return;
                    }

                    if (currentMove.name == "Guillotine" || currentMove.name == "Horn Drill")
                    {
                        target.currentHitPoints = 0;
                        currentMove.currentPowerPoints--;
                        target.isFainted = true;
                        Console.WriteLine("It's a one-hit KO!"); Console.ReadKey();
                        return;
                    }

                    if (currentMove.name == "Night Shade") { currentMove.damage = target.level; }

                    if (currentMove.name == "Splash") { currentMove.currentPowerPoints--; Console.WriteLine("But nothing happened!"); Console.ReadKey(); return; }

                    if (currentMove.name == "Super Fang")
                    {
                        currentMove.currentPowerPoints--;
                        Console.WriteLine($"It dealt {target.currentHitPoints / 2} damage!"); Console.ReadKey();
                        target.currentHitPoints /= 2;
                        return;
                    }

                    if (currentMove.name == "Transform")
                    {
                        activePokemon.WriteName(); Console.Write(" transformed into "); target.WriteName(); Console.WriteLine();Console.Write("."); Console.ReadKey();
                        activePokemon.type = target.type;
                        activePokemon.move[0] = target.move[0];
                        activePokemon.move[1] = target.move[1];
                        activePokemon.move[0].currentPowerPoints = 5;
                        activePokemon.move[1].currentPowerPoints = 5;
                        activePokemon.attackStat = target.attackStat;
                        activePokemon.attackMod = target.attackMod;
                        activePokemon.defenseStat = target.defenseStat;
                        activePokemon.defenseMod = target.defenseMod;
                        activePokemon.critMod = target.critMod;
                        activePokemon.speedStat = target.speedStat;
                        activePokemon.speedMod = target.speedMod;
                        activePokemon.hpStat = target.hpStat;
                        activePokemon.hpMod = target.hpMod;
                    }

                    //NORMAL CASES

                    if (currentMove.critChance != 0 && random.NextDouble() <= (currentMove.critChance * activePokemon.critMod)) { critHitMultiplier = 2; }
                    if (currentMove.damage != 0)
                    {
                        damage = Convert.ToInt32((((((2 * activePokemon.level) / 5) * currentMove.damage * (activePokemon.attackStat + activePokemon.attackMod) / (target.defenseStat + target.defenseMod)) / 50) + 2) * critHitMultiplier * (Convert.ToDouble(random.Next(85, 101)) / 100));
                        target.currentHitPoints = (target.currentHitPoints - damage);
                        currentMove.currentPowerPoints--;
                        Console.WriteLine($"It dealt {damage} damage!"); Console.ReadKey();
                        if (critHitMultiplier == 2) { Console.WriteLine("A critical hit!"); Console.ReadKey(); }
                    }
                    else
                    {
                        damage = 0;
                    }
                    critHitMultiplier = 1;

                    if (currentMove.causeBurn == true && random.NextDouble() < currentMove.effectChance && target.isBurned == false) { target.isBurned = true; target.WriteName(); Console.WriteLine(" was burned!"); Console.ReadKey(); }
                    if (currentMove.causePoison == true && random.NextDouble() < currentMove.effectChance && target.isPoisoned == false) { target.isPoisoned = true; target.WriteName(); Console.WriteLine(" was poisoned!"); Console.ReadKey(); }
                    if (currentMove.causeSleep == true && random.NextDouble() < currentMove.effectChance && target.sleepCounter == 0) { target.sleepCounter = random.Next(2, 6); target.WriteName(); Console.WriteLine(" fell asleep!"); Console.ReadKey(); }
                    if (currentMove.causeParalysis == true && random.NextDouble() < currentMove.effectChance && target.isParalyzed == false) { target.isPoisoned = true; target.WriteName(); Console.WriteLine(" was paralyzed!"); Console.ReadKey(); }
                    if (currentMove.causeFlinch == true && random.NextDouble() < currentMove.effectChance && target.isFlinching == false) { target.isFlinching = true; }
                    if (currentMove.gripDamage != 0 && random.NextDouble() < currentMove.effectChance && target.gripCounter == 0) { target.gripCounter = random.Next(2, 6); target.WriteName(); Console.WriteLine(" has been gripped!"); Console.ReadKey(); }
                    if (currentMove.recoilDamage != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        if (currentMove.recoilDamage == 1) { activePokemon.WriteName(); Console.WriteLine($" dealt {activePokemon.currentHitPoints} damage to itself!"); activePokemon.currentHitPoints = 0; Console.ReadKey(); }
                        else { activePokemon.WriteName(); Console.WriteLine($" dealt {damage * currentMove.recoilDamage} to itself!"); activePokemon.currentHitPoints -= Convert.ToInt16(Math.Floor((damage * currentMove.recoilDamage))); Console.ReadKey(); }
                    }
                    if (currentMove.hpGain != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        if (currentMove.name == "Recover")
                        {
                            activePokemon.currentHitPoints += (activePokemon.maxHitPoints / 2);
                            if (activePokemon.currentHitPoints > activePokemon.maxHitPoints) { activePokemon.currentHitPoints = activePokemon.maxHitPoints; }
                            activePokemon.WriteName(); Console.WriteLine(" healed itself!"); Console.ReadKey();
                        }
                        if (currentMove.name == "Rest")
                        {
                            activePokemon.currentHitPoints = activePokemon.maxHitPoints;
                            activePokemon.isBurned = false;
                            activePokemon.isParalyzed = false;
                            activePokemon.isPoisoned = false;
                            activePokemon.sleepCounter = random.Next(2, 6);
                            activePokemon.WriteName(); Console.WriteLine(" fully healed itself!"); Console.ReadKey();
                            activePokemon.WriteName(); Console.WriteLine(" fell asleep!"); Console.ReadKey();
                        }
                    }
                    if (currentMove.attackBoost != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        activePokemon.attackMod += currentMove.attackBoost;
                        activePokemon.WriteName(); Console.WriteLine("'s attack rose!"); Console.ReadKey();
                        if (activePokemon.attackMod > 6) { activePokemon.attackMod = 6; Console.WriteLine("Its attack can't go any higher!"); Console.ReadKey(); }
                    }
                    if (currentMove.defenseBoost != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        activePokemon.defenseMod += currentMove.defenseBoost;
                        activePokemon.WriteName(); Console.WriteLine("'s defense rose!"); Console.ReadKey();
                        if (activePokemon.defenseMod > 6) { activePokemon.defenseMod = 6; Console.WriteLine("Its defense can't go any higher!"); Console.ReadKey(); }
                    }
                    if (currentMove.critBoost != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        activePokemon.critMod += currentMove.critBoost;
                        activePokemon.WriteName(); Console.WriteLine(" is getting pumped!"); Console.ReadKey();
                        if (activePokemon.critMod > 7) { activePokemon.critMod = 7; Console.WriteLine("It can't get any more pumped!"); Console.ReadKey(); }
                    }
                    if (currentMove.speedBoost != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        activePokemon.speedMod += currentMove.speedBoost;
                        activePokemon.WriteName(); Console.WriteLine("'s speed rose!"); Console.ReadKey();
                        if (activePokemon.speedMod > 6) { activePokemon.speedMod = 6; Console.WriteLine("Its speed can't go any higher!"); Console.ReadKey(); }
                    }
                    if (currentMove.attackPenalty != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        target.attackMod -= currentMove.attackPenalty;
                        if (target.attackMod + target.attackStat <= 0)
                        {
                            target.attackMod = target.attackStat - 1;
                            target.WriteName(); Console.WriteLine("'s attack can't go any lower!"); Console.ReadKey();
                        }
                        target.WriteName(); Console.WriteLine("'s attack fell!"); Console.ReadKey();
                        if (target.attackMod < -6) { activePokemon.attackMod = 6; Console.WriteLine("Its attack can't go any lower!"); Console.ReadKey(); }
                    }
                    if (currentMove.defensePenalty != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        target.defenseMod -= currentMove.defensePenalty;
                        if (target.attackMod + target.attackStat <= 0)
                        {
                            target.defenseMod = target.defenseStat - 1;
                            target.WriteName(); Console.WriteLine("'s defense can't go any lower!"); Console.ReadKey();
                        }
                        target.WriteName(); Console.WriteLine("'s defense fell!"); Console.ReadKey();
                        if (target.defenseMod < -6) { activePokemon.defenseMod = 6; Console.WriteLine("Its defense can't go any lower!"); Console.ReadKey(); }
                    }
                    if (currentMove.speedPenalty != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        target.speedMod -= currentMove.speedPenalty;
                        if (target.speedMod + target.speedStat <= 0)
                        {
                            target.attackMod = target.attackStat - 1;
                            target.WriteName(); Console.WriteLine("'s speed can't go any lower!"); Console.ReadKey();
                        }
                        target.WriteName(); Console.WriteLine("'s speed fell!"); Console.ReadKey();
                        if (target.speedMod < -6) { activePokemon.speedMod = 6; Console.WriteLine("Its speed can't go any lower!"); Console.ReadKey(); }
                    }
                    if (currentMove.accuracyPenalty != 0 && random.NextDouble() < currentMove.effectChance)
                    {
                        target.accuracyMod -= currentMove.accuracyPenalty;
                        target.WriteName(); Console.WriteLine("'s accuracy fell!"); Console.ReadKey();
                        if (target.accuracyMod < -6) { activePokemon.accuracyMod = 6; Console.WriteLine("Its accuracy can't go any lower!"); Console.ReadKey(); }
                    }
                }
                else
                {
                    Console.WriteLine("The attack missed!"); Console.ReadKey();
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
                pokemon.critMod = 1;
                pokemon.isBurned = false;
                pokemon.isFlinching = false;
                pokemon.isParalyzed = false;
                pokemon.isPoisoned = false;
                pokemon.sleepCounter = 0;
                Console.Write("\n"); pokemon.WriteName(); Console.WriteLine(" fainted!");
                Console.ReadLine();
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
                    Console.ForegroundColor = ConsoleColor.White;
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
