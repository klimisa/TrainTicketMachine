namespace TrainTicketMachine.Services;

using Domain;
using Algorithms.TrieAlgorithm;

public class TrainStationLookup : ITrainStationLookup
{
    private readonly Trie trie = new();

    public (IList<string> stations, IList<char> nextChars) LookFor(TrainStationName name)
        => trie.Match(name.Value);

    public void Initialize(IEnumerable<TrainStation> trainStations)
    {
        foreach (var trainStation in trainStations)
        {
            trie.Insert(trainStation.Name);
        }
    }
}
