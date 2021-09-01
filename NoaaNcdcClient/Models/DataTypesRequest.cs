namespace NoaaNcdcClient.Models
{
    public class DataTypesRequest : ApiRequest<DataTypesRequest>
    {
        public override string Endpoint { get; } = "datatypes";

        public DataTypesRequest WithDatasets(params string[] datasetIds)
        {
            SetArrayParam("datasetid", datasetIds);
            return this;
        }

        public DataTypesRequest WithLocations(params string[] locationIds)
        {
            SetArrayParam("locationid", locationIds);
            return this;
        }

        public DataTypesRequest WithStations(params string[] stationIds)
        {
            SetArrayParam("stationid", stationIds);
            return this;
        }

        public DataTypesRequest WithDataCategories(params string[] dataCategoryIds)
        {
            SetArrayParam("datacategoryid", dataCategoryIds);
            return this;
        }
    }
}
