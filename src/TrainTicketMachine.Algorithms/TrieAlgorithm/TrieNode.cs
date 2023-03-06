namespace TrainTicketMachine.Algorithms.TrieAlgorithm;

public class TrieNode
{
    public char Value { get; set; }
    public bool IsEndOfWord { get; set; }
    public IDictionary<char, TrieNode> Children { get; set; }
    
    public IList<char> NextCharacters { get; set; }

    public TrieNode(char value)
    {
        Value = value;
        IsEndOfWord = false;
        Children = new Dictionary<char, TrieNode>();
        NextCharacters = new List<char>();
    }
}