using System.Text;

while (true)
{
    Console.WriteLine("\nEnter the number: ");
    string? input = Console.ReadLine();
    bool parsed = int.TryParse(input, out int inputNumber);

    if (parsed)
    {
        Console.WriteLine(CalculateIfPrimeMultipliersSequence(inputNumber));
    }
    else
    {
        Console.WriteLine("Input is not a number. Please try again.");
    }
}

string CalculateIfPrimeMultipliersSequence(int inputNumber)
{
    if (inputNumber <= 1)
    {
        return "You entered the number that is less than or equals to 1. Please, enter the whole number that exceeds value 1";
    }

    StringBuilder stringBuilder = new StringBuilder($"Response - Yes, ");
    int startPrimeNumber = GetStartPrimeNumber(inputNumber);
    stringBuilder.Append(startPrimeNumber);

    int remainder = inputNumber / startPrimeNumber;
    int nextPrimeNumber = GetNextPrimeNumber(startPrimeNumber);

    if (remainder == 1)
    {
        return "Response - No";
    }

    while (remainder > 1)
    {
        if (remainder % nextPrimeNumber == 0)
        {
            stringBuilder.Append("*" + nextPrimeNumber);
            remainder /= nextPrimeNumber;
            nextPrimeNumber = GetNextPrimeNumber(nextPrimeNumber);
        }
        else
        {
            return "Response - No";
        }
    }

    return stringBuilder.ToString();
}

int GetNextPrimeNumber(int number)
{
    while (true)
    {
        bool isPrime = true;
        number++;
        int squareRoot = (int)Math.Sqrt(number);

        for (int i = 2; i <= squareRoot; i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        if (isPrime)
        {
            return number;
        }
    }
}

int GetStartPrimeNumber(int inputNumber)
{
    int divider = 2;

    while (true)
    {
        if (inputNumber % divider == 0)
        {
            return divider;
        }

        divider++;
    }
}