using log4net;

namespace LocatorsPracticalTask.Core.Utilities
{
    public class FileHelper
    {
        private static ILog Log = Logger.Instance;

        public bool WaitForFileDownload(string directory, string expectedFileName, int timeoutSeconds = 10)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            while (watch.Elapsed.TotalSeconds < timeoutSeconds)
            {
                var files = Directory.GetFiles(directory, expectedFileName);
                if (files.Length > 0)
                {
                    FileInfo fileInfo = new FileInfo(files[0]);
                    if (!IsFileLocked(fileInfo))
                        return true;
                }
                Task.Delay(500).Wait();
            }
            return false;
        }

        private bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None)) { }
            }
            catch (IOException)
            {
                return true;
            }
            return false;
        }
    }
}
