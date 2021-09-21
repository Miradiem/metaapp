using metaapp.WeatherApi;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace metaapp.Storring
{
    public class WeatherFile
    {
        private SemaphoreSlim _mutex = new SemaphoreSlim(1, 1); //Limits threads
        private readonly string _file; //file path

        public WeatherFile(string file)
        {
            _file = file;
        }

        public async Task Save(WeatherModel weather)
        {
            await _mutex.WaitAsync();
            try
            {
                await WriteTextAsync(_file, Serialize(weather));
            }
            finally
            {
                _mutex.Release();
            }
        }

        private async Task WriteTextAsync(string filePath, string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using var destination =
                new FileStream(
                    filePath,
                    FileMode.Append, FileAccess.Write, FileShare.None,
                    bufferSize: 4096, useAsync: true);

            await destination.WriteAsync(encodedText, 0, encodedText.Length);
        }

        private string Serialize(WeatherModel weather)
        {
            return JsonConvert.SerializeObject(weather);
        }
    }
}
