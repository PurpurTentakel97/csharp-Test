/*
 * Purpur Tentakel
 * 27.06.2022
 * Test - RollPlay - Sword
 */

namespace RolePlay.Collectibles
{
    internal class Sword : Collectibles, ICollectibles
    {
        public string Name { get; set; }
        private int remainigUses;
        private double attack;
        private double minHitChance = 0.9;
        private double hitChance;
        public double HitChance
        {
            get { return hitChance; }
            private set
            {
                bool validHitChace = minHitChance <= value && value <= maxHitChance;
                if (validHitChace)
                {
                    hitChance = value;
                    return;
                }

                hitChance = minHitChance;
            }
        }

        public Sword(string name, int uses, double attack, double hitChance)
        {
            Name = name;
            remainigUses = uses;
            this.attack = attack;
            this.HitChance = hitChance;
        }
        public override string ToString()
        {
            string isUsable = IsUsable()
                ? "remaining uses " + remainigUses + " | attack: " + attack + " | hit chance: " + (int)(hitChance * 100) + "%"
                : "not usable";
            return $"{Name} ({isUsable})";
        }

        public int Use()
        {
            if (!IsUsable())
            {
                return 0;
            }

            --remainigUses;
            return (int)attack;
        }
        public bool IsUsable()
        {
            return remainigUses > 0;
        }
    }
}
