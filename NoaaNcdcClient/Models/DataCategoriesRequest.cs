namespace NoaaNcdcClient.Models
{
    public class DataCategoriesRequest : ApiRequest<DataCategoriesRequest>
    {
        public override string Endpoint { get; } = "datacategories";

        public DataCategoriesRequest WithDatasets(params string[] datasetIds)
        {
            SetArrayParam("datasetid", datasetIds);
            return this;
        }

        public DataCategoriesRequest WithLocations(params string[] locationIds)
        {
            SetArrayParam("locationid", locationIds);
            return this;
        }

        public DataCategoriesRequest WithStations(params string[] stationIds)
        {
            SetArrayParam("stationid", stationIds);
            return this;
        }
    }
}
