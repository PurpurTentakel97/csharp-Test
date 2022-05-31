/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Strings
 */

using Helpers;
using Menues;

namespace Strings
{
    internal class StringGame
    {
        private static (string, Action)[] menueValue = new (string, Action)[]
        {
            ("Sätze umdrehen", ReverseStringF),
            ("Liste einzeln ausgeben", StringListF),
            ("Liste einzeln ausgeben ohne Leerzeilen", StringListOutBlankF),
            ("Liste einlesen ohne Schleife", StringSplitF),
            ("Liste einlesen ohne Schleife und convertiertem Array" ,StringSplitAndConvertF),
            ("Liste einlesen ohne Schleife und convertiertem Array mit Methode", StringSplitAndConvertWithMethodF),
            ("Passwort checken", ComparePasswordF),
            ("Palindrom checken", PalindromeF),
            ("Palindrom2 checken", Palindrom2F),
            ("Andreaskreuz", CrossF),
            ("Fahne", UnionJackF),
            ("Fisch im Koihaufen", ContainsSubstringF),
        };
        public void Game()
        {
            Menue menue = new Menue("Satz Spiele", menueValue);
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

        private static void ReverseStringF()
        {
            var reverseString = new ReverseString();
            reverseString.Game();
        }
        private static void StringListF()
        {
            var stringList = new StringList();
            stringList.Game();
        }
        private static void StringListOutBlankF()
        {
            var stringListOutBlank = new StringListOutBlank();
            stringListOutBlank.Game();
        }
        private static void StringSplitF()
        {
            var stringSplit = new StringSplit();
            stringSplit.Game();
        }
        private static void StringSplitAndConvertF()
        {
            var stringSplitAndConvert = new StringSplitAndConvert();
            stringSplitAndConvert.Game();
        }
        private static void StringSplitAndConvertWithMethodF()
        {
            var stringSplitAndConvertWithMethod = new StringSplitAndConvertWithMethod();
            stringSplitAndConvertWithMethod.Game();
        }
        private static void ComparePasswordF()
        {
            var comparePassword = new ComparePassword();
            comparePassword.Game();
        }
        private static void PalindromeF()
        {
            var palindrome = new Palindrome();
            palindrome.Game();
        }
        private static void CrossF()
        {
            var cross = new Cross();
            cross.Game();
        }
        private static void UnionJackF()
        {
            var junionJack = new UnionJack();
            junionJack.Game();
        }
        private static void Palindrom2F()
        {
            var palindrom2 = new Palindrom2();
            palindrom2.Game();
        }
        private static void ContainsSubstringF()
        {
            var containsSubstring = new ContainsSubstring();
            containsSubstring.Game();
        }
    }
    internal class ReverseString
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Sätze umdrehen");

                string value = Helper.GetString("Gib einen Satz ein.");
                PrintReversedString(value);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }

