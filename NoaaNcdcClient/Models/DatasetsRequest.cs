namespace NoaaNcdcClient.Models
{
    public class DatasetsRequest : ApiRequest<DatasetsRequest>
    {
        public override string Endpoint { get; } = "datasets";

        public DatasetsRequest WithDataTypes(params string[] dataTypeIds)
        {
            SetArrayParam("datatypeid", dataTypeIds);
            return this;
        }

        public DatasetsRequest WithLocations(params string[] locationIds)
        {
            SetArrayParam("locationid", locationIds);
            return this;
        }

        public DatasetsRequest WithStations(params string[] stationIds)
        {
            SetArrayParam("stationid", stationIds);
            return this;
        }
    }
}
