namespace Admixer.TestTask
{
    internal class ThreeInRow
    {
        private int[,] matrix;
        private readonly int n;
        private readonly int m;

        private readonly int minCountToDelete = 3;
        private readonly int minNumberInMatrix = 0;
        private readonly int maxNumberInMatrix = 3;

        public ThreeInRow(int n, int m)
        {
            matrix = new int[n, m];
            this.n = n;
            this.m = m;

            InitMatrix();
        }

        public void OutputMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void LogMatrix(string filePath)
        {
            using (StreamWriter file = new(filePath))
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        file.Write(matrix[i, j] + " ");
                    }
                    file.WriteLine();
                }
            }
        }

        public void DeleteSameNumber()
        {
            bool isSame = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int count = CountSameNumber(i, j, true);
                    if (count != -1)
                    {
                        DeleteSameNumberInRow(i, j, count);
                        isSame = true;
                    }

                    count = CountSameNumber(i, j, false);
                    if (count != -1)
                    {
                        DeleteSameNumberInCol(i, j, count);
                        isSame = true;
                    }
                }
            }

            if (isSame)
                DeleteSameNumber();
        }

        private int CountSameNumber(int x, int y, bool isHorizon)
        {
            int number = matrix[x, y];
            int count = 0;

            while (x < n && y < m && number == matrix[x, y])
            {
                _ = (isHorizon) ? y++ : x++;
                count++;
            }

            return (count >= minCountToDelete)? count : -1;
        }

        private void DeleteSameNumberInRow(int x, int y, int count)
        {
            Random rnd = new Random();

            for (int j = y; j < y+ count -1; j++)
            {
                for (int i = x; i > 0; i--)
                {
                    matrix[i, j] = matrix[i - 1, j];
                }
                matrix[0, j] = rnd.Next(minNumberInMatrix, maxNumberInMatrix);
            }
        }

        private void DeleteSameNumberInCol(int x, int y, int count)
        {
            Random rnd = new Random();

            for (int i = x + count - 1; i >= 0; i--)
            {
                if(i > count - 1)
                    matrix[i, y] = matrix[i - count, y];
                else
                    matrix[i, y] = rnd.Next(minNumberInMatrix, maxNumberInMatrix);
            }
        }  

        private void InitMatrix()
        {
            var rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rnd.Next(minNumberInMatrix, maxNumberInMatrix);
                }
            }
        }
    }
}
