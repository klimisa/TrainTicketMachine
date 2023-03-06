namespace TrainTicketMachine.Domain;

public interface ITrainStationRepository
{
    Task<IEnumerable<TrainStation>> GetAll();
}