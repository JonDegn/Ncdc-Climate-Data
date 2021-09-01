using NoaaNcdcClient;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using System.IO;
using NoaaNcdcClient.Models;
using System;
using System.Collections.Generic;
using Shouldly;
using NoaaNcdcClient.Requests;

namespace NoaaNcdcClientTests
{
    public class HistoricalWeatherClientUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetDataset()
        {
            var mockHttp = new MockHttpMessageHandler();
            var datasetId = "GHCND";

            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/datasets/{Uri.EscapeDataString(datasetId)}")
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
            var dataType = "TOBS";
            var mockHttp = new MockHttpMessageHandler();
            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/datasets")
                .WithQueryString(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(QueryParameters.DataType, dataType)
                })
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/datasets.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var response = client.GetDatasets(new DatasetsRequest().WithDataTypes(dataType));

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
        public void TestGetDataCategory()
        {
            var mockHttp = new MockHttpMessageHandler();
            var dataCategoryId = "ANNAGR";

            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/datacategories/{Uri.EscapeDataString(dataCategoryId)}")
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/datacategory.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var response = client.GetDataCategory(dataCategoryId);

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
            var limit = 1;
            var mockHttp = new MockHttpMessageHandler();
            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/datacategories")
                .WithQueryString(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(QueryParameters.Limit, limit.ToString())
                })
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/datacategories.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var response = client.GetDataCategories(new DataCategoriesRequest().WithLimit(limit));

