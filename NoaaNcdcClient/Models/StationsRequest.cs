using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoaaNcdcClient.Models
{
    public class StationsRequest
    {
        public string Endpoint { get; } = "stations";
        public string[] DatasetIds { get; private set; }
        public string[] LocationIds { get; private set; }
        public string[] DataCategoryIds { get; private set; }
        public string[] DataTypeIds { get; private set; }
        public double[] Extent { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string SortField { get; private set; }
        public SortOrder SortOrder { get; private set; }
        public int Limit { get; private set; } = 25;
        public int Offset { get; private set; }

        public StationsRequest WithDatasets(params string[] datasetIds)
        {
            DatasetIds = datasetIds;
            return this;
        }

        public StationsRequest WithLocations(params string[] locationIds)
        {
            LocationIds = locationIds;
            return this;
        }

        public StationsRequest WithDataCategories(params string[] dataCategoryIds)
        {
            DataCategoryIds = dataCategoryIds;
            return this;
        }

        public StationsRequest WithDataTypes(params string[] dataTypeIds)
        {
            DataTypeIds = dataTypeIds;
            return this;
        }

        public StationsRequest WithExtent(double latMin, double lonMin, double latMax, double lonMax)
        {
            Extent = new[] { latMin, lonMin, latMax, lonMax };
            return this;
        }

        public StationsRequest WithStartDate(DateTime startDate)
        {
            StartDate = startDate;
            return this;
        }

        public StationsRequest WithEndDate(DateTime endDate)
        {
            EndDate = endDate;
            return this;
        }

        public StationsRequest WithSortField(string sortField)
        {
            SortField = sortField;
            return this;
        }

        public StationsRequest WithSortOrder(SortOrder sortOrder)
        {
            SortOrder = sortOrder;
            return this;
        }

        public StationsRequest WithLimit(int limit)
        {
            Limit = limit;
            return this;
        }

        public StationsRequest WithOffset(int offset)
        {
            Offset = offset;
            return this;
        }

        public string GetQuery()
        {
            var queryParams = new List<string>();
            if (DatasetIds != null && DatasetIds.Length > 0) queryParams.Add(MakeQueryParamForArray("datasetid", DatasetIds));
            if (LocationIds != null && LocationIds.Length > 0) queryParams.Add(MakeQueryParamForArray("locationid", LocationIds));
            if (DataCategoryIds != null && DataCategoryIds.Length > 0) queryParams.Add(MakeQueryParamForArray("datacategoryid", DataCategoryIds));
            if (DataTypeIds != null && DataTypeIds.Length > 0) queryParams.Add(MakeQueryParamForArray("datatypeid", DataTypeIds));
            if (Extent != null && Extent.Length > 0) queryParams.Add($"extent={Extent[0]},{Extent[1]},{Extent[2]},{Extent[3]}");
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
