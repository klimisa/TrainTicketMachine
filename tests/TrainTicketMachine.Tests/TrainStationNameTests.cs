namespace TrainTicketMachine.Tests;

using Domain;
using Domain.Exceptions;
using FluentAssertions;
using Services;
using Xunit;

public class TrainStationNameTests
{
    [Fact]
    public void When_name_is_valid__Should_return_correctly()
    {
        var name = "LIV";
        var request = FindByTrainStationNameQueryRequest.From(name);
        request.Name.Should().Be(TrainStationName.From(name));
    }

    [Fact]
    public void When_name_is_empty__Should_return_error()
    {
        var name = string.Empty;
        Action act = () => FindByTrainStationNameQueryRequest.From(name);
        act.Should().Throw<TrainStationNameIsEmptyException>()
            .WithMessage("Train station name cannot be empty");
    }
}
