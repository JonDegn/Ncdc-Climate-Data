namespace NoaaNcdcClient
{
    public static class QueryParameters
    {
        public static string Dataset { get; } = "datasetid";
        public static string DataType { get; } = "datatypeid";
        public static string Location { get; } = "locationid";
        public static string Station { get; } = "stationid";
        public static string LocationCategory { get; } = "locationcategoryid";
        public static string DataCategory { get; } = "datacategoryid";
        public static string Extent { get; } = "extent";
        public static string StartDate { get; } = "startdate";
        public static string EndDate { get; } = "enddate";
        public static string SortField { get; } = "sortfield";
        public static string SortOrder { get; } = "sortorder";
        public static string Units { get; } = "units";
        public static string Limit { get; } = "limit";
        public static string Offset { get; } = "offset";
        public static string IncludeMetadata { get; } = "includemetadata";
    }
}
    