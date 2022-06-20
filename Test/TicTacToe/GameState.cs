/*
 * Purpur Tentakel
 * 20.06.2022
 * Test - TicTacToe - GameState
 */

namespace Test.TicTacToe
{
    enum Marker
    {
        X,
        O,
        Empty,
    }

    internal class GameState
    {
        private int dimension;
        public int Dimension
        {
            get
            {
                return dimension;
            }
            private set
            {
                if (1 < value && value < 10)
                {
                    dimension = value;
                    return;
                }
                dimension = 3;
            }
        }

        private Marker[,] fields;
        public Marker CurrentPlayer { get; private set; }

        public GameState(int dimension)
        {
            this.Dimension = dimension;
            fields = new Marker[dimension, dimension];

            for (int line = 0; line < dimension; line++)
            {
                for (int column = 0; column < dimension; column++)
                {
                    fields[line, column] = Marker.Empty;
                }
            }

            CurrentPlayer = Marker.X;
        }
        public GameState GetCopy()
        {
            var newState = new GameState(Dimension);
            newState.CurrentPlayer = CurrentPlayer;

            for (int line = 0; line < Dimension; line++)
            {
                for (int column = 0; column < Dimension; column++)
                {
                    newState.fields[line, column] = fields[line, column];
                }
            }

            return newState;
        }

        public override string ToString()
        {
            string msgHeadline = "  ";
            string msgLine = "  ";
            string msg = "";
            for (int line = 0; line < Dimension; line++)
            {
                msgHeadline += (line + 1).ToString();
                msgLine += "-";
                msg += $"{line + 1}|";

                for (int column = 0; column < Dimension; column++)
                {
                    msg += GameState.MarkerToChar(fields[line, column]);
                }
                msg += "\n";
            }
            string msgReturn = $"{msgHeadline}\n{msgLine}\n{msg}";
            return msgReturn;
        }
        public static char MarkerToChar(Marker marker)
        {
            switch (marker)
            {
                case Marker.X:
                    return 'X';
                case Marker.O:
                    return 'O';
                case Marker.Empty:
                default:
                    return ' ';
            }
        }

        public static Marker GetOtherPlayer(Marker player)
        {
            if (player == Marker.X)
            {
                return Marker.O;
            }

            return Marker.X;
        }
        public void SwitchPlayers()
        {
            if (CurrentPlayer == Marker.X)
            {
                CurrentPlayer = Marker.O;
                return;
            }

            CurrentPlayer = Marker.X;
        }

        public bool HasAnyEmptyFields()
        {
            for (int line = 0; line < Dimension; line++)
            {
                for (int column = 0; column < Dimension; column++)
                {
                    if (fields[line, column] == Marker.Empty)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public bool IsFieldEmpty(Position position)
        {
            return IsFieldEmpty(position.Row, position.Column);
        }
        public bool IsFieldEmpty(int row, int column)
        {
            Marker field = fields[row, column];

            return field == Marker.Empty;
        }
        public void SetField(Position position)
        {
            SetField(position, CurrentPlayer);
        }
        public void SetField(Position position, Marker player)
        {
            fields[position.Row, position.Column] = player;
        }

        public bool HasPlayerWon(Marker marker)
        {
            bool won =
                HasEqualLine(marker) ||
                HasEqualColumn(marker) ||
                HasEqualDiagonal(marker);

            return won;
        }
        private bool HasEqualLine(Marker marker)
        {
            for (int line = 0; line < Dimension; line++)
            {
                bool equal = true;
                for (int column = 0; column < Dimension; column++)
                {
                    if (fields[line, column] != marker)
                    {
                        equal = false;
                        break;
                    }
                }
                if (equal)
                {
                    return true;
                }
            }

            return false;
        }
        private bool HasEqualColumn(Marker marker)
        {
            for (int column = 0; column < Dimension; column++)
            {
                bool isEqual = true;
                for (int line = 0; line < Dimension; line++)
                {
                    if (fields[line, column] != marker)
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual)
                {
                    return true;
                }
            }
            return false;
        }
        private bool HasEqualDiagonal(Marker marker)
        {
            bool isEqualIncreasing = true;
            bool isEqualDecreasing = true;
            bool isEqual = true;
            for (int i = 0; i < Dimension; i++)
            {
                if (fields[i, i] != marker)
                {
                    isEqualIncreasing = false;
                }

                if (fields[Dimension - i - 1, i] != marker)
                {
                    isEqualDecreasing = false;
                }
                isEqual = isEqualIncreasing || isEqualDecreasing;
                if (!isEqual)
                {
                    break;
                }
            }
            return isEqual;
        }


    }
}

