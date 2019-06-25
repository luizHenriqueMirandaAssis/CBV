using System.Net;

namespace CBV.Core.Domain.Shared
{
    public class HttpResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; }

        public static HttpResponse Build(HttpStatusCode statusCode, object data)
        {
            return new HttpResponse()
            {
                StatusCode = statusCode,
                Data = data
            };
        }

        public  string GetDataString()
        {
            return string.IsNullOrEmpty(this.Data.ToString()) ? string.Empty : this.Data.ToString();
        }

        public bool IsSuccess()
        {
            return this.StatusCode == HttpStatusCode.OK;
        }
    }
}
