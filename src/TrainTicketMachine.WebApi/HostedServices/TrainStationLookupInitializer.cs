namespace TrainTicketMachine.WebApi.HostedServices;

using Domain;
using Serilog;
using Services;

public class TrainStationLookupInitializer: IHostedService
{
    private readonly IServiceProvider serviceProvider;

    public TrainStationLookupInitializer(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var repository = serviceProvider.GetRequiredService<ITrainStationRepository>();
        var trainStations = await repository.GetAll();
        
        var lookup = serviceProvider.GetRequiredService<ITrainStationLookup>();
        lookup.Initialize(trainStations);
        Log.Information("Train stations lookup initialized");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}