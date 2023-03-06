namespace TrainTicketMachine.Services;

public interface ITrainStationQueryService
{
    ByTrainStationNameQueryResponse Handle(FindByTrainStationNameQueryRequest query);
}
