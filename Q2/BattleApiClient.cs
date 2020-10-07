using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Q2
{
    public static class BattleApiClient
    {
        private static readonly HttpClient HttpClient = new HttpClient
        {
            BaseAddress = new Uri("https://ob6la3c120.execute-api.ap-northeast-1.amazonaws.com"),
            Timeout = TimeSpan.FromSeconds(30)
        };

        internal static async Task<BattleResult> Get(Monster monster1, Monster monster2)
        {
            try
            {
                var response = await HttpClient.GetAsync($"/Prod/battle/{WebUtility.UrlEncode(monster1.Name)}+{WebUtility.UrlEncode(monster2.Name)}").ConfigureAwait(false);
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException($"Error has occurred. Response StatusCode:{(int)response.StatusCode} ReasonPhrase:{response.ReasonPhrase}.");
                }

                return JsonSerializer.Deserialize<BattleResult>(json);
            }
            catch (WebException ex)
            {
                switch (ex.Status)
                {
                    case WebExceptionStatus.RequestCanceled:
                    case WebExceptionStatus.Timeout:
                        throw new ApplicationException("Request Timeout");
                    default:
                        throw;
                }
            }
            catch (TaskCanceledException)
            {
                throw new ApplicationException("Request Timeout");
            }
            catch (OperationCanceledException)
            {
                throw new ApplicationException("Request Timeout");
            }
        }
    }
}
