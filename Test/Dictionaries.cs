/*
 * Purpur Tentakel
 * 13.05.2022
 * Test - Dictionaries
 */

using Helpers;
using Lists;
using Menues;
using System.Text.Json;

namespace Dictionaries
{
    internal class MyDictionarryList
    {
        // uneven index = word
        // even index = Explanation
        private static string saved = "saved....";
        private static LinkedList entries = new LinkedList();
        private static (string, Action)[] menueValue = new (string, Action)[]
        {
            ("Eintrag anzeigen",Show),
            ("Alle Einträge anzeigen",ShowAll),
            ("Eintrag anlegen",Add),
            ("Eintrag ändern",Edit),
            ("Eintrag löschen",Delete),
            ("Wörterbuch Speichern",Save),
            ("Wörterbuch laden",Load),
         };



        public void Game()
        {
            Menue menue = new Menue("Wörterbuch", menueValue, before: true);
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

        private static void Show()
        {
            Helper.PrintHeadline("Eintrag anzeigen");

            try
            {
                string word = Helper.GetString("Gib ein Wort ein");
                int index = entries.Get(word);

                if (!IsEvenIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }

                string explenation = entries.Get(index + 1);
                Console.WriteLine(explenation);
            }
            catch (Exception ex) when (ex is IndexOutOfRangeException || ex is InvalidOperationException)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
        private static void ShowAll()
        {
            Helper.PrintHeadline("Alle Einträge");

            Console.WriteLine("Nummer // Wort // Beschreibung");
            for (int i = 0; i < entries.Count; i += 2)
            {
                int count = i / 2 + 1;
                Console.WriteLine($"{count}. // {entries.Get(i)} // {entries.Get(i + 1)}");
            }
            Console.ReadLine();

        }
        private static void Add()
        {
            Helper.PrintHeadline("Hinzufügen");

            string word = Helper.GetString("Gib das zu speichende Wort ein:");
            string explenation = Helper.GetString("Gib die zu speichernde Erklärung ein:");

            if (!entries.Exists(word))
            {
                entries.Add(word);
                entries.Add(explenation);
                Console.WriteLine(saved);
            }
            else
            {
                Console.WriteLine("Eintrag bereits vorhanden");
            }

            Console.ReadLine();

        }
        private static void Edit()
        {
            Helper.PrintHeadline("Eintrag editieren");

            try
            {
                string word = Helper.GetString("Gib das zu ändernde Wort ein:");
                string explenation = Helper.GetString("Gib die neue Deffinition ein:");
                int index = entries.Get(word);
                if (!IsEvenIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }
                entries.Replace(explenation, index + 1);
                Console.WriteLine(saved);
            }
            catch (Exception ex) when (ex is IndexOutOfRangeException || ex is InvalidOperationException)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }


        }
        private static void Delete()
        {
            Helper.PrintHeadline("Löschen");

            string word = Helper.GetString("Gibt das zu löschende Word ein:");
            try
            {
                int index = entries.Get(word);
                entries.Delete(index);
                entries.Delete(index);
                Console.WriteLine(saved);

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }


        }
        private static void Save()
        {
            Helper.PrintHeadline("Wörterbuch speichern");

            List<string> data = new List<string>();
            for (int i = 0; i < entries.Count; i++)
            {
                data.Add(entries.Get(i));
            }
            string fileName = Helper.GetString("Gib den Filenamen an:");
            string json = JsonSerializer.Serialize(data);

            File.WriteAllText(@$"{fileName}.json", json);
            Console.WriteLine(saved);

            Console.ReadLine();
        }
        private static void Load()
        {
            try
            {
                Helper.PrintHeadline("Wörterbuch laden");

                string fileName = Helper.GetString("Gib den Dateinamen ein:");
                List<string> data = new List<string>();
                string json = File.ReadAllText($@"{fileName}.json");
                data = JsonSerializer.Deserialize<List<string>>(json);

                entries.Clear();
                foreach (string entry in data)
                {
                    entries.Add(entry);
                }
                Console.WriteLine("loaded....");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File nicht gefunden.");
            }
            finally
            {
                Console.ReadLine();
            }
        }


        private static bool IsEvenIndex(int index)
        {
            return index % 2 == 0;
        }
    }

