using System;
using System.Collections.Generic;
using System.Linq;

namespace NoaaNcdcClient.Models
{
    public abstract class ApiRequest<T> where T : ApiRequest<T>
    {
        public abstract string Endpoint { get; }

        public Dictionary<string, string> QueryParams { get; private set; } = new Dictionary<string, string>();

        protected void SetArrayParam(string name, string[] ids)
        {
            QueryParams[name] = $"{Uri.EscapeDataString(string.Join('&', ids))}";
        }

        protected void SetParam(string name, string value)
        {
            QueryParams[name] = Uri.EscapeDataString(value);
        }

        public T WithStartDate(DateTime startDate)
        {
            SetParam("startdate", startDate.ToString("yyyy-MM-dd"));
            return (T)this;
        }

        public T WithEndDate(DateTime endDate)
        {
            SetParam("enddate", endDate.ToString("yyyy-MM-dd"));
            return (T)this;
        }

        public T WithSortField(string sortField)
        {
            SetParam("sortfield", sortField);
            return (T)this;
        }

        public T WithSortOrder(SortOrder sortOrder)
        {
            SetParam("sortfield", Enum.GetName(sortOrder));
            return (T)this;
        }

        public T WithLimit(int limit)
        {
            SetParam("limit", limit.ToString());
            return (T)this;
        }

        public T WithOffset(int offset)
        {
            SetParam("offset", offset.ToString());
            return (T)this;
        }

        public string GetQuery()
        {
            return $"?{string.Join("&", QueryParams.Select(kv => $"{kv.Key}={kv.Value}"))}";
        }


    }
}
