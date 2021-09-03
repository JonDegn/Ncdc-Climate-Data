using System.IO;

namespace JonDegn.BulkData.Ftp
{
    public interface IFtpClient
    {
        bool DownloadFile(string localPath, string remotePath);
        Stream Download(string remotePath);
    }
}
