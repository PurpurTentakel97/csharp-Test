/*
 * Purpur Tentakel
 * 13.06.2022
 * Test - Sport Bet
 */

using Helpers;

namespace Test
{
    internal class SportBet
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("Sport Bet");
                execute();
                string quit_input = Helper.GetQuitInput();
                if (quit_input == "q")
                {
                    break;
                }
            }
        }

        private Random random = new Random();
        string[] teams = new string[]
            {
                "MostWanted38",
                "HAKUINU",
                "NECROMENZER",
                "Pedder__",
                "Coder2k",
                "dragoman12",
            };

        private void execute()
        {
            GameEntry[] games = GenerateGames(teams);
            Outcome[] outcome = ReadAllBets(games);
            Console.WriteLine("\n==================================================================\n");
            PrintResults(games, outcome);

        }

        public enum Outcome
        {
            DRAW, // 0
            HOME_VICTORY, // 1
            AWAY_VICTORY, // 2
        }
        private Outcome GenerateRandomOutcome()
        {
            int generated = random.Next(0, 3);
            return (Outcome)generated;
        }
        private string OutcomeToText(Outcome outcome)
        {
            switch (outcome)
            {
                case Outcome.DRAW:
                    return "draw";
                case Outcome.HOME_VICTORY:
                    return "home voctory";
                case Outcome.AWAY_VICTORY:
                    return "away victory";
                default:
                    return "";
            }
        }
        private string PrintPossibleOutcome()
        {
            string output = "";
            foreach (Outcome outcome in Enum.GetValues(typeof(Outcome)))
            {
                output += $"{(int)outcome} = {OutcomeToText(outcome)}, ";
            }
            return output;
        }

        private GameEntry[] GenerateGames(string[] teams)
        {
            GameEntry[] games = new GameEntry[teams.Length * (teams.Length - 1)];
            int gammeIndex = 0;
            for (int i = 0; i < teams.Length; i++)
            {
                for (int j = 0; j < teams.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    Outcome outcome = GenerateRandomOutcome();
                    GameEntry game = new GameEntry(teams[i], teams[j], outcome);
                    games[gammeIndex] = game;
                    ++gammeIndex;
                }
            }
            return games;
        }

        private Outcome ReadBet(string homeTeam, string awayTeam)
        {
            Console.WriteLine("next game:");
            Console.WriteLine($"  {homeTeam} (home team) : {awayTeam} (away team)");
            int outcomeCount = Enum.GetValues(typeof(Outcome)).Length;
            int input;
            while (true)
            {
                input = Helper.GetInt($"  youre guess? ({PrintPossibleOutcome()})");

                bool validInput = 0 <= input && input < outcomeCount;
                if (validInput)
                {
                    break;
                }
                Console.WriteLine("invalid input");
            }
            return (Outcome)input;
        }
        private Outcome[] ReadAllBets(GameEntry[] games)
        {
            Outcome[] outcomes = new Outcome[games.Length];
            for (int i = 0; i < games.Length; i++)
            {
                GameEntry game = games[i];
                outcomes[i] = ReadBet(game.HomeTeam, game.AwayTeam);
                Console.WriteLine();
            }
            return outcomes;
        }

        private void PrintResults(GameEntry[] games, Outcome[] outcomes)
        {
            int points = 0;

            for (int i = 0; i < games.Length; i++)
            {
                GameEntry game = games[i];
                Outcome outcome = outcomes[i];

                Console.WriteLine($"game {i + 1} of {games.Length}, {game.HomeTeam} : {game.AwayTeam}:");
                Console.WriteLine($"  youre bet: {OutcomeToText(outcome)}");
                Console.WriteLine($"  outcome: {OutcomeToText(game.Outcome)}");
                Console.WriteLine();


                if (outcome == game.Outcome)
                {
                    ++points;
                }
            }
            Console.WriteLine($"You got {points} of {games.Length} points.");
        }

        internal class GameEntry
        {
            public Outcome Outcome { get; private set; }
            public string HomeTeam { get; private set; }
            public string AwayTeam { get; private set; }

            public GameEntry(string homeTeam, string awayTeam, Outcome outcome)
            {
                Outcome = outcome;
                HomeTeam = homeTeam;
                AwayTeam = awayTeam;
            }


        }
    }
}
