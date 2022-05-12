namespace Menues
{
    class Menue
    {
        private string name;
        private Entry[] entries;

        public Menue(string name, (string, Action)[] entrieValues)
        {
            this.name = name;
            entries = new Entry[entrieValues.Length];
            CreateEntries(entrieValues);
        }

        public void Print()
        {
            Console.Clear();
            PrintHeadline(name);
            foreach (Entry entry in entries)
            {
                Console.WriteLine($"({Array.IndexOf(entries, entry) + 1}) {entry.name}");
            }
        }

        public Action GetAction()
        {
            byte input = GetInput();
            return entries[input - 1].action;
        }

        private byte GetInput()
        {
            while (true)
            {
                Console.WriteLine("Wähle einen Punkt mit der Zahl aus.");
                Console.WriteLine("Schreibe 'q' um das Programm zu beenden.");
                string inputRaw = Console.ReadLine();
                if (inputRaw is null)
                {
                    Console.WriteLine("Keine Eingabe");
                    continue;
                }
                if (inputRaw == "q")
                {
                    Console.WriteLine("closing...");
                    Environment.Exit(0);
                }
                if (!byte.TryParse(inputRaw, out byte input))
                {
                    Console.WriteLine("Invalide Eingabe");
                    continue;
                }
                if (input > entries.Length || input == 0)
                {
                    Console.WriteLine("Invalide Eingabe");
                    continue;
                }
                return input;
            }
        }

        private void CreateEntries((string, Action)[] entrieValues)
        {
            for (int i = 0; i < entrieValues.Length; i++)
            {
                var value = entrieValues[i];
                var entry = new Entry(value.Item1, value.Item2);
                entries[i] = entry;
            }
        }

        public static void PrintHeadline(string name)
        {
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


        class Entry
        {
            public string name;
            public Action action;

            public Entry(string name, Action action)
            {
                this.name = name;
                this.action = action;
            }

        }
    }
}
