namespace CBV.Core.Domain.Exception
{
    public class HttpException 
    {
        public static void ThrowGetTokenException(string url, int statusCode)
        {
            throw new GetTokenException($"Não foi possível obter o token para a url: {url} StatusCode: {statusCode}");
        }
        public static void ThrowGetException(string url, int statusCode)
        {
            throw new GetException($"Não foi possível realizar o pedido (GET) para a url: {url} StatusCode: {statusCode}");
        }

    }

    public class GetTokenException : System.Exception
    {
        public GetTokenException(string message) : base(message)
        {

        }
    }

    public class GetException : System.Exception
    {
        public GetException(string message) : base(message)
        {

        }
    }
}
