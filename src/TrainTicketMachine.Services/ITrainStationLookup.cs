namespace TrainTicketMachine.Services;

using Domain;

public interface ITrainStationLookup
{
    (IList<string> stations, IList<char> nextChars) LookFor(TrainStationName name);
    void Initialize(IEnumerable<TrainStation> trainStations);
}
