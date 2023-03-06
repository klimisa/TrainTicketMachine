namespace TrainTicketMachine.Services;

public record ByTrainStationNameQueryResponse(string Query, string[] Stations, char[] NextChars);