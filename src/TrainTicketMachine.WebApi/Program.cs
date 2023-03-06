using Serilog;
using TrainTicketMachine.Domain;
using TrainTicketMachine.Repository;
using TrainTicketMachine.Services;
using TrainTicketMachine.WebApi;
using TrainTicketMachine.WebApi.HostedServices;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

var services = builder.Services;

services
    .AddSingleton<ITrainStationRepository, TrainStationRepository>()
    .AddSingleton<ITrainStationLookup, TrainStationLookup>()
    .AddSingleton<ITrainStationQueryService, TrainStationQueryService>()
    .AddHostedService<TrainStationLookupInitializer>();

var app = builder.Build();

// TODO: Catch error and return error code for invalid input
app.MapGroup("api/v1")
    .MapEndpointsV1()
    .WithTags("Public");

app.Run();

public partial class Program
{
}