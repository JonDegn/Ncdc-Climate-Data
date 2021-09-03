using NUnit.Framework;
using System;
using Shouldly;
using Microsoft.Extensions.Configuration;
using JonDegn.BulkData;
using Microsoft.Extensions.Logging;
using JonDegn.ClimateData;
using JonDegn.BulkData.Ftp;

namespace JonDegn.ClimateDataTests
{
    public class BulkDataClientIntegrationTests
    {
        public IConfiguration Configuration { get; set; }
        public BulkDataClient Client { get; set; }

        [SetUp]
        public void Setup()
        {
            Configuration = new ConfigurationBuilder()
                .AddUserSecrets<BulkDataClientIntegrationTests>()
                .Build();
            var logger = LoggerFactory.Create(b => b.AddConsole()).CreateLogger<BulkDataClient>();
            Client = new BulkDataClient(new NcdcFtpClient(), logger);
        }

        [Test]
        public void TestGetDailySummaries()
        {
            var stationId = "GHCND:USS0011K03S";

            var list = Client.GetDailySummaries(stationId);

            list.Count.ShouldBeGreaterThanOrEqualTo(63351);
            var expected = new DataRow
            {
                Station = stationId,
                Date = new DateTime(1978, 11, 02),
                DataType = "PRCP",
                Value = 76,
                Attributes = ",,T,"
            };

            list[0].ShouldBeEquivalentTo(expected);
        }

    }
}