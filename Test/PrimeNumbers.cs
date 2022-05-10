namespace Numbers
{
    internal class PrimeNumbers
    {
        public static void PrintPrimeNumbersTillX(int maxNumber)
        {
            if (maxNumber <= 0)
            {
                Console.WriteLine("Zahl kleiner Null");
                return;
            }

            if (maxNumber > 10000)
            {
                Console.WriteLine("Zahl zu groß");
                return;
            }

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
