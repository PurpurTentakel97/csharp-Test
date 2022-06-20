/*
 * Purpur Tentakel
 * 20.06.2022
 * Test - GameObject - Player
 */

namespace Test.GameObject
{
    internal class Player : GameObject, IGameObject
    {
        private int health;
        public Player(int x, int y, string name, int health)
            : base(x, y, name)
        {
            this.health = health;
        }

        public void Update()
        {
            ++x;
        }
        public override string ToString()
        {
            return $"Player {GetString()} (health = {health})";
        }
    }
}
