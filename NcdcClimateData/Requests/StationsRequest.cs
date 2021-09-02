namespace JonDegn.ClimateData
{
    public class StationsRequest : ApiRequest<StationsRequest>
    {
        public override string Endpoint { get; } = "stations";

        /// <summary>
        /// Optional. Accepts a valid dataset id or a list of dataset ids. Stations returned will be supported by dataset(s) specified.
        /// </summary>
        /// <param name="datasetIds">The dataset ids.</param>
        public StationsRequest WithDatasets(params string[] datasetIds)
        {
            SetArrayParam(QueryParameters.Dataset, datasetIds);
            return this;
        }

        /// <summary>
        ///  	Optional. Accepts a valid location id or a list of location ids. Stations returned will contain data for the location(s) specified.
        /// </summary>
        /// <param name="locationIds">The location ids.</param>
        public StationsRequest WithLocations(params string[] locationIds)
        {
            SetArrayParam(QueryParameters.Location, locationIds);
            return this;
        }

        /// <summary>
        /// Optional. Accepts a valid data category id or a list of data category ids. Stations returned will be associated with the data category(ies) specified.
        /// </summary>
        /// <param name="dataCategoryIds">The data categories.</param>
        /// <returns></returns>
        public StationsRequest WithDataCategories(params string[] dataCategoryIds)
        {
            SetArrayParam(QueryParameters.DataCategory, dataCategoryIds);
            return this;
        }

        /// <summary>
        /// Optional. Accepts a valid data type id or a list of data type ids. Stations returned will contain all of the data type(s) specified.
        /// </summary>
        /// <param name="dataTypeIds">The data types.</param>
        /// <returns></returns>
        public StationsRequest WithDataTypes(params string[] dataTypeIds)
        {
            SetArrayParam(QueryParameters.DataType, dataTypeIds);
            return this;
        }

        /// <summary>
        /// Optional. The desired geographical extent for search. Stations returned must be located within the extent specified.
        /// </summary>
        /// <param name="minLongitude">The minimum longitude.</param>
        /// <param name="minLatitude">The minimum latitude.</param>
        /// <param name="maxLongitude">The maximum longitude.</param>
        /// <param name="maxLatitude">The maximum latitude.</param>
        /// <returns></returns>
        public StationsRequest WithExtent(double minLongitude, double minLatitude, double maxLongitude, double maxLatitude)
        {
            SetParam(QueryParameters.Extent, $"{minLongitude},{minLatitude},{maxLongitude},{maxLatitude}");
            return this;
        }
    }
}
