/*
 * Purpur Tentakel
 * 20.06.2022
 * Test - GameObject - GameObject
 */

namespace Test.GameObject
{
    internal class GameObject
    {
        protected int x;
        protected int y;
        protected string name;

        public GameObject(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }

        public string GetString()
        {
            return $"{name} @ ({x}/{y})";
        }
    }
}
