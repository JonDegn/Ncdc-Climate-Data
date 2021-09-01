using System;
using System.Collections.Generic;

namespace NoaaNcdcClient.Models
{
    public class DatasetsRequest
    {
        public string Endpoint { get; } = "datasets";
        public string[] DataTypeIds { get; private set; }
        public string[] LocationIds { get; private set; }
        public string[] StationIds { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string SortField { get; private set; }
        public SortOrder SortOrder { get; private set; }
        public int Limit { get; private set; } = 25;
        public int Offset { get; private set; }

        public DatasetsRequest WithDataTypes(params string[] dataTypeIds)
        {
            DataTypeIds = dataTypeIds;
            return this;
        }

        public DatasetsRequest WithLocations(params string[] locationIds)
        {
            LocationIds = locationIds;
            return this;
        }

        public DatasetsRequest WithStations(params string[] stationIds)
        {
            StationIds = stationIds;
            return this;
        }

        public DatasetsRequest WithStartDate(DateTime startDate)
        {
            StartDate = startDate;
            return this;
        }

        public DatasetsRequest WithEndDate(DateTime endDate)
        {
            EndDate = endDate;
            return this;
        }

        public DatasetsRequest WithSortField(string sortField)
        {
            SortField = sortField;
            return this;
        }

        public DatasetsRequest WithSortOrder(SortOrder sortOrder)
        {
            SortOrder = sortOrder;
            return this;
        }

        public DatasetsRequest WithLimit(int limit)
        {
            Limit = limit;
            return this;
        }

        public DatasetsRequest WithOffset(int offset)
        {
            Offset = offset;
            return this;
        }

        public string GetQuery()
        {
            var queryParams = new List<string>();
            if (DataTypeIds != null && DataTypeIds.Length > 0) queryParams.Add(MakeQueryParamForArray("datatypeid", DataTypeIds));
            if (LocationIds != null && LocationIds.Length > 0) queryParams.Add(MakeQueryParamForArray("locationid", LocationIds));
            if (StationIds != null && StationIds.Length > 0) queryParams.Add(MakeQueryParamForArray("stationid", StationIds));
            if (StartDate != null) queryParams.Add($"startdate={StartDate.Value.ToString("yyyy-MM-dd")}");
            if (EndDate != null) queryParams.Add($"enddate={EndDate.Value.ToString("yyyy-MM-dd")}");
            if (SortField != null) queryParams.Add($"sortfield={SortField}");
            queryParams.Add($"sortorder={Enum.GetName(SortOrder)}");
            queryParams.Add($"limit={Limit}");
            queryParams.Add($"offset={Offset}");
            return $"?{string.Join("&", queryParams)}";
        }
        private string MakeQueryParamForArray(string fieldName, string[] ids, char separator = '&')
        {
            return $"{fieldName}={Uri.EscapeDataString(string.Join(separator, ids))}";
        }

    }
}
