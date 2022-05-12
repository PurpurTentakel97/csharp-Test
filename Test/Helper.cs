/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Helper
 */


namespace Helpers
{
    internal class Helper
    {
        public static string GetQuitInput()
        {
            Console.WriteLine("Um eine andere Schleife auszuprobieren tippe Enter");
            Console.WriteLine("Um das Spiel zu verlassen tippe 'q'");
            return Console.ReadLine();
        }
    }
}
