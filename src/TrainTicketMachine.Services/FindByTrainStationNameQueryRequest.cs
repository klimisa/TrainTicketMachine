namespace TrainTicketMachine.Services;

using Domain;

public record FindByTrainStationNameQueryRequest
{
    public TrainStationName Name { get; }

    private FindByTrainStationNameQueryRequest(TrainStationName name)
        => Name = name;

    public static FindByTrainStationNameQueryRequest From(string name)
        => new FindByTrainStationNameQueryRequest(TrainStationName.From(name));
}
