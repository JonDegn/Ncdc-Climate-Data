using System;

namespace JonDegn.ClimateData
{
    public class DataRequest : ApiRequest<DataRequest>
    {
        public override string Endpoint { get; } = "data";


        /// <param name="datasetId">Required. Accepts a single valid dataset id. Data returned will be from the dataset specified.</param>
        /// <param name="startDate">Required. Data returned will be after the specified date. Annual and Monthly data will be limited to a ten year range while all other data will be limted to a one year range.</param>
        /// <param name="endDate">Required. Data returned will be before the specified date. Annual and Monthly data will be limited to a ten year range while all other data will be limted to a one year range.</param>
        public DataRequest(string datasetId, DateTime startDate, DateTime endDate)
        {
            SetParam(QueryParameters.Dataset, datasetId);
            SetParam(QueryParameters.StartDate, startDate.ToString("yyyy-MM-dd"));
            SetParam(QueryParameters.EndDate, endDate.ToString("yyyy-MM-dd"));
        }
        
        /// <summary>
        /// Required. Accepts a single valid dataset id. Data returned will be from the dataset specified.
        /// </summary>
        /// <param name="datasetId">The dataset id.</param>
        public DataRequest WithDataset(string datasetId)
        {
            SetParam(QueryParameters.Dataset, datasetId);
            return this;
        }

        /// <summary>
        /// Optional. Accepts a valid data type id or a chain of data type ids separated by ampersands. Data returned will contain all of the data type(s) specified.
        /// </summary>
        /// <param name="datatypeIds">The data type ids.</param>
        public DataRequest WithDatatypes(params string[] datatypeIds)
        {
            SetArrayParam(QueryParameters.DataType, datatypeIds);
            return this;
        }

        /// <summary>
        /// Optional. Accepts a valid location id or a list of location ids. Data returned will contain data for the location(s) specified.
        /// </summary>
        /// <param name="locationIds">The location ids.</param>
        public DataRequest WithLocations(params string[] locationIds)
        {
            SetArrayParam(QueryParameters.Location, locationIds);
            return this;
        }

        /// <summary>
        /// Optional. Accepts a valid station id or a list of station ids. Data returned will contain data for the station(s) specified.
        /// </summary>
        /// <param name="stationIds">The station ids.</param>
        public DataRequest WithStations(params string[] stationIds)
        {
            SetArrayParam(QueryParameters.Station, stationIds);
            return this;
        }

        /// <summary>
        /// Optional. Accepts the literal strings 'standard' or 'metric'. Data will be scaled and converted to the specified units. If a unit is not provided then no scaling nor conversion will take place.
        /// </summary>
        /// <param name="units">The units to use in the returned data.</param>
        public DataRequest WithUnits(Units units)
        {
            SetParam(QueryParameters.Units, Enum.GetName(units));
            return this;
        }

        /// <summary>
        /// Required. Data returned will be after the specified date. Annual and Monthly data will be limited to a ten year range while all other data will be limted to a one year range.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        public override DataRequest WithStartDate(DateTime startDate)
        {
            return base.WithStartDate(startDate);
        }

        /// <summary>
        /// Required. Data returned will be before the specified date. Annual and Monthly data will be limited to a ten year range while all other data will be limted to a one year range.
        /// </summary>
        /// <param name="endDate">The end date.</param>
        public override DataRequest WithEndDate(DateTime endDate)
        {
            return base.WithEndDate(endDate);
        }

        /// <summary>
        /// Optional. Defaults to true, used to improve response time by preventing the calculation of result metadata.
        /// </summary>
        /// <param name="includeMetadata">Whether to include metadata in the result.</param>
        public DataRequest WithIncludeMetadata(bool includeMetadata)
        {
            SetParam("includemetadata", includeMetadata.ToString());
            return this;
        }
    }
}
