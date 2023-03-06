namespace TrainTicketMachine.Tests;

using Domain;
using FluentAssertions;
using Services;
using Xunit;

public class TrainStationQueryServiceTests
{
    [Theory]
    [MemberData(nameof(TestData.Data), MemberType = typeof(TestData))]
    public void Given_train_stations__When_lookup_by_name__Then_should_return_correctly
    (
        TrainStation[] trainStations,
        string query,
        ByTrainStationNameQueryResponse expected
    )
    {
        // ARRANGE
        var lookup = new TrainStationLookup();
        lookup.Initialize(trainStations);
        var service = new TrainStationQueryService(lookup);
        var request = FindByTrainStationNameQueryRequest.From(query);

        // ACT
        var actual = service.Handle(request);

        // ASSERT
        actual.Should().BeEquivalentTo(expected);
    }
}

public class TestData
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                new[]
                {
                    TrainStation.From("DARTFORD"),
                    TrainStation.From("DARTMOUTH"),
                    TrainStation.From("TOWER HILL"),
                    TrainStation.From("DERBY")
                },
                "DART",
                new ByTrainStationNameQueryResponse("DART", new[] { "DARTFORD", "DARTMOUTH" }, new[] { 'F', 'M' })
            },
            new object[]
            {
                new[]
                {
                    TrainStation.From("LIVERPOOL"),
                    TrainStation.From("LIVERPOOL LIME STREET"),
                    TrainStation.From("PADDINGTON")
                },
                "LIVERPOOL",
                new ByTrainStationNameQueryResponse("LIVERPOOL", new[] { "LIVERPOOL", "LIVERPOOL LIME STREET" },
                    new[] { ' ' })
            },
            new object[]
            {
                new[]
                {
                    TrainStation.From("EUSTON"),
                    TrainStation.From("LONDON BRIDGE"),
                    TrainStation.From("VICTORIA")
                },
                "KINGS CROSS",
                new ByTrainStationNameQueryResponse("KINGS CROSS", Array.Empty<string>(), Array.Empty<char>())
            },
        };
}
