namespace TrainTicketMachine.Services;

using Domain;
using Algorithms.TrieAlgorithm;

public class TrainStationLookup : ITrainStationLookup
{
    private readonly Trie trie = new();

    public LookupResult LookFor(TrainStationName name)
    {
        var (stations, nextChars) = trie.Match(name.Value);
        return new LookupResult(
            stations.ToArray(),
            nextChars.ToArray()
        );
    }

    public void Initialize(IEnumerable<TrainStation> trainStations)
    {
        foreach (var trainStation in trainStations)
        {
            trie.Insert(trainStation.Name);
        }
    }
}

public record LookupResult(string[] Stations, char[] NextChars);
