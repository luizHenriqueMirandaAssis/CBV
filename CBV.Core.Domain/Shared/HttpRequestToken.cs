namespace CBV.Core.Domain.Shared
{
    public class HttpRequestToken
    {
        public string Url { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }


        public static HttpRequestToken Build(string url, string clientId, string clientSecret)
        {
            return new HttpRequestToken()
            {
                Url = url,
                ClientId = clientId,
                ClientSecret = clientSecret
            };
        }
    }
}


