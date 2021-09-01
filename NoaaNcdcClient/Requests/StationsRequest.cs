namespace NoaaNcdcClient.Requests
{
    public class StationsRequest : ApiRequest<StationsRequest>
    {
        public override string Endpoint { get; } = "stations";

        public StationsRequest WithDatasets(params string[] datasetIds)
        {
            SetArrayParam(QueryParameters.Dataset, datasetIds);
            return this;
        }

        public StationsRequest WithLocations(params string[] locationIds)
        {
            SetArrayParam(QueryParameters.Location, locationIds);
            return this;
        }

        public StationsRequest WithDataCategories(params string[] dataCategoryIds)
        {
            SetArrayParam(QueryParameters.DataCategory, dataCategoryIds);
            return this;
        }

        public StationsRequest WithDataTypes(params string[] dataTypeIds)
        {
            SetArrayParam(QueryParameters.DataType, dataTypeIds);
            return this;
        }

        public StationsRequest WithExtent(double lonMin, double latMin, double lonMax, double latMax)
        {
            SetParam(QueryParameters.Extent, $"{lonMin},{latMin},{lonMax},{latMax}");
            return this;
        }
    }
}
