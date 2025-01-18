using FluentAssertions;
using Matrix.Algorithms.Search;
using Matrix.Tests.Unit.Algorithms.Search;

namespace Matrix.Tests.Unit;

public class WordFinderTests
{
    [Theory]
    [ClassData(typeof(SearchTestData))]
    public void Find_ShouldReturnCorrectResult(IEnumerable<string> matrix, 
                                               IEnumerable<string> words,
                                               IEnumerable<string> expectedResult)
    {
        // Arrange
        var searchAlgorithm = new DefaultTextSearch();
        var sut = new WordFinder(matrix, searchAlgorithm);
        
        // Act
        var result = sut.Find(words);
        
        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }
}