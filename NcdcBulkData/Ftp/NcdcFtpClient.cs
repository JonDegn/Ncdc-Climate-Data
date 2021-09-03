using FluentFTP;
using System.IO;

namespace JonDegn.BulkData.Ftp
{
    public class NcdcFtpClient : IFtpClient
    {
        public FtpClient FtpClient { get; set; }
        public NcdcFtpClient()
        {
            FtpClient = new FtpClient("ftp.ncdc.noaa.gov", "anonymous", "none");
        }

        public Stream Download(string remotePath)
        {
            var memStream = new MemoryStream();
            FtpClient.Download(memStream, remotePath);
            memStream.Position = 0;
            return memStream;
        }

        //public Stream DownloadFile(string fullPath)
        //{
        //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fullPath);
        //    request.Method = WebRequestMethods.Ftp.DownloadFile;
        //    request.Credentials = new NetworkCredential("anonymous", "none");

        //    FtpWebResponse response = (FtpWebResponse)request.GetResponse();

        //    var tempFile = Path.GetTempFileName();
        //    using (Stream responseStream = response.GetResponseStream())
        //    using (Stream gzipStream = new GZipStream(responseStream, CompressionMode.Decompress))
        //    using (var fileStream = File.OpenWrite(tempFile))
        //    {
        //        gzipStream.CopyTo(fileStream);
        //    }

        //    return File.OpenRead(tempFile);
        //}

        public bool DownloadFile(string localPath, string remotePath)
        {
            return FtpClient.DownloadFile(localPath, remotePath).HasFlag(FtpStatus.Success);
        }
    }
}
