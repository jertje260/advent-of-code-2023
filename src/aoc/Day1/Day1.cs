using System.Reflection;

public static class Day1
{
    private const string Numbers = "0123456789";
    private const string One = "one";
    private const string Two = "two";
    private const string Three = "three";
    private const string Four = "four";
    private const string Five = "five";
    private const string Six = "six";
    private const string Seven = "seven";
    private const string Eight = "eight";
    private const string Nine = "nine";

    private static readonly string[] _allNumbers = Numbers.Split(',').Concat(new []
        { One, Two, Three, Four, Five, Six, Seven, Eight, Nine }).ToArray();

    public static async Task<int> RunExamplePart1()
    {
        return await RunAsync(File.ReadLinesAsync("Day1\\example.txt"), ParseLinePart1);
    }

    public static async Task<int> RunExamplePart2()
    {
        return await RunAsync(File.ReadLinesAsync("Day1\\example2.txt"), ParseLinePart2);
    }

    public static async Task<int> RunCalibrationPart1()
    {
        return await RunAsync(File.ReadLinesAsync("Day1\\calibrationdocument.txt"), ParseLinePart1);
    }

    public static async Task<int> RunCalibrationPart2()
    {
        return await RunAsync(File.ReadLinesAsync("Day1\\calibrationdocument.txt"), ParseLinePart2);
    }


    private static async Task<int> RunAsync(IAsyncEnumerable<string> lines, Func<string, int> parseFunction)
    {
        var sum = 0;

        await foreach (var num in GetNumbersAsync(lines, parseFunction))
        {
            sum += num;
        }

        return sum;
    }

    private static async IAsyncEnumerable<int> GetNumbersAsync(IAsyncEnumerable<string> lines, Func<string, int> parseFunction)
    {
        await foreach (var line in lines)
        {
            yield return parseFunction.Invoke(line);
        }
    }

    private static int ParseLinePart1(string line)
    {
        char[] chars =
        {
            line.First(c => Numbers.Contains(c)),
            line.Last(c => Numbers.Contains(c))
        };

        return int.Parse(new string(chars));
    }

    public static int ParseLinePart2(string line)
    {
        char[] chars =
        {
            FirstNumberCharacter(line.AsSpan()),
            LastNumberCharacter(line.AsSpan())
            
        };

        return int.Parse(new string(chars));
    }

   

    public static char FirstNumberCharacter(ReadOnlySpan<char> input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (Numbers.Contains(input[i]))
            {
                return input[i];
            }

            var character = GetNumberOfText(input.Slice(i));
            if (character is not null)
            {
                return character.Value;
            }
        }

        throw new ArgumentException("input has not number");
    }

    public static char LastNumberCharacter(ReadOnlySpan<char> input)
    {
        for (int i = input.Length-1; i >= 0; i--)
        {
            if (Numbers.Contains(input[i]))
            {
                return input[i];
            }

            var character = GetNumberOfText(input.Slice(i));
            if (character is not null)
            {
                return character.Value;
            }
        }

        throw new ArgumentException("input has not number");
    }

    private static char? GetNumberOfText(ReadOnlySpan<char> input)
    {
        if (input.Length < 3)
        {
            return null;
        }

        if (input.Slice(0, 3).IsSimilarTo(One))
        {
            return '1';
        }
        if (input.Slice(0, 3).IsSimilarTo(Two))
        {
            return '2';
        }
        if (input.Slice(0, 3).IsSimilarTo(Six))
        {
            return '6';
        }

        if (input.Length == 3)
        {
            return null;
        }

        if (input.Slice(0, 4).IsSimilarTo(Four))
        {
            return '4';
        }

        if (input.Slice(0, 4).IsSimilarTo(Five))
        {
            return '5';
        }

        if (input.Slice(0, 4).IsSimilarTo(Nine))
        {
            return '9';
        }

        if (input.Length == 4)
        {
            return null;
        }

        if (input.Slice(0, 5).IsSimilarTo(Three))
        {
            return '3';
        }

        if (input.Slice(0, 5).IsSimilarTo(Seven))
        {
            return '7';
        }
        if (input.Slice(0, 5).IsSimilarTo(Eight))
        {
            return '8';
        }

        return null;
    }

    private static bool IsSimilarTo(this ReadOnlySpan<char> input1, ReadOnlySpan<char> input2)
    {
        if (input1.Length != input2.Length)
        {
            return false;
        }

        for (int i = 0; i < input1.Length; i++)
        {
            if (input1[i] != input2[i])
            {
                return false;
            }
        }
        return true;
    }

    //private char GetFromString(Span<char> input) => input switch
    //{
    //    One => '1',
    //    Two => '2',
    //    Three => '3',
    //    Four => '4',
    //    Five => '5',
    //    Six => '6',
    //    Seven => '7',
    //    Eight => '8',
    //    Nine => '9',
    //    _ => throw new NotImplementedException()
    //};
}