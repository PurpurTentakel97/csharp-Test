/*
 * Purpur Tentakel
 * 27.06.2022
 * Test - RollPlay - MagicCristal
 */

namespace RolePlay.Collectibles
{
    internal class MagicCristal : Collectibles, ICollectibles
    {
        public string Name { get; set; }
        private double mana;
        private double manaPerUse;
        private double minHitChance = 0.6;
        private double maxHitChance = 0.95;
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

        public MagicCristal(string name, int mana, int manaPerUse, double hitChance)
        {
            Name = name;
            this.mana = mana;
            this.manaPerUse = manaPerUse;
            HitChance = hitChance;
        }
        public MagicCristal(string name, double mana, double manaPerUse, double hitChance)
        {
            Name = name;
            this.mana = mana;
            this.manaPerUse = manaPerUse;
            HitChance = hitChance;
        }
        public override string ToString()
        {
            string isUsable = IsUsable()
                ? "remaining uses: " + GetRemainingUsages() + " | attack: " + (int)manaPerUse + " | hit chance: " + (int)(hitChance * 100) + "%"
                : "not usable";
            return $"{Name} ({isUsable})";
        }

        public int Use()
        {
            if (!IsUsable())
            {
                return 0;
            }

            double currentManaPerUse = manaPerUse;
            mana -= manaPerUse;
            manaPerUse = manaPerUse * 1.5;

            return (int)currentManaPerUse;

        }
        public bool IsUsable()
        {
            return mana >= manaPerUse;
        }
        private int GetRemainingUsages()
        {
            MagicCristal dummy = new MagicCristal(Name, mana, manaPerUse, HitChance);
            int counter = 0;
            while (dummy.IsUsable())
            {
                dummy.Use();
                ++counter;
            }
            return counter;
        }
    }
}
