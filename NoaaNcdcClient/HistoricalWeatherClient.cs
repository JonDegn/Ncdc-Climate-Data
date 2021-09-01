using Microsoft.Extensions.Logging;
using NoaaNcdcClient.Models;
using NoaaNcdcClient.Requests;
using System;
using System.Net.Http;
using System.Text.Json;

namespace NoaaNcdcClient
{
    public class HistoricalWeatherClient
    {
        private HttpClient HttpClient { get; }
        private JsonSerializerOptions SerializerOptions { get; }
        public ILogger<HistoricalWeatherClient> Logger { get; set; }

        private readonly string baseUrl = "https://www.ncdc.noaa.gov/cdo-web/api/v2/";

        public HistoricalWeatherClient(HttpClient httpClient, string token, string userAgent, ILogger<HistoricalWeatherClient> logger = null)
        {
           Logger = logger;

            HttpClient = httpClient;
            SerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            HttpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);
            HttpClient.DefaultRequestHeaders.Add("token", token);
        }

        private T CallApi<T>(string url)
        {
            Logger?.LogInformation($"Calling: {url}");

            var response = HttpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            var responseJson = response.Content.ReadAsStringAsync().Result;

            Logger?.LogInformation($"Response: {responseJson}");

            return JsonSerializer.Deserialize<T>(responseJson, SerializerOptions);
        }

        public ListResponse<Dataset> GetDatasets(DatasetsRequest request)
        {
            return CallApi<ListResponse<Dataset>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
        }

        public Dataset GetDataset(string datasetId)
        {
            return CallApi<Dataset>($"{baseUrl}datasets/{Uri.EscapeDataString(datasetId)}");
        }

        public ListResponse<DataCategory> GetDataCategories(DataCategoriesRequest request)
        {
            return CallApi<ListResponse<DataCategory>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
        }

        public DataCategory GetDataCategory(string dataCategoryId)
        {
            return CallApi<DataCategory>($"{baseUrl}datacategories/{Uri.EscapeDataString(dataCategoryId)}");
        }

        public ListResponse<DataType> GetDataTypes(DataTypesRequest request)
        {
            return CallApi<ListResponse<DataType>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
        }

        public DataType GetDataType(string dataTypeId)
        {
            return CallApi<DataType>($"{baseUrl}datatypes/{Uri.EscapeDataString(dataTypeId)}");
        }

        public ListResponse<LocationCategory> GetLocationCategories(LocationCategoriesRequest request)
        {
            return CallApi<ListResponse<LocationCategory>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
        }

        public LocationCategory GetLocationCategory(string locationCategoryId)
        {
            return CallApi<LocationCategory>($"{baseUrl}locationcategories/{Uri.EscapeDataString(locationCategoryId)}");
        }

        public ListResponse<Location> GetLocations(LocationsRequest request)
        {
            return CallApi<ListResponse<Location>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
        }

        public Location GetLocation(string locationId)
        {
            return CallApi<Location>($"{baseUrl}locations/{Uri.EscapeDataString(locationId)}");
        }

        public ListResponse<Station> GetStations(StationsRequest request)
        {
            return CallApi<ListResponse<Station>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
        }

        public Station GetStation(string stationId)
        {
            return CallApi<Station>($"{baseUrl}stations/{Uri.EscapeDataString(stationId)}");
        }

        public ListResponse<DataRow> GetData(DataRequest request)
        {
            return CallApi<ListResponse<DataRow>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
        }
    }
}
