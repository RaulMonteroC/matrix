using FluentAssertions;
using Matrix.Algorithms.Search;

namespace Matrix.Tests.Unit.Algorithms.Search;

public class DefaultTextSearchTests
{
    private const string SEARCH_STRING = "asdasdTestasdasdassahaw8rgilsdfOneaasdasd1fmshwurtonqteend";

    [Theory]
    [InlineData(SEARCH_STRING, "Test", true)]
    [InlineData(SEARCH_STRING, "test", true)]
    [InlineData(SEARCH_STRING, "One", true)]
    [InlineData(SEARCH_STRING, "one", true)]
    [InlineData(SEARCH_STRING, "end", true)]
    [InlineData(SEARCH_STRING, "End", true)]
    public void Search_ShouldReturnExpectedResult(string text, string word, bool expectedResult)
    {
        // Arrange
        var sut = new DefaultTextSearch();

        // Act
        var result = sut.Search(text, word);

        // Assert
        result.Should().Be(expectedResult);
    }
}