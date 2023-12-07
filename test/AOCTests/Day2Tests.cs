using advent_of_code_2023.Day2;
using FluentAssertions;

namespace AOCTests
{
    public class Day2Tests
    {
        [Fact]
        public async Task ExampleDayTwo_Part1_ShouldBe8()
        {
            var result = await Day2.RunExamplePart1();
            result.Should().Be(8);
        }

        [Fact]
        public async Task ExampleDayTwo_Part2_ShouldBe2286()
        {
            var result = await Day2.RunExamplePart2();
            result.Should().Be(2286);
        }

    }
}
