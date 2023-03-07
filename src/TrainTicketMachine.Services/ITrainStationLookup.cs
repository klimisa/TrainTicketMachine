namespace TrainTicketMachine.Services;

using Domain;

public interface ITrainStationLookup
{
    LookupResult LookFor(TrainStationName name);
    void Initialize(IEnumerable<TrainStation> trainStations);
}
