string? line;
List<int> numbersList = new List<int>();
StreamReader sr;

try
{
    using (sr = new StreamReader("Resources/10m.txt"))
    {
        while ((line = sr.ReadLine()) != null)
        {
            if (int.TryParse(line, out int number))
            {
                numbersList.Add(number);
            }
            else
            {
                Console.WriteLine($"Invalid number format: {line}");
            }
        }
    }

    int maxNumber = FindMax(numbersList);
    Console.WriteLine($"Maximum number in the file: {maxNumber}");

    int minNumber = FindMin(numbersList);
    Console.WriteLine($"Minimum number in the file: {minNumber}");

    double average = CalculateAverage(numbersList);
    Console.WriteLine($"Average of the file: {average}");

    List<int> longestIncreasingSequence = FindLongestSequence(numbersList, true);
    Console.WriteLine("Longest increasing sequence: " + string.Join(", ", longestIncreasingSequence));

    List<int> longestDecreasingSequence = FindLongestSequence(numbersList, false);
    Console.WriteLine("Longest decreasing sequence: " + string.Join(", ", longestDecreasingSequence));

    double median = CalculateMedian(numbersList);
    Console.WriteLine($"Median of the file: {median}");
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}

static int FindMax(List<int>numbersList)
{
    return numbersList.Max();
}

static int FindMin(List<int> numbersList)
{
    return numbersList.Min();
}

static double CalculateMedian(List<int> numbersList)
{
    numbersList.Sort();
    int middleIndex = numbersList.Count / 2;
    double median;

    if (numbersList.Count % 2 == 0)
    {
        median = (numbersList[middleIndex - 1] + numbersList[middleIndex]) / 2.0;
    }
    else
    {
        median = numbersList[middleIndex];
    }

    return median;
}

static double CalculateAverage(List<int> numbersList)
{
    int sum = 0;
    for (int i = 0; i < numbersList.Count; i++)
    {
        sum += numbersList[i];
    }
    double average = (double)sum / numbersList.Count;

    return average;
}

static List<int> FindLongestSequence(List<int> numbersList, bool isIncrease)
{
    int longestLength = 1;
    int currentLength = 1;
    int startIndexOfLongest = 0;
    int startIndexOfCurrent = 0;

    for (int i = 1; i < numbersList.Count; i++)
    {
        if ((isIncrease && numbersList[i] > numbersList[i - 1]) || (!isIncrease && numbersList[i] < numbersList[i - 1]))
        {
            currentLength++;
            if (currentLength > longestLength)
            {
                longestLength = currentLength;
                startIndexOfLongest = startIndexOfCurrent;
            }
        }
        else
        {
            currentLength = 1;
            startIndexOfCurrent = i;
        }
    }

    return numbersList.GetRange(startIndexOfLongest, longestLength);
}