using System;

namespace DungeonsAndDargons
{
    class MainProgram
    {
        static Weapon[] weapons = new Weapon[]
            {
                new Weapon("Dagger", 3, 5, false, 2),
                new Weapon("Claws", 3, 5, true, 4),
                new Weapon("Shortsword", 5, 8, false, 3),
                new Weapon("Zweihander", 6, 10, true, 4),
                new Weapon("Black Knight Sword", 8, 12, false, 8)
            };

        static Character[] monsters = new Character[]
            {
                new Character("Goblin", 6, 5, 2),
                new Character("Wolf", 8, 8, 2),
                new Character("Orc", 10, 10, 3),
                new Character("Dire Wolf", 10, 12, 5),
                new Character("Orc Lord", 12, 25, 10)
            };

        static void Loot(int room, Character player)
        {
            Console.WriteLine("You find a treasure! Select an option to loot:\n1. Healing Potion (Heal to Full HP)\n2. Rations(Increase Max HP by 5)\n3. Rummage a new weapon");
            string userSelect = Console.ReadLine();
            bool choice = false;
            Random random = new Random();
            while (choice == false)
            {
                switch (userSelect)
                {
                    case "1":
                        player.CurrentHealth = player.MaxHealth;
                        Console.WriteLine("You heal back to {0} health!", player.MaxHealth);
                        choice = true;
                        break;
                    case "2":
                        player.MaxHealth += (random.Next(room, room + 2) + random.Next(0, 6));
                        Console.WriteLine("Your max health is now {0} HP", player.MaxHealth);
                        choice = true;
                        break;
                    case "3":
                        Weapon drop = weapons[0];
                        if (room < 3)
                        {
                            drop = weapons[random.Next(0, 2)];
                        }
                        else if (room > 2 && room < 5)
                        {
                            drop = weapons[random.Next(2, 4)];
                        }
                        else if (room == 5)
                        {
                            drop = weapons[4];
                        }
                        Console.WriteLine("You've found {0}", drop);

                        if(drop == player.CurrentWeapon)
                        {
                            Console.WriteLine("At first you were dissapointed but underneath the weapon you find a armor reinforcement kit! +1 Block!");
                            player.Block += 1;
                            choice = true;
                            break;
                        }

                        Console.WriteLine("Do you want to replace {0}\n1 to replace, any other key to keep current weapon", player.CurrentWeapon);
                        string weaponSelect = Console.ReadLine();
                        if (weaponSelect == "1")
                        {
                            player.CurrentWeapon = drop;
                            Console.WriteLine("Your weapon is now: {0}", player.CurrentWeapon);
                            choice = true;
                        }
                        else
                        {
                            Console.WriteLine("You leave the loot behind");
                            choice = true;
                        }
                        break;
                    default:
                        Console.WriteLine("Input not recognized");
                        break;
                }
            }
        }

        

        static void Main(string[] args)
        {
            Dungeon gameDungeon = new Dungeon("The Dead Hall");
            Console.Title = gameDungeon.Title;
            Console.WriteLine("Enter a name for your character");
            string userName = Console.ReadLine();
            Character player = new Character(userName, 10, 10, 3);
            monsters[1].CurrentWeapon = weapons[1];
            monsters[2].CurrentWeapon = weapons[2];
            monsters[3].CurrentWeapon = weapons[1];
            monsters[4].CurrentWeapon = weapons[3];
            Random rand = new Random();
            int currentRoom = 0;
            int statusTrack = 0;
            int monsterToFight = 0;
            do
            {
                statusTrack = 0;
                if (currentRoom == 0)
                {
                    monsterToFight = 0;
                }
                else if (currentRoom > 0 && currentRoom <= 2)
                {
                    monsterToFight = rand.Next(1, 2);
                }
                else if (currentRoom >= 3 && currentRoom < 6)
                {
                    monsterToFight = rand.Next(2, 4);
                }

                else if (currentRoom == 6)
                {
                    monsterToFight = 4;
                }
                statusTrack = gameDungeon.Menu(player, monsters[monsterToFight], currentRoom);
                if (statusTrack == 1)
                {
                    
                    if (currentRoom < 6) 
                    {
                        Loot(currentRoom, player);
                        currentRoom++;
                    }
                    else
                    {
                        Console.WriteLine("You made it to the treasure room! You can now retire on a pile of gold and gems, great job!");
                        statusTrack = -1;
                    }
                }
                if (statusTrack == 2)
                {
                    currentRoom--;
                }
            } while (statusTrack != -1);

            Console.WriteLine("----Final Stats----");
            Console.WriteLine(player);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
