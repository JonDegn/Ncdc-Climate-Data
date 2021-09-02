using System;
using System.Collections.Generic;
using System.Linq;

namespace JonDegn.ClimateData
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

        /// <summary>
        /// Optional. The items returned will have data after the specified date. Paramater can be use independently of enddate.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        public virtual T WithStartDate(DateTime startDate)
        {
            SetParam(QueryParameters.StartDate, startDate.ToString("yyyy-MM-dd"));
            return (T)this;
        }

        /// <summary>
        /// Optional. The items returned will have data before the specified date. Paramater can be use independently of startdate.
        /// </summary>
        /// <param name="endDate">The end date.</param>
        public virtual T WithEndDate(DateTime endDate)
        {
            SetParam(QueryParameters.EndDate, endDate.ToString("yyyy-MM-dd"));
            return (T)this;
        }

        /// <summary>
        /// Optional. The field to sort results by. Supports id, name, mindate, maxdate, and datacoverage fields.
        /// </summary>
        /// <param name="sortField">The sort field.</param>
        public T WithSortField(string sortField)
        {
            SetParam(QueryParameters.SortField, sortField);
            return (T)this;
        }

        /// <summary>
        /// Optional. Which order to sort by, asc or desc. Defaults to asc.
        /// </summary>
        /// <param name="sortOrder">The sort order.</param>
        public T WithSortOrder(SortOrder sortOrder)
        {
            SetParam(QueryParameters.SortOrder, Enum.GetName(sortOrder));
            return (T)this;
        }

        /// <summary>
        /// Optional. Defaults to 25, limits the number of results in the response. Maximum is 1000.
        /// </summary>
        /// <param name="limit">The limit.</param>
        public T WithLimit(int limit)
        {
            SetParam(QueryParameters.Limit, limit.ToString());
            return (T)this;
        }

        /// <summary>
        /// Optional. Defaults to 0, used to offset the resultlist. The example would begin with record 24.
        /// </summary>
        /// <param name="offset">The offset.</param>
        public T WithOffset(int offset)
        {
            SetParam(QueryParameters.Offset, offset.ToString());
            return (T)this;
        }

        public string GetQuery()
        {
            return $"?{string.Join("&", QueryParams.Select(kv => $"{kv.Key}={kv.Value}"))}";
        }


    }
}
