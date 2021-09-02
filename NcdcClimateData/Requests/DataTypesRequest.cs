namespace JonDegn.ClimateData
{
    public class DataTypesRequest : ApiRequest<DataTypesRequest>
    {
        public override string Endpoint { get; } = "datatypes";

        /// <summary>
        /// Optional. Accepts a valid dataset id or a list of dataset ids. Data types returned will be supported by dataset(s) specified.
        /// </summary>
        /// <param name="datasetIds">The dataset ids.</param>
        public DataTypesRequest WithDatasets(params string[] datasetIds)
        {
            SetArrayParam(QueryParameters.Dataset, datasetIds);
            return this;
        }

        /// <summary>
        /// Optional. Accepts a valid location id or a list of location ids. Data types returned will be applicable for the location(s) specified.
        /// </summary>
        /// <param name="locationIds">The location ids.</param>
        public DataTypesRequest WithLocations(params string[] locationIds)
        {
            SetArrayParam(QueryParameters.Location, locationIds);
            return this;
        }

        /// <summary>
        /// Optional. Accepts a valid station id or a list of station ids. Data types returned will be applicable for the station(s) specified.
        /// </summary>
        /// <param name="stationIds">The station ids.</param>
        public DataTypesRequest WithStations(params string[] stationIds)
        {
            SetArrayParam(QueryParameters.Station, stationIds);
            return this;
        }

        /// <summary>
        /// Optional. Accepts a valid data category id or a list of data category ids (although it is rare to have a data type with more than one data category). Data types returned will be associated with the data category(ies) specified.
        /// </summary>
        /// <param name="dataCategoryIds">The data categories.</param>
        public DataTypesRequest WithDataCategories(params string[] dataCategoryIds)
        {
            SetArrayParam(QueryParameters.DataCategory, dataCategoryIds);
            return this;
        }
    }
}
