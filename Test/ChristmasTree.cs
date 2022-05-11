namespace Tree
{
    internal class ChristmasTree
    {
        byte height;

        public ChristmasTree(byte height)
        {
            this.height = height;
        }

        public void Print()
        {
            int leaves = 1;
            for (int i = 0; i < height - 1; i++)
            {
                for (int j = i; j < height - 2; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 0; k < leaves; k++)
                {
                    Console.Write("*");
                }
                leaves += 2;
                Console.WriteLine();
            }
            for (int i = 0; i < height / 10 + 1; i++)
            {
                for (int j = 0; j < height - 2; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }


        }
    }
}
