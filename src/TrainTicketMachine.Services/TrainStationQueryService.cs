namespace TrainTicketMachine.Services;

public class TrainStationQueryService : ITrainStationQueryService
{
    private readonly ITrainStationLookup trainStationLookup;

    public TrainStationQueryService(ITrainStationLookup trainStationLookup)
    {
        this.trainStationLookup = trainStationLookup;
    }

    public ByTrainStationNameQueryResponse Handle(FindByTrainStationNameQueryRequest request)
    {
        var lookupResult = trainStationLookup.LookFor(request.Name);
        return new ByTrainStationNameQueryResponse(
            request.Name.Value,
            lookupResult.Stations.ToArray(),
            lookupResult.NextChars.ToArray()
        );
    }


}
