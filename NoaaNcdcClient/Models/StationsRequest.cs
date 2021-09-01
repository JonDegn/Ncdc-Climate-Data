namespace NoaaNcdcClient.Models
{
    public class StationsRequest : ApiRequest<StationsRequest>
    {
        public override string Endpoint { get; } = "stations";

        public StationsRequest WithDatasets(params string[] datasetIds)
        {
            SetArrayParam("datasetid", datasetIds);
            return this;
        }

        public StationsRequest WithLocations(params string[] locationIds)
        {
            SetArrayParam("locationid", locationIds);
            return this;
        }

        public StationsRequest WithDataCategories(params string[] dataCategoryIds)
        {
            SetArrayParam("datacategoryid", dataCategoryIds);
            return this;
        }

        public StationsRequest WithDataTypes(params string[] dataTypeIds)
        {
            SetArrayParam("datatypeid", dataTypeIds);
            return this;
        }

        public StationsRequest WithExtent(double lonMin, double latMin, double lonMax, double latMax)
        {
            SetParam("extent", $"{lonMin},{latMin},{lonMax},{latMax}");
            return this;
        }
    }
}
