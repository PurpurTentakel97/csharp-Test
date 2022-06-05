/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Helper
 */


namespace Helpers
{
    internal class Helper
    {
        private static string invalidInput = "Invalider Input";
        public static string GetQuitInput()
        {
            Console.WriteLine("Um das Spiel zu verlassen tippe 'q'");
            Console.WriteLine("Ansonsten drücke Enter");
            return Console.ReadLine();
        }

        public static string GetString(string text)
        {
            while (true)
            {
                Console.WriteLine(text);
                string input = Console.ReadLine();

                if (input is null)
                {
                    Console.WriteLine(invalidInput);
                    continue;
                }

                input = input.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(invalidInput);
                    continue;
                }

                return input;
            }

        }
        public static byte GetByte(string text)
        {
            while (true)
            {
                Console.WriteLine(text);
                string inputRaw = Console.ReadLine();

                if (!byte.TryParse(inputRaw, out byte input))
                {
                    Console.WriteLine(invalidInput);
                    continue;
                }

                return input;
            }

        }
        public static ushort GetUshort(string text)
        {
            while (true)
            {
                Console.WriteLine(text);
                string inputRaw = Console.ReadLine();

                if (!ushort.TryParse(inputRaw, out ushort input))
                {
                    Console.WriteLine(invalidInput);
                    continue;
                }

                return input;
            }

        }
        public static double GetDouble(string text)
        {
            while (true)
            {
                Console.WriteLine(text);
                string inputRaw = Console.ReadLine();

                if (!double.TryParse(inputRaw, out double input))
                {
                    Console.WriteLine(invalidInput);
                    continue;
                }

                return input;
            }

        }
        public static float GetFloat(string text)
        {
            while (true)
            {
                Console.WriteLine(text);
                string inputRaw = Console.ReadLine();

                if (!float.TryParse(inputRaw, out float input))
                {
                    Console.WriteLine(invalidInput);
                    continue;
                }

                return input;
            }

        }
        public static int GetInt(string text)
        {
            while (true)
            {
                Console.WriteLine(text);
                string inputRaw = Console.ReadLine();

                if (!int.TryParse(inputRaw, out int input))
                {
                    Console.WriteLine(invalidInput);
                    continue;
                }

                return input;
            }

        }

        public static int[] GetRandomIntArray(int min, int max, int count)
        {
            var random = new Random();
            var randomNumbers = new int[count];
            for (int i = 0; i < count; i++)
            {
                int randomNumber = random.Next(min, max + 1);
                randomNumbers[i] = randomNumber;
            }

            return randomNumbers;


        }

        public static void FlipInt(ref int x)
        {
            if (x < 0)
            {
                x = x * -1;
            }
        }

        public static void PrintHeadline(string name)
        {
            Console.Clear();
            string equals = "==========";
            Console.Write(equals);
            for (int i = 0; i < name.Length + 2; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine(equals);

            Console.WriteLine($"{equals} {name} {equals}");

            Console.Write(equals);
            for (int i = 0; i < name.Length + 2; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine(equals);
            Console.WriteLine("");
        }
    }
}
