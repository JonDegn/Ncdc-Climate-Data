using System;
using System.Collections.Generic;

namespace NoaaNcdcClient.Models
{
    public class DataTypesRequest
    {
        public string Endpoint { get; } = "datatypes";
        public string[] datasetIds { get; private set; }
        public string[] LocationIds { get; private set; }
        public string[] StationIds { get; private set; }
        public string[] DataCategoryIds { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string SortField { get; private set; }
        public SortOrder SortOrder { get; private set; }
        public int Limit { get; private set; } = 25;
        public int Offset { get; private set; }

        public DataTypesRequest WithDatasets(params string[] datasetIds)
        {
            this.datasetIds = datasetIds;
            return this;
        }

        public DataTypesRequest WithLocations(params string[] locationIds)
        {
            LocationIds = locationIds;
            return this;
        }

        public DataTypesRequest WithStations(params string[] stationIds)
        {
            StationIds = stationIds;
            return this;
        }

        public DataTypesRequest WithDataCategories(params string[] dataCategoryIds)
        {
            DataCategoryIds = dataCategoryIds;
            return this;
        }

        public DataTypesRequest WithStartDate(DateTime startDate)
        {
            StartDate = startDate;
            return this;
        }

        public DataTypesRequest WithEndDate(DateTime endDate)
        {
            EndDate = endDate;
            return this;
        }

        public DataTypesRequest WithSortField(string sortField)
        {
            SortField = sortField;
            return this;
        }

        public DataTypesRequest WithSortOrder(SortOrder sortOrder)
        {
            SortOrder = sortOrder;
            return this;
        }

        public DataTypesRequest WithLimit(int limit)
        {
            Limit = limit;
            return this;
        }

        public DataTypesRequest WithOffset(int offset)
        {
            Offset = offset;
            return this;
        }

        public string GetQuery()
        {
            var queryParams = new List<string>();
            if (datasetIds != null && datasetIds.Length > 0) queryParams.Add(MakeQueryParamForArray("datasetid", datasetIds));
            if (LocationIds != null && LocationIds.Length > 0) queryParams.Add(MakeQueryParamForArray("locationid", LocationIds));
            if (StationIds != null && StationIds.Length > 0) queryParams.Add(MakeQueryParamForArray("stationid", StationIds));
            if (DataCategoryIds != null && DataCategoryIds.Length > 0) queryParams.Add(MakeQueryParamForArray("datacategoryid", DataCategoryIds));
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
