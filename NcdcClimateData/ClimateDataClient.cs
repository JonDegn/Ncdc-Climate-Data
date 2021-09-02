using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;

namespace JonDegn.ClimateData
{
    public class ClimateDataClient
    {
        private HttpClient HttpClient { get; }
        private JsonSerializerOptions SerializerOptions { get; }
        public ILogger<ClimateDataClient> Logger { get; set; }

        private readonly string baseUrl = "https://www.ncdc.noaa.gov/cdo-web/api/v2/";

        /// <summary>
        /// Client for accessing NCDC Climate Data Online (CDO) info.
        /// See <see href="https://www.ncdc.noaa.gov/cdo-web/webservices/v2#gettingStarted"/>.
        /// </summary>
        /// <param name="httpClient">The instance of HttpClient to use.</param>
        /// <param name="token">Your access token.</param>
        /// <param name="userAgent">The user-agent string to use.</param>
        /// <param name="logger">The logger to use.</param>
        public ClimateDataClient(HttpClient httpClient, string token, string userAgent, ILogger<ClimateDataClient> logger = null)
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

        /// <summary>
        /// Fetches a list of available datasets.
        /// See <see href="https://www.ncdc.noaa.gov/cdo-web/webservices/v2#datasets"/>.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>A list of datasets.</returns>
        public ListResponse<Dataset> GetDatasets(DatasetsRequest request)
        {
            return CallApi<ListResponse<Dataset>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
        }

        /// <summary>
        /// Fetches information about a specific dataset.
        /// See <see href="https://www.ncdc.noaa.gov/cdo-web/webservices/v2#datasets"/>.
        /// </summary>
        /// <param name="datasetId">The id of the dataset.</param>
        /// <returns>The dataset info.</returns>
        public Dataset GetDataset(string datasetId)
        {
            return CallApi<Dataset>($"{baseUrl}datasets/{Uri.EscapeDataString(datasetId)}");
        }

        /// <summary>
        /// Fetches a list of available data categories.
        /// See <see href="https://www.ncdc.noaa.gov/cdo-web/webservices/v2#dataCategories"/>.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>A list of data categories.</returns>
        public ListResponse<DataCategory> GetDataCategories(DataCategoriesRequest request)
        {
            return CallApi<ListResponse<DataCategory>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
        }

        /// <summary>
        /// Fetches information about a specific data category.
        /// See <see href="https://www.ncdc.noaa.gov/cdo-web/webservices/v2#dataCategories"/>.
        /// </summary>
        /// <param name="dataCategoryId">The id of the data category.</param>
        /// <returns>The data category info.</returns>
        public DataCategory GetDataCategory(string dataCategoryId)
        {
            return CallApi<DataCategory>($"{baseUrl}datacategories/{Uri.EscapeDataString(dataCategoryId)}");
        }

        /// <summary>
        /// Fetches a list of available data types.
        /// See <see href="https://www.ncdc.noaa.gov/cdo-web/webservices/v2#dataTypes"/>.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>A list of data types.</returns>
        public ListResponse<DataType> GetDataTypes(DataTypesRequest request)
        {
            return CallApi<ListResponse<DataType>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
        }

        /// <summary>
        /// Fetches information about a specific data type.
        /// See <see href="https://www.ncdc.noaa.gov/cdo-web/webservices/v2#dataTypes"/>.
        /// </summary>
        /// <param name="dataTypeId">The id of the data type.</param>
        /// <returns>The data type info.</returns>
        public DataType GetDataType(string dataTypeId)
        {
            return CallApi<DataType>($"{baseUrl}datatypes/{Uri.EscapeDataString(dataTypeId)}");
        }

        /// <summary>
        /// Fetches a list of available location categories.
        /// See <see href="https://www.ncdc.noaa.gov/cdo-web/webservices/v2#locationCategories"/>.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>A list of location categories.</returns>
        public ListResponse<LocationCategory> GetLocationCategories(LocationCategoriesRequest request)
        {
            return CallApi<ListResponse<LocationCategory>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
        }

        /// <summary>
        /// Fetches information about a specific location category.
        /// See <see href="https://www.ncdc.noaa.gov/cdo-web/webservices/v2#locationCategories"/>.
        /// </summary>
        /// <param name="locationCategoryId">The id of the location category.</param>
        /// <returns>The location category info.</returns>
        public LocationCategory GetLocationCategory(string locationCategoryId)
        {
            return CallApi<LocationCategory>($"{baseUrl}locationcategories/{Uri.EscapeDataString(locationCategoryId)}");
        }

        /// <summary>
        /// Fetches a list of available locations.
        /// See <see href="https://www.ncdc.noaa.gov/cdo-web/webservices/v2#locations"/>.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>A list of locations.</returns>
        public ListResponse<Location> GetLocations(LocationsRequest request)
        {
            return CallApi<ListResponse<Location>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
        }

        /// <summary>
        /// Fetches information about a specific location.
        /// See <see href="https://www.ncdc.noaa.gov/cdo-web/webservices/v2#locations"/>.
        /// </summary>
        /// <param name="locationId">The id of the location.</param>
        /// <returns>The location info.</returns>
        public Location GetLocation(string locationId)
        {
            return CallApi<Location>($"{baseUrl}locations/{Uri.EscapeDataString(locationId)}");
        }

        /// <summary>
        /// Fetches a list of available stations.
        /// See <see href="https://www.ncdc.noaa.gov/cdo-web/webservices/v2#stations"/>.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>A list of stations.</returns>
        public ListResponse<Station> GetStations(StationsRequest request)
        {
            return CallApi<ListResponse<Station>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
        }

        /// <summary>
        /// Fetches information about a specific station.
        /// See <see href="https://www.ncdc.noaa.gov/cdo-web/webservices/v2#stations"/>.
        /// </summary>
        /// <param name="stationId">The id of the station.</param>
        /// <returns>The station info.</returns>
        public Station GetStation(string stationId)
        {
            return CallApi<Station>($"{baseUrl}stations/{Uri.EscapeDataString(stationId)}");
        }

        /// <summary>
        /// Fetches data from a dataset.
        /// See <see href="https://www.ncdc.noaa.gov/cdo-web/webservices/v2#data"/>.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>The data.</returns>
        public ListResponse<DataRow> GetData(DataRequest request)
        {
            return CallApi<ListResponse<DataRow>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
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
    }
}
