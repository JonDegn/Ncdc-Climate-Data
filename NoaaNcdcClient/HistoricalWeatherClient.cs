using NoaaNcdcClient.Models;
using System;
using System.Net.Http;
using System.Text.Json;

namespace NoaaNcdcClient
{
    public class HistoricalWeatherClient
    {
        private HttpClient HttpClient { get; }
        private JsonSerializerOptions SerializerOptions { get; }

        private readonly string baseUrl = "https://www.ncdc.noaa.gov/cdo-web/api/v2/";

        public HistoricalWeatherClient(HttpClient httpClient, string token, string userAgent)
        {
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
            var response = HttpClient.GetAsync(url).Result;

            response.EnsureSuccessStatusCode();

            var responseJson = response.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<T>(responseJson, SerializerOptions);
        }

        public ListResponse<DataRow> GetData(DataRequest request)
        {
            return CallApi<ListResponse<DataRow>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
        }

        public ListResponse<Station> GetStations(StationsRequest request)
        {
            return CallApi<ListResponse<Station>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
        }

        public Station GetStation(string stationId)
        {
            return CallApi<Station>($"{baseUrl}stations/{Uri.EscapeDataString(stationId)}");
        }

        public ListResponse<Dataset> GetDatasets(DatasetsRequest request)
        {
            return CallApi<ListResponse<Dataset>>($"{baseUrl}{request.Endpoint}{request.GetQuery()}");
        }

        public Dataset GetDataset(string datasetId)
        {
            return CallApi<Dataset>($"{baseUrl}datasets/{Uri.EscapeDataString(datasetId)}");
        }


    }
}
