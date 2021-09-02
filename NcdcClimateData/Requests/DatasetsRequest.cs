namespace JonDegn.ClimateData
{
    public class DatasetsRequest : ApiRequest<DatasetsRequest>
    {
        public override string Endpoint { get; } = "datasets";

        /// <summary>
        /// Optional. Accepts a valid data type id or a list of data type ids. Datasets returned will contain all of the data type(s) specified.
        /// </summary>
        /// <param name="dataTypeIds">The data types.</param>
        public DatasetsRequest WithDataTypes(params string[] dataTypeIds)
        {
            SetArrayParam(QueryParameters.DataType, dataTypeIds);
            return this;
        }

        /// <summary>
        /// Optional. Accepts a valid location id or a list of location ids. Datasets returned will contain data for the location(s) specified.
        /// </summary>
        /// <param name="locationIds">The location ids.</param>
        public DatasetsRequest WithLocations(params string[] locationIds)
        {
            SetArrayParam(QueryParameters.Location, locationIds);
            return this;
        }

        /// <summary>
        /// Optional. Accepts a valid station id or a list of station ids. Datasets returned will contain data for the station(s) specified.
        /// </summary>
        /// <param name="stationIds">The station ids.</param>
        public DatasetsRequest WithStations(params string[] stationIds)
        {
            SetArrayParam(QueryParameters.Station, stationIds);
            return this;
        }
    }
}
