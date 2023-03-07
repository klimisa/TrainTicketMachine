# Train Ticket Machine

### Introduction  

The architecture of the app is based on port and adapters.

The ports are, 
- [ Outgoing ]`ITrainStationRepository` in TrainTicketMachine.Domain
- [ Incoming ] `ITrainStationQueryService` in TrainTicketMachine.Services

For logging [Serilog](https://serilog.net/) has been used.

### Project structure

There are two folders `src` where the functionality of the app exist and the
`tests` folder where the tests exists.

The structure is as follow:

#### TrainTicketMachine.WebApi
Everything is related to ASP.NET Core, here the minimal API is used to create
an HTTP api call for the search/find functionality. 

The API endpoint is: `api/v1/search?station=<station>` 

There is an [api.http](api.http) file where the GET request lives in order to test the app,
either by running the project or via docker. There are two environments ready 
to be used  for each case `development` and `docker`.

In the case you are testing with docker there is a [docker-compose.yaml](docker-compose.yaml)
file. Run `docker-compose up` in the root folder.

The docker-compose uses the [.Dockerfile](.Dockerfile) which prepares the docker
image. 
   
In this project also the dependency injection is happening using the DI of ASP.NET core
       
*Slow and unreliable connection*

In order to mitigate the problem of slow and unreliable conncetion the trie 
algorithm is feed with data on the application startup using the `TrainStationLookupInitializer` class
which implements the `IHostedService`.

#### TrainTicketMachine.Services
Here is the service layer which defines the application boundaries.

The `TrainStationQueryService` accepts in the constructor an `ITrainStationLookup`
and has a public method `Handle` which accepts an `FindByTrainStationNameQueryRequest`
and returns an `FindByTrainStationNameQueryResponse`.

The `TrainStationLookup` class is the lookup service which implements the `ITrainStationLookup`.
Here we have used the strategy pattern in order to isolate how the lookup will be 
built. In our case the trie algorithm has been chosen.

The `ITrainStationLookup`  has two methods:

1. LookupResult LookFor(string name)
2. void Initialize(IEnumerable<TrainStation> trainStations)

the first methods takes a name and returns a `LookupResult` and the second 
method `Initialize` is to initialize the trie when the app starts.
      
#### TrainTicketMachine.Domain
There is not really a true domain here, but just to give a bit of strictness 
in our app there is a `TrainStation` value object used in the repository `ITrainStationRepository`
which retrieves the train stations from whatever source we implement it with.
In our case the implementation is an in-memory and exists `TrainTicketMachine.Repository` project. 

The `TrainStationName` it's the other value object which has a validation rule for the name
of the train station and in the case of an empty name it throws an `TrainStationNameIsEmptyException`.
It used to protect the `FindByTrainStationNameQueryRequest` from receiving an empty name.

#### TrainTicketMachine.Repository
The implementation of the `ITrainStationRepository` is an in-memory list of train station names.

#### TrainTicketMachine.Algorithms
Here the implementation of the `Trie` algorithm. Special thanks to 
[ChatGPT](https://openai.com/) which created the algorithm.

### Testing
The test are under the `TrainTicketMachine.Tests` and the split into two, unit tests
and integration tests. For integration tests are using the `WebApplicationFactory` which 
is spinning up our app and test it end-to-end using our endpoint as our clients will be calling it. 
For the assertions the [Fluent Assertions](https://fluentassertions.com/) library has been used.

### IMPROVEMENTS
 - Add a mongodb to get the stations from
 - Populate mongo with data at app startup 
 - Use [FluentDocker](https://github.com/mariotoffia/FluentDocker) to spin up mongo containers for the integration tests.
 - Swagger
 - Load testing
