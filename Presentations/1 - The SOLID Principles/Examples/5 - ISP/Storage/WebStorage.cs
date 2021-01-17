using System;
using System.Net;
using System.Threading.Tasks;

namespace Wincubate.Solid.Module01
{
    class WebStorage : IReadStorage
    {
        public string Url { get; }

        public WebStorage(string url)
        {
            Url = url;
        }

        public Task<string> GetDataAsStringAsync()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    return client.DownloadStringTaskAsync(Url);
                }
            }
            catch (Exception exception)
            {
                throw new StockStorageException($"Could not load from \"{Url}\"", exception);
            }
        }
    }
}
