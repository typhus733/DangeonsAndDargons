using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndDargons
{
    public class Dungeon
    {
        public string Title { get; }
        public Dictionary<int, string> Rooms { get; }

        public Dungeon(string title)
        {
            this.Title = title;
            Rooms = new Dictionary<int, string>()
            {
                { 0, "Entrance" },
                { 1, "Hallway" },
                { 2, "Fountain Room" },
                { 3, "Great Hall" },
                { 4, "Kitchen" },
                { 5, "Barracks" },
                { 6, "Treasure Hall" }
            };
        }

        public int Menu(Character player, Character monster, int currentRoom)
        {
           
            bool run = true;
            do
            {
                Console.WriteLine("Current Room: {0}", Rooms[currentRoom]);
                Console.WriteLine("You see a {0}", monster.Name);
                Console.WriteLine("Select a menu option: 1. Attack 2. Run 3. Player Info 4. Monster Info 5. Exit Program");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        int hit = player.HitCalc();
                        int damage = 0;
                        if (monster.CurrentWeapon.IsTwoHanded == true && hit >= monster.Block)
                        {
                            damage = player.DamageCalc();
                            monster.CurrentHealth -= damage;
                            Console.WriteLine("You hit and dealt {0} damage!\n", damage);
                            if (monster.CurrentHealth <= 0)
                            {
                                Console.WriteLine("The {0} dies!\n", monster.Name);
                                monster.CurrentHealth = monster.MaxHealth;
                                return 1;
                            }
                        }
                        else if (monster.CurrentWeapon.IsTwoHanded == false && hit >= monster.Block + 3)
                        {
                            damage = player.DamageCalc();
                            monster.CurrentHealth -= damage;
                            Console.WriteLine("You hit and dealt {0} damage!\n", damage);
                            if (monster.CurrentHealth <= 0)
                            {
                                Console.WriteLine("The {0} dies!\n", monster.Name);
                                monster.CurrentHealth = monster.MaxHealth;
                                return 1;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You missed!\n");
                        }
                        hit = monster.HitCalc();
                        if (player.CurrentWeapon.IsTwoHanded == true && hit >= player.Block)
                        {
                            damage = monster.DamageCalc();
                            Console.WriteLine("The {0} hit and dealt {1}\n", monster.Name, damage);
                            player.CurrentHealth -= damage;
                            if(player.CurrentHealth <= 0)
                            {
                                Console.WriteLine("You're DEAD!!!\nYou reached room {0}", currentRoom);
                                return -1;
                            }
                        }
                        else if (player.CurrentWeapon.IsTwoHanded == false && hit >= player.Block + 3)
                        {
                            damage = monster.DamageCalc();
                            Console.WriteLine("The {0} hit and dealt {1}\n", monster.Name, damage);
                            player.CurrentHealth -= damage;
                            if (player.CurrentHealth <= 0)
                            {
                                Console.WriteLine("You're DEAD!!!\nYou reached room {0}", currentRoom);
                                return -1;
                            }
                        }
                        else
                        {
                            Console.WriteLine("The {0} missed!\n", monster.Name);
                        }
                        break;
                        
                    case "2":
                        if(currentRoom == 0)
                        {
                            Console.WriteLine("There's nowhere to run!\n");
                            break;
                        }
                        else
                        {
                            return 2;
                        }

                    
                    case "3":
                        Console.WriteLine(player);
                        break;
                    
                    case "4":
                        Console.WriteLine(monster);
                        break;

                    case "5":
                        Console.WriteLine("You reached room {0}, thank you for playing!", currentRoom);
                        return -1;

                    default:
                        Console.WriteLine("Invalid input entered");
                        break;
                }
            }
            while (run == true);
            return 0;
        }

    }
}
