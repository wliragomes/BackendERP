using SharedKernel.DTOs;

namespace SharedKernel.SharedObjects
{
    public class NewResponse
    {
        public object? Data { get; set; }
        public MetaDTO? Meta { get; set; }
        public int StatusCode { get; set; } = 200;
        public object? Errors { get; set; }

        public NewResponse()
        {
        }

        public NewResponse(object data)
        {
            Data = data;
        }

        public NewResponse(object data, int statusCode)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public NewResponse(object data, int statusCode, object errors)
        {
            Data = data;
            StatusCode = statusCode;
            Errors = errors;
        }

        public NewResponse(int statusCode, object errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

        public NewResponse(int statusCode)
        {
            Data = default;
            StatusCode = statusCode;
        }
    }
}
