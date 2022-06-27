/*
 * Purpur Tentakel
 * 27.06.2022
 * Test - RollPlay - ICollectible
 */

namespace RolePlay.Collectibles
{
    internal interface ICollectibles
    {
        string Name { get; set; }
        int Use();
        bool IsUsable();
        string ToString();
        double HitChance { get; }
    }
}

/*
 * Bogen
 * StreitAxt
 * Zeihänder
 */
