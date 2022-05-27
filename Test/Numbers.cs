/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Numbers
 */

using Helpers;
using Menues;

namespace Numbers
{
    internal class NumberGame
    {
        private static (string, Action)[] menueValue = new (string, Action)[]
        {
            ("Prim Zahlen", PrimeNumbersF),
            ("Effiziente Prim Zahlen", EfficientPrimeNumbersF),
            ("Gerade Zahlen", EvenNumbersF),
            ("Zahlen raten", GuessNumberF),
            ("Bit Konvberter", MyBitConverterF),
            ("Durschnitt berechnen", MeanF),
            ("Collatz-Folge", CollatzF),
            ("Zahlen sortieren", SortNumbersF),
            ("Temperatur überprüfen", TemperatureF),
            ("Modulo X", ModuloXF),
            ("Aufsteigende Nummer Sequenz", SeqienceOfNumebrsF),
            ("Aufsteigende Nummer Sequenz 2", SeqienceOfNumebrs2F),
            ("Quadratzahlen", SquareNumbersF),
            ("Mitternachtsformel", MidnightFormulaF),
            ("Rechner", CalculateF),
        };

        public void Game()
        {
            Menue menue = new Menue("Zahlen Spiele", menueValue);
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

        private static void PrimeNumbersF()
        {
            PrimeNumbers.Game();
        }
        private static void EfficientPrimeNumbersF()
        {
            EfficentPrimeNumbers.Game();
        }
        private static void EvenNumbersF()
        {
            var evenNumbers = new EvenNumbers();
            evenNumbers.Game();
        }
        private static void GuessNumberF()
        {
            var guessNumbers = new GuessNumber();
            guessNumbers.Game();
        }
        private static void MyBitConverterF()
        {
            var myBitConverter = new MyBitConverter();
            myBitConverter.Game();
        }
        private static void MeanF()
        {
            Mean.Game();
        }
        private static void CollatzF()
        {
            Collatz.Game();
        }
        private static void SortNumbersF()
        {
            SortNumbers.Game();
        }
        private static void TemperatureF()
        {
            Temperature.Game();
        }
        private static void ModuloXF()
        {
            var moduloX = new ModuloX();
            moduloX.Game();
        }
        private static void SeqienceOfNumebrsF()
        {
            var seqienceOfNumebrs = new SeqienceOfNumebrs();
            seqienceOfNumebrs.Game();
        }
        private static void SeqienceOfNumebrs2F()
        {
            var seqienceOfNumebrs2 = new SeqienceOfNumebrs2();
            seqienceOfNumebrs2.Game();
        }
        private static void SquareNumbersF()
        {
            var squareNumbers = new SquareNumbers();
            squareNumbers.Game();

        }
        private static void MidnightFormulaF()
        {
            var midnightFormula = new MidnightFormula();
            midnightFormula.Game();
        }
        private static void CalculateF()
        {
            var calculate = new Calculate();
            calculate.Game();
        }
    }

    internal class PrimeNumbers
    {
        public static void Game()
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
        private static void PrintPrimeNumbersTillX(ushort maxNumber)
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

    internal class EfficentPrimeNumbers
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
                if (input == 0.0)
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

    internal class ModuloX
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Modulo X");

                int[] values = GetValues();
                List<int> modValues = GetModuloValues(values);
                Print(modValues, values);


                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }

        private int[] GetValues()
        {
            int min;
            int max;
            do
            {
                min = Helper.GetInt("Gib die kleinste Zahl ein");
                max = Helper.GetInt("Gib die größste Zahl ein");
                if (min >= max)
                {
                    Console.WriteLine("Kleine Zahl größer als oder gleich große Zahl. Erneute Eingabe:");
                }
            } while (min > max);

            int mod = Helper.GetInt("Gib die Zahl ein, durch die die Zahlen Teilbar sein sollen");

            int[] values = new int[] { min, max, mod };

            return values;
        }

        private List<int> GetModuloValues(int[] values)
        {
            int min = values[0];
            int max = values[1];
            int mod = values[2];

            var modValues = new List<int>();
            for (int i = min; i < max + 1; i++)
            {
                if (i % mod == 0)
                {
                    modValues.Add(i);
                }
            }
            return modValues;
        }

        private void Print(List<int> modValues, int[] values)
        {
            int min = values[0];
            int max = values[1];
            int mod = values[2];

            Console.WriteLine($"Die ganzzahlich durch {mod} teilbaren Zahlen zwischen {min} und {max} sind:");
            for (int i = 0; i < modValues.Count; i++)
            {
                if (i == modValues.Count - 1)
                {
                    Console.Write($"{modValues[i]}.");
                    continue;
                }
                if (i == modValues.Count - 2)
                {
                    Console.Write($"{modValues[i]} und ");
                    continue;
                }

                Console.Write($"{modValues[i]}, ");
            }

            Console.WriteLine();
        }
    }

    internal class SeqienceOfNumebrs
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Aufsteigende Nummer Sequenz");

                int n = Helper.GetInt("Wie viele Nummern sollen ausgegeben werden?");

