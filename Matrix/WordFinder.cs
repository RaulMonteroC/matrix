using Matrix.Algorithms.Search;

namespace Matrix;

public sealed class WordFinder(IEnumerable<string> matrix,
                               ITextSearch? textSearch = null)
    : IWordFinder
{
    private readonly Dictionary<string, int> _foundWords = new();
    private readonly ITextSearch _textSearch = textSearch ?? new DefaultTextSearch();
    
    private const int NUMBER_OF_WORDS_TO_RETURN = 10;

    public IEnumerable<string> Find(IEnumerable<string> wordStream)
    {
        var tasks = new List<Task>();
        
        foreach (var text in matrix)
        {
            tasks.Add(Task.Run(() => FindWord(text, wordStream)));
        }
        
        Task.WaitAll(tasks.ToArray());
        
        return _foundWords.OrderBy(x => x.Value)
                          .Take(NUMBER_OF_WORDS_TO_RETURN)
                          .Select(x => x.Key);
    }

    private void FindWord(string text, IEnumerable<string> words)
    {
        foreach (var word in words)
        {
            if (_textSearch.Search( text, word))
            {
                _foundWords[word]++;
            }
        }
    }
}