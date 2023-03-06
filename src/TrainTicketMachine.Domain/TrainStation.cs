namespace TrainTicketMachine.Domain;

using Exceptions;

public readonly record struct TrainStation
{
    public string Name { get; }

    // Use only to rehydrate state
    public TrainStation(string name)
    {
        Name = name;
    }

    public static TrainStation From(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new TrainStationNameIsEmptyException();

        return new TrainStation(name.ToUpper());
    }
};
