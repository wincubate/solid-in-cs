using System;
using System.Net;
using System.Threading.Tasks;

namespace Wincubate.Solid
{
    class WebStorage : IReadStorage
    {
        public string Url { get; }

        public WebStorage(string url)
        {
            Url = url;
        }

        public async Task<string> GetDataAsStringAsync()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    return await client.DownloadStringTaskAsync(Url);
                }
            }
            catch (Exception exception)
            {
                throw new StockStorageException($"Could not load from \"{Url}\"", exception);
            }
        }
    }
}