            var expected = new ListResponse<DataCategory>
            {
                Metadata = new Metadata
                {
                    ResultSet = new ResultSet
                    {
                        Offset = 1,
                        Count = 42,
                        Limit = limit
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
            var mockHttp = new MockHttpMessageHandler();
            var dataTypeId = "ACMH";

            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/datatypes/{Uri.EscapeDataString(dataTypeId)}")
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/datatype.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var response = client.GetDataType(dataTypeId);

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
            var dataCategory = "TEMP";
            var limit = 1;
            var mockHttp = new MockHttpMessageHandler();
            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/datatypes")
                .WithQueryString(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(QueryParameters.DataCategory, dataCategory),
                    new KeyValuePair<string, string>(QueryParameters.Limit, limit.ToString())
                })
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/datatypes.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var response = client.GetDataTypes(new DataTypesRequest().WithDataCategories(dataCategory).WithLimit(limit));

            var expected = new ListResponse<DataType>
            {
                Metadata = new Metadata
                {
                    ResultSet = new ResultSet
                    {
                        Offset = 1,
                        Count = 59,
                        Limit = limit
                    }
                },
                Results = new List<DataType>
                {
                     new DataType
                     {
                        MinDate = new DateTime(1763, 01, 01),
                        MaxDate = new DateTime(2021, 07, 01),
                        Name = "Cooling Degree Days Season to Date",
                        DataCoverage = 1,
                        Id = "CDSD"
                     }
                }
            };

            response.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void TestGetLocationCategory()
        {
            var mockHttp = new MockHttpMessageHandler();
            var locationCategoryId = "CLIM_REG";

            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/locationcategories/{Uri.EscapeDataString(locationCategoryId)}")
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/locationcategory.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var response = client.GetLocationCategory(locationCategoryId);

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
            var limit = 1;
            var mockHttp = new MockHttpMessageHandler();
            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/locationcategories")
                .WithQueryString(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(QueryParameters.Limit, limit.ToString())
                })
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/locationcategories.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var response = client.GetLocationCategories(new LocationCategoriesRequest().WithLimit(limit));

            var expected = new ListResponse<LocationCategory>
            {
                Metadata = new Metadata
                {
                    ResultSet = new ResultSet
                    {
                        Offset = 1,
                        Count = 12,
                        Limit = limit
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
            var mockHttp = new MockHttpMessageHandler();
            var locationId = "FIPS:37";

            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/locations/{Uri.EscapeDataString(locationId)}")
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/location.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var response = client.GetLocation(locationId);

            var expected = new Location
            {
                MinDate = new DateTime(1869, 03, 01),
                MaxDate = new DateTime(2021, 08, 30),
                Name= "North Carolina",
                DataCoverage = 1,
                Id = locationId
            };

            response.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void TestGetLocations()
        {
            string locationCategory = "ST";
            int limit = 1;
            var mockHttp = new MockHttpMessageHandler();
            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/locations")
                .WithQueryString(new List<KeyValuePair<string,string>> 
                { 
                    new KeyValuePair<string, string>(QueryParameters.LocationCategory, locationCategory), 
                    new KeyValuePair<string, string>(QueryParameters.Limit, limit.ToString()) 
                })
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/locations.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var response = client.GetLocations(new LocationsRequest().WithLocationCategories(locationCategory).WithLimit(limit));

            var expected = new ListResponse<Location>
            {
                Metadata = new Metadata
                {
                    ResultSet = new ResultSet
                    {
                        Offset = 1,
                        Count = 51,
                        Limit = 1
                    }
                },
                Results = new List<Location>
                {
                     new Location
                     {
                        MinDate = new DateTime(1888, 02, 01),
                        MaxDate = new DateTime(2021, 08, 30),
                        Name = "Alabama",
                        DataCoverage = 1,
                        Id = "FIPS:01"
                     }
                }
            };

            response.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void TestGetStation()
        {
            var mockHttp = new MockHttpMessageHandler();
            var stationId = "GHCND:US1NCAG0001";

            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/stations/{Uri.EscapeDataString(stationId)}")
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
                Id = stationId,
                ElevationUnit = "METERS",
                Longitude = -81.152517
            };

            response.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void TestGetStations()
        {
            var extent = "39.4344694,-111.2923622,39.4666796,-111.2472153";
            var mockHttp = new MockHttpMessageHandler();
            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/stations")
                .WithQueryString(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(QueryParameters.Extent, extent)
                })
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/stations.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var response = client.GetStations(new StationsRequest().WithExtent(39.4344694, -111.2923622, 39.4666796, -111.2472153));

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
                        Elevation= 2745.9,
                        MinDate= new DateTime(1978, 09, 30),
                        MaxDate= new DateTime(2021, 08, 28),
                        Latitude= 39.45,
                        Name= "RED PINE RIDGE, UT US",
                        DataCoverage= 0.9955,
                        Id= "GHCND:USS0011K28S",
                        ElevationUnit= "METERS",
                        Longitude= -111.27
                    }
                }
            };

            response.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void TestGetData()
        {
            var dataset = "GHND";
            var includeMetadata = false;
            var station = "GHCND:USC00425837";
            var limit = 1;
            var mockHttp = new MockHttpMessageHandler();
            mockHttp
                .When($"https://www.ncdc.noaa.gov/cdo-web/api/v2/data")
                .WithQueryString(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(QueryParameters.Dataset, dataset),
                    new KeyValuePair<string, string>(QueryParameters.StartDate, "1908-05-01"),
                    new KeyValuePair<string, string>(QueryParameters.EndDate, "1908-05-02"),
                    new KeyValuePair<string, string>(QueryParameters.IncludeMetadata, includeMetadata.ToString()),
                    new KeyValuePair<string, string>(QueryParameters.Station, station),
                    new KeyValuePair<string, string>(QueryParameters.Limit, limit.ToString())
                })
                .Respond("application/geo+json", File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/data.json")));

            var client = new HistoricalWeatherClient(mockHttp.ToHttpClient(), "token", "user-agent");

            var dataRequest = new DataRequest()
                .WithDatasets(dataset)
                .WithStartDate(new DateTime(1908, 5, 1))
                .WithEndDate(new DateTime(1908, 5, 2))
                .WithIncludeMetadata(includeMetadata)
                .WithStations(station)
                .WithLimit(limit);

            var response = client.GetData(dataRequest);

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