namespace TrainTicketMachine.Domain;

using Exceptions;

public readonly record struct TrainStationName
{
    public string Value { get; }

    private TrainStationName(string value)
    {
        Value = value;
    }

    public static TrainStationName From(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new TrainStationNameIsEmptyException();

        return new TrainStationName(name.ToUpper());
    }
};
