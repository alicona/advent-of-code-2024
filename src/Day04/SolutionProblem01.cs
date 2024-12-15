namespace Day04
{
    public class SolutionProblem01
    {
        private int _totalCols;
        private int _totalRows;
        public int Calculate(char[][] input, string word) 
        {
            _totalRows = input.Length;
            _totalCols = input[0].Length;
            int totalfound = 0;

            for (int i = 0; i < _totalRows; i++)
            {
                for (int j = 0; j < _totalCols; j++)
                {
                    totalfound += WordsFound(input, i, j, word);
                }
            }

            return totalfound;
        }

        private int WordsFound(char[][] input, int col, int row, string word) 
        {
            // Dont continue if the first character doesnt match the word.
            if (input[row][col] != word[0])
                return 0;

            int wordLenght = word.Length;
            int wordsFoundAtPosition = 0;

            // We can move in these directions
            int[] x = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] y = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < 8; i++) // Look in the 8 directions possible.
            {
                // calculate the next position
                int nextCol = col + y[i];
                int nextRow = row + x[i];
                

                int index;

                for (index = 1; index < wordLenght; index++)
                {

                    // break if out of bounds
                    if (nextRow >= _totalRows || nextRow < 0 || nextCol >= _totalCols || nextCol < 0)
                        break;

                    // break if characters dont match
                    if (input[nextRow][nextCol] != word[index])
                        break;

                    // Moving in particular direction
                    nextRow += x[i];
                    nextCol += y[i];
                }

                // If all character matched, then value of must
                // be equal to length of word
                if (index == wordLenght) 
                {
                    wordsFoundAtPosition++;
                } 
            }

            // if word is not found in any direction,
            // then return false
            return wordsFoundAtPosition;
        }
    }
}
