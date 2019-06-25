using System.Collections.Generic;

namespace CBV.Core.Domain.Adapter
{
    public class Response
    {
        public Response()
        {
            Success = false;
            Errors = new List<string>();
        }
        public bool Success { get; set; }
        public object Data { get; set; }
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        public static Response BuildSuccess(object data = null)
        {
            return new Response()
            {
                Success = true,
                Data = data,
                StatusCode = 200
            };
        }

        public static Response BuildInternalServerError()
        {
            return new Response()
            {
                Success = false,
                Errors = AddError("Não foi possível processar sua solicitação. Tente novamente mais tarde"),
                StatusCode = 500
            };
        }

        public static Response BuildBadRequest(object value = null, List<string> errors = null)
        {

            var msg = value == null
                ? "Solicitação inválida"
                : $"Solicitação inválida, valor: {value}";

            return new Response()
            {
                Success = false,
                Errors = errors ?? AddError(msg),
                StatusCode = 400
            };
        }

        public static Response BuildNotFound(string msg)
        {
            return new Response()
            {
                Success = false,
                Errors = AddError(msg),
                StatusCode = 404
            };
        }

        public static List<string> AddError(string erro)
        {
            return new List<string>() { erro };
        }
    }
}