                Print(n);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }

        private void Print(int n)
        {
            Console.WriteLine();
            int count = 1;
            Console.WriteLine();

            for (int i = 1; i < n + 1; i++)
            {
                var position = Console.GetCursorPosition();

                Console.SetCursorPosition(position.Left, position.Top - 1);
                Console.Write($"{count}  ");

                position = Console.GetCursorPosition();

                Console.SetCursorPosition(position.Left, position.Top + 1);

                Console.Write($"{i}  ");
                count += i;
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }

    internal class SeqienceOfNumebrs2
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Aufsteigende Nummer Sequenz");

                int min = Helper.GetInt("Gib die niedrigste Zahl ein");
                int max = Helper.GetInt("Gib die höchste Zahl ein");
                int step = Helper.GetInt("Gib ein alle wie viele Zahlen 100 addiert werden soll");

                Print(min, max, step);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }
        private void Print(int min, int max, int step)
        {
            for (int i = min; i <= max; i++)
            {
                if (i % step == 0)
                {
                    Console.Write($"{i + 100}, ");
                    continue;
                }

                Console.Write($"{i}, ");
            }
            Console.WriteLine();
        }
    }

    internal class SquareNumbers
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Quadratzahlen");

                int min = Helper.GetInt("Gib die niedrigste Zahl ein");
                int max = Helper.GetInt("Gib die höchste Zahl ein");

                if (min > max)
                {
                    (min, max) = (max, min);
                }

                Print(min, max);


                string quitCondition = Helper.GetQuitInput();
                if (quitCondition == "q")
                {
                    break;
                }
            }
        }

        private void Print(int min, int max)
        {
            int sum = 0;
            int maxILength = max.ToString().Length;
            int maxSquareLength = (max * max).ToString().Length;

            Console.WriteLine();
            for (int i = min; i < max + 1; i++)
            {
                int squared = i * i;
                sum += squared;

                string iOut = i.ToString().PadLeft(maxILength + 2);
                string squaredOut = squared.ToString().PadLeft(maxSquareLength);
                Console.WriteLine($"{iOut}   {squaredOut}");

            }

            Console.WriteLine();
            Console.WriteLine($"Sie Summe der Quadratzahlen zwischen {min} und {max} ist {sum}.");
            Console.WriteLine();
        }
    }

    internal class MidnightFormula
    {
        private double a = 0.0;
        private double b = 0.0;
        private double c = 0.0;

        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Mitternachtsformel");

                PrintTask();

                a = Helper.GetDouble("a = ?");
                b = Helper.GetDouble("b = ?");
                c = Helper.GetDouble("c = ?");

                double D = CalculateDiscriminant(a, b, c);
                Console.WriteLine(D);
                int solutionCount = GetSoultionCount(D);
                Console.WriteLine(solutionCount);

                double? x1 = null;
                if (solutionCount >= 0)
                {
                    x1 = GetFirstSolution(D, a, b);
                }

                double? x2 = null;
                if (solutionCount > 0)
                {
                    x2 = GetSecondSolution(D, a, b);
                }

                Print(solutionCount, x1, x2);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }

        private void PrintTask()
        {
            Console.WriteLine();
            Console.WriteLine("Rechner für quatische Gleichungen vpm Typ:");
            Console.WriteLine("( 0 = ax^2 + bx +  c )");
            Console.WriteLine();
            Console.WriteLine("Folgende Koeffizienten eingeben:");
        }
        private double CalculateDiscriminant(double a, double b, double c)
        {
            return (b * b) - (4 * a * c);
        }
        private int GetSoultionCount(double D)
        {
            if (D < 0)
            {
                return 0;
            }

            if (D > 0)
            {
                return 2;
            }

            return 1;
        }
        private double GetFirstSolution(double D, double a, double b)
        {
            return (-b + Math.Sqrt(D) / (2 * a));
        }
        private double GetSecondSolution(double D, double a, double b)
        {
            return (-b - Math.Sqrt(D) / (2 * a));
        }
        private void Print(int solutionCout, double? x1, double? x2)
        {
            if (solutionCout == 0)
            {
                Console.WriteLine("Keine Lösung vorhanden");
            }
            if (solutionCout == 1)
            {
                Console.WriteLine($"x = {x1}");
            }
            if (solutionCout == 2)
            {
                Console.WriteLine($"x1 = {x1}, x2 = {x2}");
            }
            Console.WriteLine();
        }
    }

    internal class Calculate
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Rechner");

                float value1 = Helper.GetFloat("Gib die erste Zahl ein");
                string operation;
                while (true)
                {
                    operation = Helper.GetString("Gib die Rechenart ein. (+,-,*,/)");
                    if (new string[] { "+", "-", "*", "/" }.Contains(operation))
                    {
                        break;
                    }
                    Console.WriteLine("Invalider Input");
                }
                float value2 = Helper.GetFloat("Gib die zweite Zahl ein");

                float result = Calculation(value1, operation, value2);

                Print(result, value1, operation, value2);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }

        private float Calculation(float value1, string operation, float value2)
        {
            switch (operation)
            {
                case "+":
                    return Add(value1, value2);
                case "-":
                    return Substract(value1, value2);
                case "*":
                    return Multiply(value1, value2);
                case "/":
                    return Divide(value1, value2);
            }
            return 0f;
        }

        private float Add(float value1, float value2)
        {
            return value1 + value2;
        }
        private float Substract(float value1, float value2)
        {
            return value1 - value2;
        }
        private float Multiply(float value1, float value2)
        {
            return value1 * value2;
        }
        private float Divide(float value1, float value2)
        {
            if (value2 == 0f)
            {
                Console.WriteLine("Bevide by Zero");
                return 0f;
            }
            return value1 / value2;
        }

        private void Print(float result, float value1, string operation, float value2)
        {
            Console.WriteLine($"{value1} {operation} {value2} = {result}");
        }
    }
}
