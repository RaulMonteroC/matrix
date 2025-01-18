namespace Matrix.Algorithms.Search;

public class DefaultTextSearch : ITextSearchAlgorithm
{
    public bool Search(string text, string word) => 
        text.Contains(word, StringComparison.OrdinalIgnoreCase);
}