using JonDegn.ClimateData;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using JonDegn.BulkData.Ftp;
using System.Linq;

namespace JonDegn.BulkData
{
    public class BulkDataClient
    {
        public static string Host { get; } = "ftp.ncdc.noaa.gov";

        private IFtpClient FtpClient { get; }
        private ILogger<BulkDataClient> Logger { get; }

        public BulkDataClient(IFtpClient ftpClient, ILogger<BulkDataClient> logger=null)
        {
            FtpClient = ftpClient;
            Logger = logger;
        }

        public List<DataRow> GetDailySummaries(string stationId)
        {
            // Sometimes stationIds contain the dataset. We need to remove it to get the correct directory.
            var colonPos = stationId.IndexOf(':');
            if (colonPos > -1) stationId = stationId[(colonPos + 1)..];

            var ftpPath = $"/pub/data/ghcn/daily/by_station/{stationId}.csv.gz";
            Logger?.LogInformation($"Downloading file: {ftpPath}");
            using var stream = new GZipStream(FtpClient.Download(ftpPath), CompressionMode.Decompress);
            using var reader = new StreamReader(stream);
            var rows = new List<DataRow>();
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(',');
                var day = DateTime.ParseExact(parts[1], "yyyyMMdd", null);
                var dataType = parts[2];
                var value = int.Parse(parts[3]);
                var attributes = string.Join(',', parts.ToList().Skip(4).ToList());
                rows.Add(new DataRow
                {
                    Station = $"GHCND:{stationId}",
                    Date = day,
                    DataType = dataType,
                    Value = value,
                    Attributes = attributes
                });
            }
            return rows;
        }
    }
}