        private void PrintReversedString(string value)
        {
            char[] chars = value.ToCharArray();
            Array.Reverse(chars);
            Console.WriteLine(new string(chars));
        }
    }
    internal class StringList
    {

        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Sätze umdrehen");

                string value = Helper.GetString("Gib duch Kommata separierte Werte ein:");
                string[] values = GetStringArray(value);
                PrintStringArray(values);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }

        private string[] GetStringArray(string value)
        {
            int counter = 0;
            foreach (char character in value)
            {
                if (character.Equals(','))
                {
                    counter++;
                }
            }
            counter++;

            string[] values = new string[counter];

            int counter2 = 0;
            string toArray = "";
            foreach (char character in value)
            {
                if (counter2 + 1 == counter)
                {
                    toArray += character;
                    values[counter2] = toArray;
                    continue;
                }

                if (character.Equals(','))
                {
                    values[counter2] = toArray;
                    toArray = "";
                    counter2++;
                    continue;
                }

                toArray += character;
            }

            return values;
        }
        private void PrintStringArray(string[] values)
        {
            foreach (string value in values)
            {
                Console.WriteLine(value);
            }
        }
    }
    internal class StringListOutBlank
    {

        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Sätze umdrehen");

                string value = Helper.GetString("Gib duch Kommata separierte Werte ein:");
                string[] values = GetStringArray(value);
                PrintStringArray(values);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }

        private string[] GetStringArray(string value)
        {
            int counter = 0;
            foreach (char character in value)
            {
                if (character.Equals(','))
                {
                    counter++;
                }
            }
            counter++;

            string[] values = new string[counter];

            int counter2 = 0;
            string toArray = "";
            foreach (char character in value)
            {
                if (counter2 + 1 == counter)
                {
                    toArray += character;
                    values[counter2] = toArray;
                    continue;
                }

                if (character.Equals(','))
                {
                    values[counter2] = toArray;
                    toArray = "";
                    counter2++;
                    continue;
                }

                toArray += character;
            }

            return values;
        }
        private void PrintStringArray(string[] values)
        {
            foreach (string value in values)
            {
                if (string.IsNullOrEmpty(value))
                {
                    continue;
                }
                Console.WriteLine(value);
            }
        }
    }
    internal class StringSplit
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Sätze umdrehen");

                string value = Helper.GetString("Gib duch Kommata separierte Werte ein:");
                string[] values = GetStringArray(value);
                PrintStringArray(values);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }
        private string[] GetStringArray(string value)
        {
            string[] values = value.Split(',');
            return values;
        }
        private void PrintStringArray(string[] values)
        {
            foreach (string value in values)
            {
                if (string.IsNullOrEmpty(value))
                {
                    continue;
                }
                Console.WriteLine(value);
            }
        }
    }
    internal class StringSplitAndConvert
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Sätze umdrehen");

                string value = Helper.GetString("Gib duch Kommata separierte Werte ein:");
                string[] values = GetStringArray(value);
                PrintStringArray(values);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }
        private string[] GetStringArray(string value)
        {
            string[] values = value.Split(',');
            return values;
        }
        private void PrintStringArray(string[] values)
        {
            string toPrint = "";
            foreach (string value in values)
            {
                if (string.IsNullOrEmpty(value))
                {
                    continue;
                }

                toPrint += value;
                toPrint += "\n";
            }

            toPrint = toPrint.Substring(0, toPrint.Length - 2);
            Console.WriteLine(toPrint);
        }
    }
    internal class StringSplitAndConvertWithMethod
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Sätze umdrehen");

                string value = Helper.GetString("Gib duch Kommata separierte Werte ein:");
                string[] values = GetStringArray(value);
                PrintStringArray(values);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }
        private string[] GetStringArray(string value)
        {
            string[] values = value.Split(',');
            return values;
        }
        private void PrintStringArray(string[] values)
        {
            string toPrint = String.Join("\n", values);
            Console.WriteLine(toPrint);
        }
    }
    internal class ComparePassword
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Passwort checken");

                string value = Helper.GetString("Gib dein Passwort ein. (Gib 'q' ein um die Eingabe zu abzubrechen):");

                if (value == "q")
                {
                    break;
                }

                if (IsPassword(value))
                {
                    Console.WriteLine("Zugriff gestattet, richtiges Passwort");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("Zugriff verweigert, Falsches Passwort");
                Console.ReadKey();
            }
        }

        private bool IsPassword(string value)
        {
            return value == "dfg987345";
        }
    }
    internal class Palindrome
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Palindrom checken");

                string value = Helper.GetString("Gib das Palindrom ein (Gib 'q' ein um die Eingabe zu abzubrechen):");

                if (value == "q")
                {
                    break;
                }

                Console.WriteLine($"{value} ist {(IsPalindrome(value) ? "ein" : "KEIN")} Palindrom.");
                Console.ReadKey();
            }
        }
        private bool IsPalindrome(string value)
        {
            for (int left = 0, right = value.Length - 1; left < right; left++, right--)
            {
                if (value[left] != value[right])
                {
                    return false;
                }

            }
            return true;
        }
    }
    internal class Palindrom2
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Palindrom2");

                char[] palindrome = Helper.GetString("Gib das Palindrome ein").ToArray();
                bool result = IsPalindrome(palindrome, 0);
                Print(result);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }

        private bool IsPalindrome(char[] palindrome, int index)
        {
            if (index > palindrome.Length / 2)
            {
                return true;
            }
            if (palindrome[index] != palindrome[palindrome.Length - 1 - index])
            {
                return false;
            }
            ++index;
            return IsPalindrome(palindrome, index);
        }
        private void Print(bool result)
        {
            if (result)
            {
                Console.WriteLine("Das Wort ist ein Palindrom");
            }
            else
            {
                Console.WriteLine("Das Wort ist kein Palindrom");
            }
        }
    }
    internal class Cross
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Andreaskreuz");
                int value = Helper.GetInt("Gib die Größe des Kreuzes ein.");

                Print2(value);

                string quitCondition = Helper.GetQuitInput();
                if (quitCondition == "q")
                {
                    break;
                }
            }
        }

        private void Print(int value)
        {
            Console.WriteLine();
            for (int i = 0; i < value; i++)
            {
                for (int j = 0; j < value; j++)
                {
                    if (i == j)
                    {
                        Console.Write("X");
                        continue;
                    }
                    if (value - 1 - i == j)
                    {
                        Console.Write("X");
                        continue;

                    }
                    Console.Write("-");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void Print2(int value)
        {
            for (int i = 0; i < value; i++)
            {
                var output = new string('-', value);
                char[] array = output.ToArray();
                array[i] = 'X';
                array[value - 1 - i] = 'X';
                Console.WriteLine(new string(array));
            }
        }
    }
    internal class UnionJack
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Fahne");
                int value = Helper.GetInt("Gib die Größe der Fahne ein.");

                if (value % 2 == 0)
                {
                    value++;
                }

                Print2(value);

                string quitCondition = Helper.GetQuitInput();
                if (quitCondition == "q")
                {
                    break;
                }
            }
        }

        private void Print(int value)
        {
            Console.WriteLine();
            for (int i = 0; i < value; i++)
            {
                for (int j = 0; j < value; j++)
                {
                    if (i == j || value - 1 - i == j || j == (value - 1) / 2)
                    {
                        Console.Write("X");
                        continue;
                    }
                    if (i == (value - 1) / 2)
                    {
                        Console.Write(new string('X', value));
                        break;
                    }
                    Console.Write("-");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void Print2(int value)
        {
            Console.WriteLine();
            for (int i = 0; i < value; i++)
            {
                if (i == (value - 1) / 2)
                {
                    Console.WriteLine(new string('X', value));
                    continue;
                }
                var output = new string('-', value);
                char[] array = output.ToArray();
                array[i] = 'X';
                array[value - 1 - i] = 'X';
                array[(value - 1) / 2] = 'X';
                Console.WriteLine(new string(array));
            }
            Console.WriteLine();
        }
    }
    internal class ContainsSubstring
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Nadel im Koihaufen");

                string hayStack = Helper.GetString("Gib den Koihaufen ein");
                string needle = Helper.GetString("Gib die Nadel ein");

                bool isInHayStack = IsInHayStack(hayStack, needle);
                Print(hayStack, needle, isInHayStack);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }
        private bool IsInHayStack(string haystack, string needle)
        {
            if (needle == "")
            {
                return true;
            }
            for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                if (haystack[i] == needle[0])
                {
                    if (CheckNeedle(haystack, needle, i))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool CheckNeedle(string haystack, string needle, int addIndex)
        {
            for (int i = 1; i < needle.Length; i++)
            {
                if (needle[i] != haystack[i + addIndex])
                {
                    return false;
                }
            }
            return true;
        }
        private void Print(string hayStack, string needle, bool isInHayStack)
        {
            Console.WriteLine();

            if (isInHayStack)
            {
                Console.WriteLine($"Der Fisch {needle} ist im Koihaufen {hayStack}");
            }
            else
            {
                Console.WriteLine($"Der Fisch {needle} hat sich nicht in den Koihaufen {hayStack} verirrt.");
            }

            Console.WriteLine();
        }
    }
}
