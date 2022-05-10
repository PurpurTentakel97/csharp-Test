/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Strings
 */

namespace Strings
{
    internal class ReverseString
    {
        public static void PrintReversedString(string value)
        {
            char[] chars = value.ToCharArray();
            Array.Reverse(chars);
            Console.WriteLine(new string(chars));
        }
    }
}
