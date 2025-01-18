namespace Matrix;

public interface IWordFinder
{
    IEnumerable<string> Find(IEnumerable<string> wordStream);
}