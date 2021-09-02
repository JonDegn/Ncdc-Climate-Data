namespace JonDegn.ClimateData
{
    public class DataCategoriesRequest : ApiRequest<DataCategoriesRequest>
    {
        public override string Endpoint { get; } = "datacategories";

        /// <summary>
        /// Optional. Accepts a valid dataset id or a list of dataset ids. Data categories returned will be supported by dataset(s) specified.
        /// </summary>
        /// <param name="datasetIds">The dataset ids.</param>
        public DataCategoriesRequest WithDatasets(params string[] datasetIds)
        {
            SetArrayParam(QueryParameters.Dataset, datasetIds);
            return this;
        }

        /// <summary>
        /// Optional. Accepts a valid location id or a list of location ids. Data categories returned will contain data for the location(s) specified.
        /// </summary>
        /// <param name="locationIds">The location ids.</param>
        public DataCategoriesRequest WithLocations(params string[] locationIds)
        {
            SetArrayParam(QueryParameters.Location, locationIds);
            return this;
        }

        /// <summary>
        /// Optional. Accepts a valid station id or a list of station ids. Data categories returned will contain data for the station(s) specified.
        /// </summary>
        /// <param name="stationIds">The station ids.</param>
        public DataCategoriesRequest WithStations(params string[] stationIds)
        {
            SetArrayParam(QueryParameters.Station, stationIds);
            return this;
        }
    }
}
