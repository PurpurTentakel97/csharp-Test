/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Numbers
 */

namespace Numbers
{
    internal class PrimeNumbers
    {
        public static void PrintPrimeNumbersTillX(int maxNumber)
        {
            for (int i = 2; i < maxNumber; i++)
            {
                bool found = false;
                for (int j = 2; j < i; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (i % j == 0)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.Write($"{i}, ");
                }

            }
            Console.WriteLine("");
        }
    }
}
