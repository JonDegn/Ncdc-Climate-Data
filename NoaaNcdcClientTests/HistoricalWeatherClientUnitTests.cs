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
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/stations/*")
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/station.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

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

        [Test]
        public void TestGetStations()
        {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/stations")
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/stations.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var response = client.GetStations(new StationsRequest());

            var expected = new ListResponse<Station>
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
        public void TestGetDataset()
        {
            var mockHttp = new MockHttpMessageHandler();
            var datasetId = "GHCND";

            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/datasets/*")
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/dataset.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var response = client.GetDataset(datasetId);

            var expected = new Dataset
            {
                MinDate = new DateTime(1763, 01, 01),
                MaxDate = new DateTime(2021, 08, 29),
                Name = "Daily Summaries",
                DataCoverage = 1,
                Id = "GHCND"
            };

            response.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void TestGetDatasets()
        {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/datasets")
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/datasets.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var response = client.GetDatasets(new DatasetsRequest());

            var expected = new ListResponse<Dataset>
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
                Results = new List<Dataset>
                {
                     new Dataset
                     {
                        MinDate = new DateTime(1763, 01, 01),
                        MaxDate = new DateTime(2021, 08, 29),
                        Name = "Daily Summaries",
                        DataCoverage = 1,
                        Id = "GHCND"
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

            var expected = new ListResponse<DataRow>
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