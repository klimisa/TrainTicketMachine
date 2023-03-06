namespace TrainTicketMachine.Domain.Exceptions;

public class TrainStationNameIsEmptyException : Exception
{
    public TrainStationNameIsEmptyException(): base("Train station name cannot be empty")
    {
    }
}
