/*
 * Purpur Tentakel
 * 20.06.2022
 * Test - TicTacToe - ComputerPlayer
 */

using Helpers;

namespace Test.TicTacToe
{
    internal class ComputerPlayer
    {
        private Marker Computer { get; set; }
        private Marker Human { get; set; }

        public ComputerPlayer(Marker computer)
        {
            Computer = computer;
            Human = GameState.GetOtherPlayer(computer);
        }
        public Position GetNextMove(GameState gameState)
        {
            var possibleMoves = new List<Position>();
            for (int row = 0; row < gameState.Dimension; row++)
            {
                for (int column = 0; column < gameState.Dimension; column++)
                {
                    var currentPosition = new Position(row, column);

                    if (!gameState.IsFieldEmpty(currentPosition))
                    {
                        break;
                    }

                    GameState copyGameState = gameState.GetCopy();
                    copyGameState.SetField(currentPosition, Computer);
                    if (copyGameState.HasPlayerWon(Computer))
                    {
                        return currentPosition;
                    }

                    copyGameState = gameState.GetCopy();
                    copyGameState.SetField(currentPosition, Human);
                    if (copyGameState.HasPlayerWon(Human))
                    {
                        return currentPosition;
                    }

                    possibleMoves.Add(currentPosition);
                }
            }
            int random = Helper.GetRandomInt(0, possibleMoves.Count - 1);
            return possibleMoves[random];
        }
    }
}
