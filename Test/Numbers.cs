/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Numbers
 */

using Helpers;
using Menues;

namespace Numbers
{
    internal class PrimeNumbers
    {
        public void Game()
        {

            while (true)
            {
                Helper.PrintHeadline("Prim Zahlen Ausgeben");

                ushort input = Helper.GetUshort("Trage ein bis zu welcher Zahl die Primzahlen ausgegeben werden sollen.");
                PrintPrimeNumbersTillX(input);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }
        private void PrintPrimeNumbersTillX(ushort maxNumber)
        {
            Helper.PrintHeadline("Prim Zahlen Ausgeben");

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

    internal class EffiicentPrimeNumbers
    {
        public static void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Effiziernt Prim Zahlen Ausgeben");

                ushort n = Helper.GetUshort("Trage ein bis zu welcher Zahl die Primzahlen ausgegeben werden sollen.");

                bool[] array = GetArray(n);
                array = SetArray(array);
                PrintArray(array);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }

        private static bool[] GetArray(int n)
        {
            bool[] array = new bool[n + 1];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = true;
            }
            return array;
        }

        private static bool[] SetArray(bool[] array)
        {
            for (int i = 2; i < array.Length - 1; i++)
            {
                if (!array[i])
                {
                    continue;
                }

                for (int j = 2 * i; j <= array.Length - 1; j += i)
                {
                    array[j] = false;
                }
            }
            return array;
        }

        private static void PrintArray(bool[] array)
        {
            Console.WriteLine($"Die Primzahlen bis {array.Length - 1} sind:");
            bool first = true;
            for (int i = 2; i < array.Length; i++)
            {
                if (!array[i])
                {
                    continue;
                }

                if (!first)
                {
                    Console.Write(", ");
                }

                first = false;

                Console.Write(i);
            }
            Console.WriteLine();
        }
    }

    internal class EvenNumbers
    {
        private static (string, Action)[] menueValue = new (string, Action)[]
        {
            ("For-Schleife",PrintFirstTenEvenNumbersFor),
            ("While_schleife",PrintFirstTenEvenNumbersWhile),
            ("Do-While_schleife",PrintFirstTenEvenNumbersDoWhile),
        };

        public void Game()
        {
            Menue menue = new Menue("Gerade Zahlen Ausgeben", menueValue);
            while (true)
            {
                menue.Print();
                Action action = menue.GetAction();
                if (action == null)
                {
                    break;
                }
                action();
            }
        }
        private static void PrintFirstTenEvenNumbersFor()
        {
            Helper.PrintHeadline("For-Schleife");

            (int left, int top) cursorPosition;
            for (int i = 1; i < 12; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write($"{i}, ");
                    if (i == 18)
                    {
                        cursorPosition = Console.GetCursorPosition();
                        Console.SetCursorPosition(cursorPosition.left - 2, cursorPosition.top);
                        Console.Write(" und ");
                    }
                }
            }
            cursorPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(cursorPosition.left - 2, cursorPosition.top);
            Console.WriteLine(".");
            Console.ReadLine();
        }
        private static void PrintFirstTenEvenNumbersWhile()
        {
            Helper.PrintHeadline("While-Schleife");

            int index = 1;
            while (index < 21)
            {
                PrintEvenNumber(index: index);
                index++;
            }
            var cursorPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(cursorPosition.Left - 2, cursorPosition.Top);
            Console.WriteLine(".");
            Console.ReadLine();
        }
        private static void PrintFirstTenEvenNumbersDoWhile()
        {
            Helper.PrintHeadline("Do-While-Schleife");

            int index = 1;
            do
            {
                PrintEvenNumber(index: index);
                index++;
            } while (index < 21);
            var cursorPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(cursorPosition.Left - 2, cursorPosition.Top);
            Console.WriteLine(".");
            Console.ReadLine();
        }

        private static void PrintEvenNumber(int index)
        {
            if (index % 2 == 0)
            {
                Console.Write($"{index}, ");
                if (index == 18)
                {
                    var cursorPosition = Console.GetCursorPosition();
                    Console.SetCursorPosition(cursorPosition.Left - 2, cursorPosition.Top);
                    Console.Write(" und ");
                }
            }
        }

    }

    internal class GuessNumber
    {
        private byte correctNumber;

        public void Game()
        {

            while (true)
            {
                Helper.PrintHeadline("Zahlen-Raten_Spiel");

                correctNumber = (byte)Random.Shared.Next(0, 101);
                bool win = false;
                byte count = 1;
                byte maxCount = 6;
                do
                {
                    Console.WriteLine($"Runde {count}:");
                    Console.WriteLine($"Verbleivbende Versuche: {maxCount - count + 1}");
                    byte input = Helper.GetByte("Gib deine Vermutung ein (0-100)");
                    if (CheckInput(input))
                    {
                        win = true;
                        break;
                    }
                    count++;
                } while (count <= maxCount);

                if (win)
                {
                    Console.WriteLine($"Glückwunsch Du hast gewonnen. Die richtige Zahl ist {correctNumber}");
                }
                else
                {
                    Console.WriteLine($"Du hast die Zahl leider nicht erraten. Die richtige Zahl wäre {correctNumber} gewesen.");
                }
                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
            Console.WriteLine("Programm beendet.");
        }
        private bool CheckInput(byte input)
        {
            if (correctNumber == input)
            {
                Console.WriteLine("Richtige Zahl");
                return true;
            }

            else if (correctNumber > input)
            {
                Console.WriteLine("Die Zahl ist zu Klein");
                return false;
            }

            Console.WriteLine("Die Zahl ist zu Groß");
            return false;

        }
    }

