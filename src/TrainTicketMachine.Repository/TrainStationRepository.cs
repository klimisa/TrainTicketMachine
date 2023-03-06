namespace TrainTicketMachine.Repository;

using Domain;

public class TrainStationRepository : ITrainStationRepository
{
    private IEnumerable<string> trainStations = new List<string>()
    {
        "DARTFORD",
        "DARTMOUTH",
        "TOWER HILL",
        "DERBY",
        "LIVERPOOL",
        "LIVERPOOL LIME STREET",
        "PADDINGTON",
        "EUSTON",
        "LONDON BRIDGE",
        "VICTORIA",
    };

    public Task<IEnumerable<TrainStation>> GetAll()
        => Task.FromResult(
            from s in trainStations
            select new TrainStation(s));
}