    internal class MyDictionarryDict
    {
        private static string saved = "saved....";
        private static Dictionary<string, string> entries = new Dictionary<string, string>();
        private static (string, Action)[] menueValue = new (string, Action)[]
        {
            ("Eintrag anzeigen",Show),
            ("Alle Einträge anzeigen",ShowAll),
            ("Eintrag anlegen",Add),
            ("Eintrag ändern",Edit),
            ("Eintrag löschen",Delete),
            ("Wörterbuch Speichern",Save),
            ("Wörterbuch laden",Load),
        };

        public void Game()
        {
            Menue menue = new Menue("Wörterbuch", menueValue, before: true);
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

        private static void Show()
        {
            Helper.PrintHeadline("Eintrag Anzeigen");

            string key = Helper.GetString("Gib das anzuzeigende Wort ein:");

            if (entries.ContainsKey(key))
            {
                Console.WriteLine(entries[key]);
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Eintrag nicht vorhanden.");
            Console.ReadLine();
        }
        private static void ShowAll()
        {
            Helper.PrintHeadline("Alle Einträge anzeigen");

            Console.WriteLine("Nummer // Wort // Beschreibung");
            int counter = 1;
            foreach (string key in entries.Keys)
            {
                Console.WriteLine($"{counter}. // {key} // {entries[key]}");
                counter++;
            }
            Console.ReadLine();
        }
        private static void Add()
        {
            Helper.PrintHeadline("Eintrag Hinzugügen");

            string key = Helper.GetString("Gebe das neue Wort ein:");
            string value = Helper.GetString("Gibt die neue Beschreibung ein:");

            if (!entries.ContainsKey(key))
            {
                entries.Add(key, value);
                Console.WriteLine(saved);
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Eintrag existiert bereits.");
            Console.ReadLine();
        }
        private static void Edit()
        {
            Helper.PrintHeadline("Eintrag editieren");

            string key = Helper.GetString("Gib das zu editierende Wort ein:");
            if (entries.ContainsKey(key))
            {
                string value = Helper.GetString("Gib die neue Beschreibung ein");
                entries[key] = value;
                Console.WriteLine(saved);
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Wort nicht vorhanden");
            Console.ReadLine();
        }
        private static void Delete()
        {
            Helper.PrintHeadline("Eintrag löschen");

            string key = Helper.GetString("Gib das zu löschende Wort ein");

            if (entries.ContainsKey(key))
            {
                entries.Remove(key);
                Console.WriteLine(saved);
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Wort nicht vorhanden");
            Console.ReadLine();
        }
        private static void Save()
        {
            Helper.PrintHeadline("Wörterbuch speichern");

            List<string> data = new List<string>();
            foreach (string key in entries.Keys)
            {
                data.Add(key);
                data.Add(entries[key]);
            }
            string fileName = Helper.GetString("Gib den Filenamen an:");
            string json = JsonSerializer.Serialize(data);

            File.WriteAllText(@$"{fileName}.json", json);
            Console.WriteLine(saved);

            Console.ReadLine();

        }
        private static void Load()
        {
            try
            {
                Helper.PrintHeadline("Wörterbuch laden");

                string fileName = Helper.GetString("Gib den Dateinamen ein:");
                List<string> data = new List<string>();
                string json = File.ReadAllText($@"{fileName}.json");
                data = JsonSerializer.Deserialize<List<string>>(json);

                entries.Clear();
                for (int i = 0; i < data.Count; i += 2)
                {
                    entries.Add(data[i], data[i + 1]);
                }
                Console.WriteLine("loaded....");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File nicht gefunden.");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
