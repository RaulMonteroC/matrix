namespace Matrix.Algorithms.Search;

public class DefaultTextSearch : ITextSearch
{
    public bool Search(string text, string word) => text.Contains(word);
}