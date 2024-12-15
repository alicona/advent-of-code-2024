namespace Day04
{
    public class SolutionProblem02
    {
        private int _totalCols;
        private int _totalRows;
        public int Calculate(char[][] input, string word) 
        {
            _totalRows = input.Length;
            _totalCols = input[0].Length;
            int totalfound = 0;
            var count = 0;

            for (int i = 0; i < _totalRows; i++)
            {
                for (int j = 0; j < _totalCols; j++)
                {
                    if (input[i][j] == 'A') 
                    {
                        Console.Write($"A Found @ {i},{j} => ");
                        // first diagonal -1 -1
                        if ((WordsFound(input, j - 1, i - 1, "MAS", 1, 1) ||
                            WordsFound(input, j - 1, i - 1, "SAM", 1, 1)) &&
                            (WordsFound(input, j + 1, i - 1, "MAS", 1, -1) ||
                            WordsFound(input, j + 1, i - 1, "SAM", 1, -1)))
                        {
                            totalfound++;
                            Console.WriteLine("Y");
                        }
                        else { Console.WriteLine("N"); }
                    }
                }
            }

            return totalfound;
        }

        private bool WordsFound(char[][] input, int col, int row, string word, int dirx, int diry)
        {
            if (row >= _totalRows || row < 0 || col >= _totalCols || col < 0) return false;


            int nextCol = col;
            int nextRow = row;
            int wordLenght = word.Length;
            int index;

            for (index = 0; index < wordLenght; index++)
            {
                if (nextRow >= _totalRows || nextRow < 0 || nextCol >= _totalCols || nextCol < 0) break;
                if (input[nextRow][nextCol] != word[index])
                    break;

                nextRow += dirx;
                nextCol += diry;
                
            }

            if (index == wordLenght)
            {
                return true;
            }

            return false;
        }
    }
}
