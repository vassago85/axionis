using AxionisPos.Api.Services;
using Xunit;

namespace AxionisPos.Api.Tests;

public class ImportNumberParsingTests
{
    [Theory]
    [InlineData("9000", 9000)]
    [InlineData("R 9,000.00", 9000)]
    [InlineData("r9000", 9000)]
    [InlineData("R\u00a09\u00a0000.50", 9000.50)]
    [InlineData("1 234.56", 1234.56)]
    [InlineData("", 0)]
    [InlineData("  ", 0)]
    public void ParseAmount_parses_currency_and_spaces(string input, decimal expected)
    {
        Assert.Equal(expected, ImportNumberParsing.ParseAmount(input, 0));
    }

    [Fact]
    public void ParseAmount_bad_returns_fallback()
    {
        Assert.Equal(-1m, ImportNumberParsing.ParseAmount("not-a-number", -1m));
    }
}
