using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoaaNcdcClient.Models
{
    public class DataRequest
    {
        public string Endpoint { get; } = "data";
        public string[] DatasetIds { get; private set; }
        public string[] LocationIds { get; private set; }
        public string[] StationIds { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public Units Units { get; set; }
        public string SortField { get; private set; }
        public SortOrder SortOrder { get; private set; }
        public int Limit { get; private set; } = 25;
        public int Offset { get; private set; }
        public bool IncludeMetadata { get; set; } = true;

        public DataRequest WithDatasets(params string[] datasetIds)
        {
            DatasetIds = datasetIds;
            return this;
        }

        public DataRequest WithLocations(params string[] locationIds)
        {
            LocationIds = locationIds;
            return this;
        }

        public DataRequest WithStations(params string[] stationIds)
        {
            StationIds = stationIds;
            return this;
        }

        public DataRequest WithStartDate(DateTime startDate)
        {
            StartDate = startDate;
            return this;
        }

        public DataRequest WithEndDate(DateTime endDate)
        {
            EndDate = endDate;
            return this;
        }

        public DataRequest WithUnits(Units units)
        {
            Units = units;
            return this;
        }

        public DataRequest WithSortField(string sortField)
        {
            SortField = sortField;
            return this;
        }

        public DataRequest WithSortOrder(SortOrder sortOrder)
        {
            SortOrder = sortOrder;
            return this;
        }

        public DataRequest WithLimit(int limit)
        {
            Limit = limit;
            return this;
        }

        public DataRequest WithOffset(int offset)
        {
            Offset = offset;
            return this;
        }

        public DataRequest WithIncludeMetadata(bool includeMetadata)
        {
            IncludeMetadata = includeMetadata;
            return this;
        }

        public string GetQuery()
        {
            var queryParams = new List<string>();
            if (DatasetIds != null && DatasetIds.Length > 0) queryParams.Add(MakeQueryParamForArray("datasetid", DatasetIds));
            if (LocationIds != null && LocationIds.Length > 0) queryParams.Add(MakeQueryParamForArray("locationid", LocationIds));
            if (StationIds != null && StationIds.Length > 0) queryParams.Add(MakeQueryParamForArray("stationid", StationIds));
            if (StartDate != null) queryParams.Add($"startdate={StartDate.Value:yyyy-MM-dd}");
            if (EndDate != null) queryParams.Add($"enddate={EndDate.Value:yyyy-MM-dd}");
            queryParams.Add($"units={Enum.GetName(Units)}");
            if (SortField != null) queryParams.Add($"sortfield={SortField}");
            queryParams.Add($"sortorder={Enum.GetName(SortOrder)}");
            queryParams.Add($"limit={Limit}");
            queryParams.Add($"offset={Offset}");
            queryParams.Add($"includemetadata={IncludeMetadata}");
            return $"?{string.Join("&", queryParams)}";
        }
        private string MakeQueryParamForArray(string fieldName, string[] ids, char separator = '&')
        {
            return $"{fieldName}={Uri.EscapeDataString(string.Join(separator, ids))}";
        }

    }
}
