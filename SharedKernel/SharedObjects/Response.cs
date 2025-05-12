namespace SharedKernel.SharedObjects
{
    public class Response
    {
        public object? Dados { get; set; }
        public int StatusCode { get; set; } = 200;
        public object? Erros { get; set; }

        public Response()
        {
        }

        public Response(object dados)
        {
            Dados = dados;
        }

        public Response(object dados, int statusCode)
        {
            StatusCode = statusCode;
            Dados = dados;
        }

        public Response(object dados, int statusCode, object errors)
        {
            Dados = dados;
            StatusCode = statusCode;
            Erros = errors;
        }

        public Response(int statusCode, object errors)
        {
            StatusCode = statusCode;
            Erros = errors;
        }

        public Response(int statusCode)
        {
            Dados = default;
            StatusCode = statusCode;
        }
    }
}
