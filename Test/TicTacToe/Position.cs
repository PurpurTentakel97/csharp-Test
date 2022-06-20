/*
 * Purpur Tentakel
 * 20.06.2022
 * Test - TicTacToe - Position
 */

namespace Test.TicTacToe
{
    internal class Position
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
