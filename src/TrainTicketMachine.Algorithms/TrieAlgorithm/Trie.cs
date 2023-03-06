namespace TrainTicketMachine.Algorithms.TrieAlgorithm;

public class Trie
{
    private readonly TrieNode _root;

    public Trie()
    {
        _root = new TrieNode('^');
    }

    public void Insert(string word)
    {
        var currentNode = _root;
        foreach (var c in word)
        {
            if (!currentNode.Children.ContainsKey(c))
            {
                currentNode.Children.Add(c, new TrieNode(c));
                currentNode.NextCharacters.Add(c);
            }
            currentNode = currentNode.Children[c];
        }
        currentNode.IsEndOfWord = true;
    }

    public (IList<string>, IList<char>) Match(string prefix)
    {
        var result = new List<string>();
        var currentNode = _root;
        foreach (var c in prefix)
        {
            if (!currentNode.Children.ContainsKey(c))
            {
                return (result, new List<char>());
            }
            currentNode = currentNode.Children[c];
        }
        CollectWords(currentNode, prefix, result);
        return (result, currentNode.NextCharacters);
    }
    

    private static void CollectWords(TrieNode node, string prefix, ICollection<string> result)
    {
        if (node.IsEndOfWord)
        {
            result.Add(prefix);
        }
        foreach (var childNode in node.Children.Values)
        {
            CollectWords(childNode, prefix + childNode.Value, result);
        }
    }  
}