using NoaaNcdcClient;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using System.IO;
using NoaaNcdcClient.Models;
using System;
using System.Collections.Generic;
using Shouldly;

namespace NoaaNcdcClientTests
{
    public class HistoricalWeatherClientUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetStation()
        {
            var mockHttp = new MockHttpMessageHandler();
            var stationId = "GHCND:US1NCAG0001";

            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/station/*")
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/station.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var response = client.GetStation(stationId);

            var expected = new Station
            {
                Elevation = 946.1,
                MinDate = DateTime.Parse("2007-09-08"),
                MaxDate = DateTime.Parse("2021-08-27"),
                Latitude = 36.458975,
                Name = "SPARTA 3.5 SSW, NC US",
                DataCoverage = 0.9763,
                Id = "GHCND:US1NCAG0001",
                ElevationUnit = "METERS",
                Longitude = -81.152517
            };

            response.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void TestGetStations()
        {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/stations")
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/stations.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var response = client.GetStations(new StationsRequest());

            var expected = new StationsResponse
            {
                Metadata = new Metadata
                {
                    ResultSet = new ResultSet
                    {
                        Offset = 1,
                        Count = 1,
                        Limit = 25
                    }
                },
                Results = new List<Station>
                {
                    new Station
                    {
                        Elevation= 946.1,
                        MinDate= DateTime.Parse("2007-09-08"),
                        MaxDate= DateTime.Parse("2021-08-27"),
                        Latitude= 36.458975,
                        Name= "SPARTA 3.5 SSW, NC US",
                        DataCoverage= 0.9763,
                        Id= "GHCND:US1NCAG0001",
                        ElevationUnit= "METERS",
                        Longitude= -81.152517
                    }
                }
            };

            response.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void TestGetData()
        {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/data")
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/data.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var response = client.GetData(new DataRequest());

            var expected = new DataResponse
            {
                Metadata = new Metadata
                {
                    ResultSet = new ResultSet
                    {
                        Offset = 1,
                        Count = 2,
                        Limit = 25
                    }
                },
                Results = new List<DataRow>
                {
                    new DataRow
                    {
                        Date = DateTime.Parse("2020-01-01T00:00:00"),
                        DataType = "PRCP",
                        Station = "GHCND:US1NCAG0001",
                        Attributes = ",,N,",
                        Value = 10
                    }
                }
            };

            response.ShouldBeEquivalentTo(expected);
        }
    }
}