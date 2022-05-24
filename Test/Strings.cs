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
        //private static Dictionary<string, string> entries = new Dictionary<string, string>();
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
    }
}
