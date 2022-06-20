/*
 * Purpur Tentakel
 * 20.06.2022
 * Test - TicTacToe - TestGame
 */

using Helpers;

namespace Test.TicTacToe
{
    internal class TestGame
    {
        public void Game()
        {
            while (true)
            {
                Console.Clear();
                Helper.PrintHeadline("TicTacToe");

                int dimension = Helper.GetInt("enter dimension (2-9)");
                Execute(dimension);

                if (Helper.GetQuitInput() == "q")
                {
                    break;
                }
            }
        }
        public void Execute(int dimention)
        {
            var gameState = new GameState(dimention);
            Marker playerMarker = Marker.X;
            Marker computerMarker = Marker.O;
            var computerPlayer = new ComputerPlayer(computerMarker);

            while (true)
            {
                PrintGame(gameState);

                bool isPlayerTurn = gameState.CurrentPlayer == playerMarker;
                if (isPlayerTurn)
                {
                    Position position = GetPlayerMove(gameState);
                    gameState.SetField(position);
                }
                else
                {
                    Position position = computerPlayer.GetNextMove(gameState);
                    gameState.SetField(position);
                }

                bool playerWon = gameState.HasPlayerWon(gameState.CurrentPlayer);
                if (playerWon)
                {
                    PrintGame(gameState);
                    Console.WriteLine($"Won: {gameState.CurrentPlayer}");
                    break;
                }

                bool gameOver = !gameState.HasAnyEmptyFields();
                if (gameOver)
                {
                    PrintGame(gameState);
                    Console.WriteLine("Draw");
                    break;
                }
                gameState.SwitchPlayers();
            }
        }
        private Position GetPlayerMove(GameState gameState)
        {
            Console.WriteLine("your move?");
            while (true)
            {
                int row = Helper.GetInt("  Row:");
                int column = Helper.GetInt("  Column:");

                bool validRow = Helper.IsInRange(row, 0, gameState.Dimension + 1);
                if (!validRow)
                {
                    Console.WriteLine("Invalid row. Try again");
                    continue;
                }

                bool validColumn = Helper.IsInRange(column, 0, gameState.Dimension + 1);
                if (!validColumn)
                {
                    Console.WriteLine("Invalid column. Try again");
                    continue;
                }

                bool validField = gameState.IsFieldEmpty(row - 1, column - 1);
                if (!validField)
                {
                    Console.WriteLine("Invalid field. Try again");
                    continue;
                }

                return new Position(row - 1, column - 1);

            }
        }

        private void PrintGame(GameState gameState)
        {
            Console.Clear();
            Helper.PrintHeadline("TicTacToe");

            Console.WriteLine("playing field:\n");
            Console.WriteLine(gameState.ToString());
            Console.WriteLine();
        }
    }
}