    internal class MyBitConverter
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("8 Bit Zahlen Konvertieren");

                byte input = Helper.GetByte("Gib die zu konventierenede Zahl ein (< 256)");
                string bit8 = ConvertNumberInto8Bit(input);
                Console.WriteLine(bit8);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }

        private string ConvertNumberInto8Bit(byte value)
        {
            string ret = "";
            byte bit = 128;
            while (bit > 0)
            {
                if (value >= bit)
                {
                    ret += "1";
                    value -= bit;
                    bit = (byte)((bit) / 2);
                    continue;
                }
                ret += "0";
                bit = (byte)((bit) / 2);
            }
            return ret;
        }
    }

    internal class Mean
    {

        public static void Game()
        {
            while (true)
            {
                double value = 0.0;
                int count = 0;

                Helper.PrintHeadline("Arithmetisches Mittel");
                Console.WriteLine("Gebe nacheinander beliebig viele Zahlen ein.");
                Console.WriteLine("Beende die Eingabe mit einer 0.");

                GetInput(ref value, ref count);

                Console.WriteLine(count > 0 ? $"Das Mittel ist {value / count}" : "Keine Eingabe erkannt");

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }
        private static void GetInput(ref double value, ref int count)
        {
            while (true)
            {
                double input = Helper.GetDouble("Gib eine Zahl ein:");
                if (input <= 0.0)
                {
                    break;
                }
                value += input;
                count++;
            }
        }
    }

    internal class Collatz
    {
        public static void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Collatz-Problem (1-100)");

                for (int n = 1; n <= 100; n++)
                {
                    WoCollatz(n);
                }


                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }
        private static void WoCollatz(int n)
        {
            bool is1Or2 = false;
            if (n == 1 || n == 2)
            {
                is1Or2 = true;
            }

            string output = $"n = {n}: ";

            while (true)
            {
                if (n == 1)
                {

                    if (is1Or2)
                    {
                        is1Or2 = false;
                    }
                    else
                    {
                        output += $"{n}";
                        break;
                    }
                }
                output += $"{n}, ";
                if (n % 2 == 0)
                {
                    n /= 2;
                }
                else
                {
                    n = n * 3 + 1;
                }
            }
            Console.WriteLine(output);
        }
    }

    internal class SortNumbers
    {
        public static void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Zahlen sortieren");

                int min = Helper.GetInt("Gib die hiedrignste Zahl der Liste ein");
                int max = Helper.GetInt("Gib die höchste Zahl der Liste ein");
                int count = Helper.GetInt("Gib die Anzahl der Zahlen ein");


                int[] numbers = Helper.GetRandomIntArray(min, max, count);

                SortNumberArray(ref numbers);

                PrintNumberArray(numbers);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }

            }
        }

        private static void SortNumberArray(ref int[] numbers)
        {
            for (int n = numbers.Length; n > 1; n--)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        (numbers[i], numbers[i + 1]) = (numbers[i + 1], numbers[i]);
                    }
                }
            }
        }

        private static void PrintNumberArray(int[] numbers)
        {
            Console.WriteLine("Sortierte Liste:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]}, ");
            }
            var cursor = Console.GetCursorPosition();
            Console.SetCursorPosition(cursor.Left - 2, cursor.Top);
            Console.WriteLine();
        }
    }

    internal class Temperature
    {
        private static int minTemperature;
        private static int maxTemperature;

        public static void Game()
        {
            Helper.PrintHeadline("Temperatur");

            minTemperature = Helper.GetInt("Gib die minimale Temperatur ein");
            maxTemperature = Helper.GetInt("Gib die maximale Temperatur ein");

            while (true)
            {
                Helper.PrintHeadline("Temperatur");

                int currentTemperature = Helper.GetInt("Gib die aktuelle Teperatur ein");
                PrintCheckTemperature(currentTemperature);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }

        private static void PrintCheckTemperature(int currentTemperature)
        {
            if (currentTemperature < minTemperature)
            {
                Console.WriteLine($"Die akruelle Teperatur von {currentTemperature}°C ist unter {minTemperature}°C");
                return;
            }

            if (currentTemperature > maxTemperature)
            {
                Console.WriteLine($"Die aktuelle Temperatur von {currentTemperature}°C ist über {maxTemperature}°C");
                return;
            }

            Console.WriteLine($"Die aktuelle Temperatur von {currentTemperature}°C ist OK");
        }
    }
}
