using System.Text.RegularExpressions;

namespace Day03
{
    public class SolutionProblem02
    {
        public long Calculate(string input)
        {
            long total = 0;
            string doRegex = "do\\(\\)";
            string dontRegex = "don't\\(\\)";

            var matchDo = Regex.Matches(input, doRegex).ToList();
            var matchDont = Regex.Matches(input, dontRegex).ToList();

            var queue = new PriorityQueue<(string, int), int>();

            // Populate queues
            foreach (var m in matchDo)
            {
                var index = m.Index;
                queue.Enqueue(("do", index), index);
            }

            foreach (var m in matchDont)
            {
                var index = m.Index;
                queue.Enqueue(("dont", index), index);
            }

            // sum from the beggining up to the first find of do or dont
            var first  = queue.Peek();
            total += Parser.Parse(input.Substring(0, first.Item2));

            // Take one element from the queue and check if it is a DO, then sum up to the next element in the queue
            while (queue.Count > 1) 
            {
                var start = queue.Dequeue();

                if (start.Item1 == "do") 
                {
                    var finish = queue.Peek();
                    var substring = input.Substring(start.Item2, finish.Item2 - start.Item2);
                    total += Parser.Parse(substring);
                }
            }

            // Remove the last element in the queue
            var last = queue.Dequeue();
            if (last.Item1 == "do") 
            {
                total += Parser.Parse(input.Substring(last.Item2));
            }

            return total;
        }
    }
}
