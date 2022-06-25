/*
 * Purpur Tentakel
 * 25.06.2022
 * Test - Matrix
 */

using Helpers;

namespace Matrix
{
    internal class MatrixGame
    {
        private double[,] Ad = new double[,]
        {
            { 1.0, 2.0, 3.0 },
            { 4.0, 5.0, 6.0 },
            { 7.0, 8.0, 9.0 },
        };
        private double[,] Bd = new double[,]
        {
            { 1.0, 2.0, 3.0 },
            { 4.0, 5.0, 6.0 },
            { 7.0, 8.0, 9.0 },
        };
        public void Game()
        {
            while (true)
            {
                Console.Clear();
                Helper.PrintHeadline("Matrix");

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
            Matrix a = new Matrix(Ad);
            Console.WriteLine($"Matrix A:\n{a}");

            Matrix b = new Matrix(Bd);
            Console.WriteLine($"Matrix B:\n{b}");
            Console.WriteLine($"is A = B? {a.Equals(b)}");

            b.SetValue(2, 1, 42.0);
            Console.WriteLine($"Matrix B:\n{b}");
            Console.WriteLine($"is A = B? {a.Equals(b)}");

            Matrix c = a.Add(b);
            Console.WriteLine($"Resulr of A + B is \n{c}");
        }
    }
    internal class Matrix
    {
        private double[,] values;

        public Matrix(double[,] values)
        {
            this.values = values;
        }
        public Matrix(int numRows, int numColumns)
        {
            values = new double[numRows, numColumns];
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numColumns; col++)
                {
                    values[row, col] = 0.0;
                }
            }
        }
        public override string ToString()
        {
            //Console.WriteLine($"Test {x,10}");
            if (!HasAnyEntries())
            {
                return "No Entries";
            }

            string toReturn = "";
            int maxRow = GetNumRows();
            int maxCol = GetNumCols();
            int letterLength = GetLengthOfLongestValue();

            for (int row = 0; row < maxRow; ++row)
            {
                string line = values[row, 0].ToString().PadLeft(letterLength);
                for (int col = 1; col < maxCol; ++col)
                {
                    line += $", {values[row, col].ToString().PadLeft(letterLength)}";
                }
                line += "\n";
                toReturn += line;
            }
            return toReturn;
        }

        public int GetNumRows()
        {
            return values.GetLength(0);
        }
        public int GetNumCols()
        {
            return values.GetLength(1);
        }
        private int GetLengthOfLongestValue()
        {
            int maxLength = 0;
            int maxRow = GetNumRows();
            int maxCol = GetNumCols();
            for (int row = 0; row < maxRow; ++row)
            {
                for (int col = 0; col < maxCol; ++col)
                {
                    double value = values[row, col];
                    int valueLength = value.ToString().Length;
                    if (valueLength > maxLength)
                    {
                        maxLength = valueLength;
                    }
                }
            }
            return maxLength;

        }
        private bool HasRow()
        {
            return GetNumRows() != 0;
        }
        private bool HasCol()
        {
            return GetNumCols() != 0;
        }
        private bool HasAnyEntries()
        {
            return HasRow() && HasCol();
        }
        public double GetValue(int row, int column)
        {
            return values[row, column];
        }
        public void SetValue(int row, int column, double value)
        {
            values[row, column] = value;
        }

        private bool HasSameDimension(Matrix other)
        {
            bool equalRowCount = GetNumRows() == other.GetNumRows();
            bool equalColumnCount = GetNumCols() == other.GetNumCols();

            return equalRowCount && equalColumnCount;
        }
        public Matrix Add(Matrix other)
        {
            if (!HasSameDimension(other))
            {
                throw new InvalidOperationException("Different Dimensions");
            }

            int maxRow = GetNumRows();
            int maxCol = GetNumCols();

            Matrix toReturn = new Matrix(maxRow, maxCol);
            for (int row = 0; row < maxRow; ++row)
            {
                for (int col = 0; col < maxCol; ++col)
                {
                    double new_value = values[row, col] + other.GetValue(row, col);
                    toReturn.SetValue(row, col, new_value);
                }
            }

            return toReturn;
        }

        public override bool Equals(Object obj)
        {
            if (obj is not Matrix other)
            {
                return false;
            }

            if (!HasSameDimension(other))
            {
                return false;
            }

            int maxRow = GetNumRows();
            int maxCol = GetNumCols();

            for (int row = 0; row < maxRow; ++row)
            {
                for (int col = 0; col < maxCol; ++col)
                {
                    if (values[row, col] != other.GetValue(row, col))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
