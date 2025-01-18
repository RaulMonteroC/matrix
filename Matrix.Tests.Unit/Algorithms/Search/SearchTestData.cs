using System.Collections;

namespace Matrix.Tests.Unit.Algorithms.Search;

public class SearchTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        // Small horizontal search finds one word
        yield return
        [
            new[]
            {
                "iKtestSEMx",
                "qwsBkHevBt"
            },
            new[] { "test" },
            new[] { "test" }
        ];
        
        // Small vertical search finds one word
        yield return
        [
            new[]
            {
                "twsBkHevBt",
                "eooSxcydfK",
                "sGloPNLLhT",
                "tEtRnqvGlU",

            },
            new[] { "test" },
            new[] { "test" }
        ];
        
        // Small vertical search for a word that doesn't exists
        yield return
        [
            new[]
            {
                "twsBkHevBt",
                "eooSxcydfK",
                "sGloPNLLhT",
                "VEtRnqvGlU"
            },
            new[] { "test" },
            Enumerable.Empty<string>()
        ];
        
        // Repeated word display only once
        yield return
        [
            new[]
            {
                "twsBkHevBt",
                "eooSTeStfK",
                "sGloPNLLhT",
                "VEtRnqvGlU"
            },
            new[] { "test" },
            new[] { "test" },
        ];
        
        // Words are returned in order of occurence
        yield return
        [
            new[]
            {
                "twsBkHevOt",
                "eooSTeStNT",
                "sGOneNLLEw",
                "VEtRnqvGlo",
                "onebvvLnXO",
            },
            new[] { "test", "one", "two" },
            new[] { "one", "test", "two" },
        ];
        
        // All scenarios with bigger dataset
        yield return
        [
            new[]
            {
                "iktesOsemx",
                "qwsbkNevbt",
                "hoosxEydfk",
                "ONEopnTWOt",
                "vetrnqvglu",
                "gcxOvvlnxo",
                "bxxNosopcc",
                "dtkEedTtar",
                "bbmTHREEej",
                "dqcqniOqxt"
            },
            new[] { "three", "one", "two" },
            new[] { "one", "two", "three" },
            
            // ONE 3
            // TWO 2
            // THREE 1
        ];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private readonly IEnumerable<string> _crossword =
    [
        "iKtestSEMx",
        "qwsBkHevBt",
        "hooSxcydfK",
        "oGloPNLLhT",
        "VEtRnqvGlU",
        "GcXbvvLnXO",
        "bxxsosopCC",
        "DTkGEDlTAr",
        "BBMKgNOQEj",
        "dqcQNidQXT"
    ];
}