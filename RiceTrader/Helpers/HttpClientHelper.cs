namespace RiceTrader.Helpers
{
    public class HttpClientHelper
    {
        public static HttpClient GetHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://34.110.147.74.nip.io/ricelinkapi/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("x-apikey", "RD3FEWPGhJRIn5egcgP2VyWDenPqPdYRvMGq7YcQIqGJuXAF");

            return httpClient;
        }
    }
}
