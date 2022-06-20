/*
 * Purpur Tentakel
 * 20.06.2022
 * Test - GameObject - Game
 */

using Helpers;

namespace Test.GameObject
{
    internal class TestGame
    {
        IGameObject[] gameObjects = new IGameObject[]
        {
            new Player(3,4,"Super Mario", 100),
            new Enemy(7,8, "Bowser", 120),
            new Enemy(1,2, "Monty Mole", 30),
            new Enemy(-3,4, "Thwimp", 45),
        };

        public void Game()
        {
            while (true)
            {
                Console.Clear();
                Helper.PrintHeadline("GameObject");

                int rounds = Helper.GetInt("enter round count");


                Execute(rounds);

                if (Helper.GetQuitInput() == "q")
                {
                    break;
                }
            }
        }
        private void Execute(int rounds)
        {
            for (int round = 1; round <= rounds; ++round)
            {
                Console.WriteLine($"Round {round}: Fight!");
                foreach (IGameObject gameObject in gameObjects)
                {
                    gameObject.Update();
                    Console.WriteLine($"    {gameObject.ToString()}");

                }
            }
        }
    }
}
