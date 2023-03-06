namespace TrainTicketMachine.Tests;

using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class TrainStationWebApiTests
{
    private readonly HttpClient httpClient;

    public TrainStationWebApiTests()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        httpClient = webAppFactory.CreateDefaultClient();
    }

    [Fact]
    public async Task When_calling_search_api_with_valid_data__Returns_Correctly()
    {
        var result = await httpClient.GetStringAsync("api/v1/search?station=LIVERPOOL");
        var expected =
            "{\"query\":\"LIVERPOOL\",\"stations\":[\"LIVERPOOL\",\"LIVERPOOL LIME STREET\"],\"nextChars\":[\" \"]}";
        result.Should().Be(expected);
    }

    [Fact]
    public async Task When_calling_search_api_with_no_name__Returns_BadRequest()
    {
        var name = string.Empty;
        var result = await httpClient.GetAsync($"api/v1/search?station={name}");
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var content = await result.Content.ReadAsStringAsync();
        content.Should().Be($"\"Train station name cannot be empty\"");
    }
}
