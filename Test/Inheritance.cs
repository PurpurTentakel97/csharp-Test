/*
 * Purpur Tentakel
 * 27.06.2022
 * Test - Inheritance
 */

using Helpers;

namespace InheritanceNS
{
    internal class Inheritance
    {
        public void Game()
        {
            while (true)
            {
                Console.Clear();
                Helper.PrintHeadline("Inheritance");

                Execute();

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }

        private void Execute()
        {
            Console.WriteLine("Class A");
            A.F();

            Console.WriteLine("Class B");
            B.F();

            Console.WriteLine("Class C");
            C.F();

            Console.WriteLine("Class D");
            D.F();

            Console.WriteLine("Class E");
            E.F();
        }

        internal class A
        {
            public static void F()
            {
                Console.WriteLine("Method from Class A");
            }
        }
        internal class B : A { }
        internal class C : A { }
        internal class D : B
        {
            new public static void F()
            {
                Console.WriteLine("Method from Class D");
            }
        }
        internal class E : B { }
    }
}
