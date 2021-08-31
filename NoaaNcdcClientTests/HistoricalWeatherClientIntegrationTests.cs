using NoaaNcdcClient;
using NUnit.Framework;
using NoaaNcdcClient.Models;
using System;
using Shouldly;
using Microsoft.Extensions.Configuration;

namespace NoaaNcdcClientTests
{
    public class HistoricalWeatherClientIntegrationTests
    {
        public IConfiguration Configuration { get; set; }

        [SetUp]
        public void Setup()
        {
            Configuration = new ConfigurationBuilder()
                .AddUserSecrets<HistoricalWeatherClientIntegrationTests>()
                .Build();
        }

        [Test]
        public void TestGetStation()
        {
            var stationId = "GHCND:US1NCAG0001";

            var client = new HistoricalWeatherClient(new System.Net.Http.HttpClient(), Configuration["NCDC:Token"], Configuration["NCDC:UserAgent"]);

            var response = client.GetStation(stationId);

            var expected = new Station
            {
                Elevation = 946.1,
                MinDate = DateTime.Parse("2007-09-01"),
                MaxDate = DateTime.Parse("2021-08-27"),
                Latitude = 36.458975,
                Name = "SPARTA 3.5 SSW, NC US",
                DataCoverage = 1,
                Id = "GHCND:US1NCAG0001",
                ElevationUnit = "METERS",
                Longitude = -81.152517
            };

            response.ShouldBeEquivalentTo(expected);
        }
    }
}