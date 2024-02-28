namespace PortaTestTaskApi.Calculate
{
    public class Calculation
    {
        public List<int> FindLongestIncreasingSequence(List<int> numbers)
        {
            List<int> currentSequence = new List<int>();
            List<int> longestSequence = new List<int>();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] < numbers[i + 1])
                {
                    currentSequence.Add(numbers[i]);
                }
                else
                {
                    currentSequence.Add(numbers[i]);

                    if (currentSequence.Count > longestSequence.Count)
                    {
                        longestSequence = new List<int>(currentSequence);
                    }

                    currentSequence.Clear();
                }
            }

            currentSequence.Add(numbers[numbers.Count - 1]);

            if (currentSequence.Count > longestSequence.Count)
            {
                longestSequence = new List<int>(currentSequence);
            }

            return longestSequence;
        }

        public List<int> FindLongestDecreasingSequence(List<int> numbers)
        {
            List<int> currentSequence = new List<int>();
            List<int> longestSequence = new List<int>();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    currentSequence.Add(numbers[i]);
                }
                else
                {
                    currentSequence.Add(numbers[i]);
                    if (currentSequence.Count > longestSequence.Count)
                    {
                        longestSequence = new List<int>(currentSequence);
                    }
                    currentSequence.Clear();
                }
            }

            currentSequence.Add(numbers.Last());
            if (currentSequence.Count > longestSequence.Count)
            {
                longestSequence = new List<int>(currentSequence);
            }

            return longestSequence;
        }
        public int CalculateMedian(List<int> numbers)
        {
            numbers.Sort();
            int middle = numbers.Count / 2;
            return (numbers.Count % 2 == 0) ? (numbers[middle - 1] + numbers[middle]) / 2 : numbers[middle];
        }
    }
}