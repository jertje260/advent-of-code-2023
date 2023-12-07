namespace advent_of_code_2023.Day2
{
    public static class Day2
    {


        public static async Task<int> RunExamplePart1()
        {
            return await RunAsync(File.ReadLinesAsync("Day2\\example.txt"), PossibleGame);
        }

        public static async Task<int> RunPart1()
        {
            return await RunAsync(File.ReadLinesAsync("Day2\\inputs.txt"), PossibleGame);
        }

        public static async Task<int> RunExamplePart2()
        {
            return await RunAsync(File.ReadLinesAsync("Day2\\example.txt"), PowerOfGame);
        }

        public static async Task<int> RunPart2()
        {
            return await RunAsync(File.ReadLinesAsync("Day2\\inputs.txt"), PowerOfGame);
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

        //TODO improve to use readonly spans
        private static int PossibleGame(string arg)
        {
            // 12 red, 13 green, 14 blue
            var split = arg.Split(':');
            var gameNumber = split[0].Substring(4);

            var options = split[1].Split(';');


            foreach (var draw in options)
            {
                var cubes = draw.Split(", ").Select(c => c.Trim());

                foreach (var cubeSet in cubes)
                {
                    var set = cubeSet.Split(" ");
                    var amount = int.Parse(set[0]);

                    if (set[1] == "red" && amount > 12)
                    {
                        return 0;
                    }

                    if (set[1] == "green" && amount > 13)
                    {
                        return 0;
                    }
                    if (set[1] == "blue" && amount > 14)
                    {
                        return 0;
                    }
                }
            }

            // Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            // if possible return game number

            return int.Parse(gameNumber);
        }

        private static int PowerOfGame(string arg)
        {
            var split = arg.Split(':');

            var options = split[1].Split(';');

            var red = 0; 
            var green = 0; 
            var blue = 0;

            foreach (var draw in options)
            {
                var cubes = draw.Split(", ").Select(c => c.Trim());

                foreach (var cubeSet in cubes)
                {
                    var set = cubeSet.Split(" ");
                    var amount = int.Parse(set[0]);

                    if (set[1] == "red" && red < amount)
                    {
                        red = amount;
                    }

                    if (set[1] == "green" && green < amount)
                    {
                        green = amount;
                    }
                    if (set[1] == "blue" && blue < amount)
                    {
                        blue = amount;
                    }
                }
            }

            return red * blue * green;
        }


    }
}
