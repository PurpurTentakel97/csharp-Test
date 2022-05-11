namespace Test
{
    internal class GuessNumber
    {
        private byte correctNumber;

        public void Game()
        {
            while (true)
            {
                correctNumber = (byte)Random.Shared.Next(0, 101);
                bool win = false;
                byte count = 1;
                byte maxCount = 6;
                do
                {
                    Console.WriteLine($"Runde {count}:");
                    Console.WriteLine($"Verbleivbende Versuche: {maxCount - count + 1}");
                    byte input = GetInput();
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
                Console.WriteLine("Wenn du noch ein Spiel spielen möchtest drücke 'Enter'");
                Console.WriteLine("Schreibe 'quit' mas Programm zu beenden");
                string question = Console.ReadLine();
                if (question == "quit")
                {
                    break;
                }
            }
            Console.WriteLine("Programm beendet.");
        }

        private byte GetInput()
        {
            while (true)
            {
                Console.WriteLine("Gib deine Vermutung ein (0-100)");
                string inputS = Console.ReadLine();

                if (byte.TryParse(inputS, out byte input))
                {
                    if (input < 101)
                    {
                        return input;
                    }
                }

                Console.WriteLine("Ungültige Eingabe");
            }
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
}
