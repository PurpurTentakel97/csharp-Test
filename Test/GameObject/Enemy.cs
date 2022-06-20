/*
 * Purpur Tentakel
 * 20.06.2022
 * Test - GameObject - Enemy
 */

namespace Test.GameObject
{
    internal class Enemy : GameObject, IGameObject
    {
        private int strength;
        public Enemy(int x, int y, string name, int strength)
            : base(x, y, name)
        {
            this.strength = strength;
        }

        public void Update()
        {
            ++x;
            ++y;
        }
        public override string ToString()
        {
            return $"Enemy {GetString()} (health = {strength})";
        }
    }
}
