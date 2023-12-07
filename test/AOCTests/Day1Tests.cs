using FluentAssertions;

namespace AOCTests
{
    public class Day1Tests
    {
        [Fact]
        public async Task Day1ExampleShouldBe142()
        {
            var result = await Day1.RunExamplePart1();

            result.Should().Be(142);
        }

        [Fact]
        public async Task Day1ExamplePart2ShouldBe281()
        {
            var result = await Day1.RunExamplePart2();

            result.Should().Be(281);
        }

        [Theory]
        [InlineData("one", '1')]
        [InlineData("two", '2')]
        [InlineData("three", '3')]
        [InlineData("four", '4')]
        [InlineData("five", '5')]
        [InlineData("six", '6')]
        [InlineData("seven", '7')]
        [InlineData("eight", '8')]
        [InlineData("nine", '9')]
        [InlineData("t1", '1')]
        [InlineData("teight", '8')]
        public void FirstNumberCharacterTests(string input, char expectation)
        {
            Day1.FirstNumberCharacter(input).Should().Be(expectation);
        }

        [Theory]
        [InlineData("one2", '2')]
        [InlineData("two", '2')]
        [InlineData("three", '3')]
        [InlineData("four", '4')]
        [InlineData("five", '5')]
        [InlineData("six", '6')]
        [InlineData("seven", '7')]
        [InlineData("eight", '8')]
        [InlineData("nine", '9')]
        [InlineData("t1", '1')]
        [InlineData("123teight", '8')]
        [InlineData("teight93210", '0')]
        public void LastNumberCharacterTests(string input, char expectation)
        {
            Day1.LastNumberCharacter(input).Should().Be(expectation);
        }

        [Theory]
        [InlineData("two1nine", 29)]
        [InlineData("eightwothree", 83)]
        [InlineData("abcone2threexyz", 13)]
        [InlineData("xtwone3four", 24)]
        [InlineData("4nineeightseven2",42)]
        [InlineData("zoneight234", 14)]
        [InlineData("7pqrstsixteen", 76)]
        public void FullLineTest(string input, int expectation)
        {
            Day1.ParseLinePart2(input).Should().Be(expectation);
        }
    }
}