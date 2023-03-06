namespace TrainTicketMachine.WebApi;

using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Services;

public static class EndpointsV1
{
    public static RouteGroupBuilder MapEndpointsV1(this RouteGroupBuilder group)
    {
        group.MapGet("/search", FindByTrainStationName);
        return group;
    }

    private static Task<IResult> FindByTrainStationName
    (
        [FromQuery] string station,
        ITrainStationQueryService service
    )
    {
        try
        {
            return Task.FromResult<IResult>(
                TypedResults.Ok(service.Handle(FindByTrainStationNameQueryRequest.From(station))));
        }
        catch (TrainStationNameIsEmptyException e)
        {
            return Task.FromResult<IResult>(TypedResults.BadRequest(e.Message));
        }
        catch (Exception e)
        {
            Log.Error(e, "Unhandled error");
            throw;
        }
    }
}
