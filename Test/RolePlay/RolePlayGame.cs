/*
 * Purpur Tentakel
 * 27.06.2022
 * Test - RolePlay - Game
 */

using Helpers;
using RolePlay.Collectibles;

namespace RolePlay
{
    internal class RolePlayGame
    {
        private double minHitChance = 0.5;
        private static Random random = new Random();
        private ICollectibles[] inventory = new ICollectibles[]
        {
            new Sword("Meister-Schwert",random.Next(20)+10, random.Next(10), Helper.GetRandomDouble(0.8,1.0)),
            new MagicCristal("Magischer Stein", random.Next(100), random.Next(10), Helper.GetRandomDouble(0.6,0.95)),
        };
        public void Game()
        {
            while (true)
            {
                Console.Clear();
                Helper.PrintHeadline("RollPlayGame");

                Execute();

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }
        private void Execute()
        {
            int monsterHealth = random.Next(50) + 50;
            int playerHealth = random.Next(50) + 50;

            Console.WriteLine("\tFight starting:");

            while (true)
            {
                Console.WriteLine($"Your health: {playerHealth}");
                PrintInventory();

                int playerInput = GetPlayerInput();

                PlayerDamage(ref monsterHealth, inventory[playerInput]);

                if (monsterHealth <= 0)
                {
                    Console.WriteLine("you won!");
                    break;
                }

                MonsterDamage(ref playerHealth);

                if (playerHealth <= 0)
                {
                    Console.WriteLine("you lost!");
                    break;
                }

                if (!HasAnyUsages())
                {
                    Console.WriteLine("no usages left | you lost!");
                    break;
                }
            }
        }

        private void PlayerDamage(ref int monsterHealth, ICollectibles weapon)
        {
            int damage = weapon.Use();

            double hitChance = Helper.GetRandomDouble(0.4, 1.0);

            if (!IsHit(weapon.HitChance, hitChance))
            {
                Console.WriteLine("Miss");
                return;
            }
            random.Next(0, 1);

            monsterHealth -= damage;
            Console.WriteLine($"your damage: {damage}");
            Console.WriteLine($"remaining monster health: {monsterHealth}");
        }
        private void MonsterDamage(ref int playerHealth)
        {

            int damage = random.Next(15) + 5;
            playerHealth -= damage;

            Console.WriteLine($"monster damage: {damage}");
            Console.WriteLine($"your remaining health: {playerHealth}");
        }
        private int GetPlayerInput()
        {
            int playerChoice;
            while (true)
            {
                playerChoice = Helper.GetInt("\tchoose your weapon:") - 1;
                bool validInput = 0 <= playerChoice && playerChoice < inventory.Length;
                if (validInput)
                {
                    if (inventory[playerChoice].IsUsable())
                    {
                        break;
                    }
                    Console.WriteLine("weapon is not usable");
                }
                Console.WriteLine("invalid input");
            }
            return playerChoice;
        }
        private void PrintInventory()
        {
            for (int i = 0; i < inventory.Length; ++i)
            {
                Console.WriteLine($"{i + 1}  -> {inventory[i]}");
            }
        }
        private bool HasAnyUsages()
        {
            foreach (ICollectibles item in inventory)
            {
                if (item.IsUsable())
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsHit(double waponHitChance, double HitChance)
        {
            double currentHitChance = waponHitChance * HitChance;
            Console.WriteLine($"hit chance: {(int)(currentHitChance * 100)}%");
            return minHitChance < currentHitChance;
        }
    }
}
