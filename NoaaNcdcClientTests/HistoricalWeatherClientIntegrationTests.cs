using NoaaNcdcClient;
using NUnit.Framework;
using NoaaNcdcClient.Models;
using System;
using Shouldly;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using NoaaNcdcClient.Requests;
using Microsoft.Extensions.Logging;

namespace NoaaNcdcClientTests
{
    public class HistoricalWeatherClientIntegrationTests
    {
        public IConfiguration Configuration { get; set; }
        public HistoricalWeatherClient Client { get; set; }

        [SetUp]
        public void Setup()
        {
            Configuration = new ConfigurationBuilder()
                .AddUserSecrets<HistoricalWeatherClientIntegrationTests>()
                .Build();
            var logger = LoggerFactory.Create(b => b.AddConsole()).CreateLogger<HistoricalWeatherClient>();
            Client = new HistoricalWeatherClient(new System.Net.Http.HttpClient(), Configuration["NCDC:Token"], Configuration["NCDC:UserAgent"], logger);
        }

        [Test]
        public void TestGetDataset()
        {
            var datasetId = "GHCND";

            var response = Client.GetDataset(datasetId);

            response.MinDate.ShouldBe(new DateTime(1763, 01, 01));
            response.MaxDate.ShouldBeGreaterThanOrEqualTo(new DateTime(2021, 08, 29));
            response.Name.ShouldBe("Daily Summaries");
            response.DataCoverage.ShouldBe(1);
            response.Id.ShouldBe(datasetId);
        }

        [Test]
        public void TestGetDatasets()
        {
            var response = Client.GetDatasets(new DatasetsRequest().WithDataTypes("TOBS"));

            var expectedMetadata = new Metadata
            {
                ResultSet = new ResultSet
                {
                    Offset = 1,
                    Count = 1,
                    Limit = 25
                }
            };

            response.Metadata.ShouldBeEquivalentTo(expectedMetadata);
            response.Results.Count.ShouldBe(1);
            response.Results[0].MinDate.ShouldBe(new DateTime(1763, 01, 01));
            response.Results[0].MaxDate.ShouldBeGreaterThanOrEqualTo(new DateTime(2021, 08, 29));
            response.Results[0].Name.ShouldBe("Daily Summaries");
            response.Results[0].DataCoverage.ShouldBe(1);
            response.Results[0].Id.ShouldBe("GHCND");
        }

