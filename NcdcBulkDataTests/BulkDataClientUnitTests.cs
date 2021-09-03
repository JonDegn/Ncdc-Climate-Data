using NUnit.Framework;
using System.IO;
using System;
using Shouldly;
using JonDegn.ClimateData;
using JonDegn.BulkData.Ftp;
using JonDegn.BulkData;
using Moq;

namespace JonDegn.BulkDataTests
{
    public class BulkDataClientUnitTests
    {

        [SetUp]
        public void Setup()
        {

        }


        [Test]
        public void TestGetDailySummaries()
        {
            var stationId = "GHCND:USS0011K03S";

            var mock = new Mock<IFtpClient>();

            mock
                .Setup(m => m.Download("/pub/data/ghcn/daily/by_station/USS0011K03S.csv.gz"))
                .Returns(File.OpenRead(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/USS0011K03S.csv.gz")))
                .Verifiable();

            var client = new BulkDataClient(mock.Object);

            var list = client.GetDailySummaries(stationId);

            mock.Verify();

            list.Count.ShouldBe(13);
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