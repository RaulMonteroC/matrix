using System.Collections.Concurrent;
using Matrix.Algorithms.Search;

namespace Matrix;

public sealed class WordFinder(IEnumerable<string> matrix,
                               ITextSearchAlgorithm? textSearch = null)
    : IWordFinder
{
    private readonly ConcurrentDictionary<string, int> _foundWords = new();
    private readonly ITextSearchAlgorithm _searchAlgorithm = textSearch ?? new DefaultTextSearch();

    private const int NUMBER_OF_WORDS_TO_RETURN = 10;

    public IEnumerable<string> Find(IEnumerable<string> wordStream)
    {
        var wordLength = matrix.ElementAt(0).Length;
        var wordsToSearch = wordStream.ToArray();
        var matrixArray = matrix.ToArray();
        
        Task.WaitAll(DispatchHorizontalSearch(wordsToSearch, matrixArray),
                     DispatchVerticalSearch(wordsToSearch, wordLength, matrixArray));

        return _foundWords.OrderBy(x => x.Value)
                          .Select(x => x.Key);
    }

    private Task DispatchHorizontalSearch(string[] wordStream, string[] matrixArray)
    {
        var tasks = new List<Task>();
        
        foreach (var text in matrixArray)
        {
            tasks.Add(Task.Run(() => ExecuteSearch(text, wordStream)));
        }
        
        return Task.WhenAll(tasks);
    }
    
    private Task DispatchVerticalSearch(string[] wordStream, int wordLength, string[] matrixArray)
    {
        var tasks = new List<Task>();
        
        for (int i = 0; i < wordLength; i++)
        {
            var text = string.Concat(matrixArray.Select(x => x[i]));
            tasks.Add(Task.Run(() => ExecuteSearch(text, wordStream)));
        }
        
        return Task.WhenAll(tasks);
    }
    
    private void ExecuteSearch(string text, IEnumerable<string> wordStream)
    {
        Parallel.ForEach(wordStream, word =>
        {
            if (_foundWords.Count <= NUMBER_OF_WORDS_TO_RETURN && _searchAlgorithm.Search(text, word))
            {
                if (!_foundWords.TryAdd(word, 1))
                {
                    _foundWords[word]++;
                }
            }
        });
    }
}