        [Test]
        public void TestGetDataCategory()
        {
            var dataCategoryId = "ANNAGR";

            var response = Client.GetDataCategory(dataCategoryId);

            var expected = new DataCategory
            {
                Name = "Annual Agricultural",
                Id = dataCategoryId
            };

            response.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void TestGetDataCategories()
        {
            var response = Client.GetDataCategories(new DataCategoriesRequest().WithLimit(1));

            var expected = new ListResponse<DataCategory>
            {
                Metadata = new Metadata
                {
                    ResultSet = new ResultSet
                    {
                        Offset = 1,
                        Count = 42,
                        Limit = 1
                    }
                },
                Results = new List<DataCategory>
                {
                     new DataCategory
                     {
                        Name = "Annual Agricultural",
                        Id = "ANNAGR"
                     }
                }
            };

            response.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void TestGetDataType()
        {
            var dataTypeId = "ACMH";

            var response = Client.GetDataType(dataTypeId);

            var expected = new DataType
            {
                MinDate = new DateTime(1965, 01, 01),
                MaxDate = new DateTime(2005, 12, 31),
                DataCoverage = 1,
                Id = dataTypeId
            };

            response.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void TestGetDataTypes()
        {
            var response = Client.GetDataTypes(new DataTypesRequest().WithDataCategories("TEMP").WithLimit(1));

            var expectedMetadata = new Metadata
            {
                ResultSet = new ResultSet
                {
                    Offset = 1,
                    Count = 59,
                    Limit = 1
                }
            };

            response.Metadata.ShouldBeEquivalentTo(expectedMetadata);
            response.Results.Count.ShouldBe(1);
            response.Results[0].MinDate.ShouldBe(new DateTime(1763, 01, 01));
            response.Results[0].MaxDate.ShouldBeGreaterThanOrEqualTo(new DateTime(2021, 07, 01));
            response.Results[0].Name.ShouldBe("Cooling Degree Days Season to Date");
            response.Results[0].DataCoverage.ShouldBe(1);
            response.Results[0].Id.ShouldBe("CDSD");
        }

        [Test]
        public void TestGetLocationCategory()
        {
            var locationCategoryId = "CLIM_REG";

            var response = Client.GetLocationCategory(locationCategoryId);

            var expected = new LocationCategory
            {
                Name = "Climate Region",
                Id = locationCategoryId
            };

            response.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void TestGetLocationCategories()
        {
            var response = Client.GetLocationCategories(new LocationCategoriesRequest().WithLimit(1));

            var expected = new ListResponse<LocationCategory>
            {
                Metadata = new Metadata
                {
                    ResultSet = new ResultSet
                    {
                        Offset = 1,
                        Count = 12,
                        Limit = 1
                    }
                },
                Results = new List<LocationCategory>
                {
                     new LocationCategory
                     {
                        Name = "City",
                        Id = "CITY"
                     }
                }
            };

            response.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void TestGetLocation()
        {
            var locationId = "FIPS:37";

            var response = Client.GetLocation(locationId);

            response.MinDate.ShouldBe(new DateTime(1869, 03, 01));
            response.MaxDate.ShouldBeGreaterThanOrEqualTo(new DateTime(2021, 08, 29));
            response.Name.ShouldBe("North Carolina");
            response.DataCoverage.ShouldBe(1);
            response.Id.ShouldBe(locationId);
        }

        [Test]
        public void TestGetLocations()
        {
            string locationCategory = "ST";
            int limit = 1;
            var response = Client.GetLocations(new LocationsRequest().WithLocationCategories(locationCategory).WithLimit(limit));

            var expectedMetadata = new Metadata
            {
                ResultSet = new ResultSet
                {
                    Offset = 1,
                    Count = 51,
                    Limit = limit
                }
            };

            response.Metadata.ShouldBeEquivalentTo(expectedMetadata);
            response.Results.Count.ShouldBe(limit);
            response.Results[0].MinDate.ShouldBe(new DateTime(1888, 02, 01));
            response.Results[0].MaxDate.ShouldBeGreaterThanOrEqualTo(new DateTime(2021, 07, 01));
            response.Results[0].Name.ShouldBe("Alabama");
            response.Results[0].DataCoverage.ShouldBe(1);
            response.Results[0].Id.ShouldBe("FIPS:01");
        }

        [Test]
        public void TestGetStation()
        {
            var stationId = "GHCND:US1NCAG0001";

            var response = Client.GetStation(stationId);

            response.Elevation.ShouldBe(946.1);
            response.MinDate.ShouldBe(new DateTime(2007, 09, 01));
            response.MaxDate.ShouldBeGreaterThanOrEqualTo(new DateTime(2021, 08, 28));
            response.Latitude.ShouldBe(36.458975);
            response.Name.ShouldBe("SPARTA 3.5 SSW, NC US");
            response.DataCoverage.ShouldBe(1);
            response.Id.ShouldBe(stationId);
            response.ElevationUnit.ShouldBe("METERS");
            response.Longitude.ShouldBe(-81.152517);

        }

        [Test]
        public void TestGetStations()
        {
            var response = Client.GetStations(new StationsRequest().WithExtent(39.4344694, -111.2923622, 39.4666796, -111.2472153));

            var expectedMetadata = new Metadata
            {
                ResultSet = new ResultSet
                {
                    Offset = 1,
                    Count = 1,
                    Limit = 25
                }
            };

            response.Metadata.ShouldBeEquivalentTo(expectedMetadata);
            response.Results.Count.ShouldBe(1);
            response.Results[0].Elevation.ShouldBe(2745.9);
            response.Results[0].MinDate.ShouldBe(new DateTime(1978, 09, 30));
            response.Results[0].MaxDate.ShouldBeGreaterThanOrEqualTo(new DateTime(2021, 08, 28));
            response.Results[0].Latitude.ShouldBe(39.45);
            response.Results[0].Name.ShouldBe("RED PINE RIDGE, UT US");
            response.Results[0].DataCoverage.ShouldBe(0.9955);
            response.Results[0].Id.ShouldBe("GHCND:USS0011K28S");
            response.Results[0].ElevationUnit.ShouldBe("METERS");
            response.Results[0].Longitude.ShouldBe(-111.27);
        }

        [Test]
        public void TestGetData()
        {
            var dataRequest = new DataRequest()
                .WithDatasets("GHCND")
                .WithStartDate(new DateTime(1908, 5, 1))
                .WithEndDate(new DateTime(1908, 5, 2))
                .WithIncludeMetadata(false)
                .WithStations("GHCND:USC00425837")
                .WithLimit(1);

            var response = Client.GetData(dataRequest);

            var expected = new ListResponse<DataRow>
            {
                Results = new List<DataRow>
                {
                    new DataRow
                    {
                        Date = DateTime.Parse("1908-05-01T00:00:00"),
                        DataType = "PRCP",
                        Station = "GHCND:USC00425837",
                        Attributes = "P,,6,",
                        Value = 0
                    }
                }
            };

            response.ShouldBeEquivalentTo(expected);
        }
    }
}