namespace FilmManagement.Application.Common.Responses
{
    public class ApiListResponse<T> : ApiResponse<IList<T>>
    {
        public ApiListResponse(IList<T> data, string message, int? statusCode = null) : base(data, message, statusCode)
        {
        }

        public ApiListResponse(IList<T> data, string message) : base(data, message)
        {
        }

        public ApiListResponse(string message) : base(message)
        {
        }
    }
}
