namespace FilmManagement.Application.Common.Responses
{
    public class ApiPagedResponse<T> : ApiResponse<IList<T>>
    {
        public int TotalCount { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public ApiPagedResponse(IList<T> data, int totalCount, int skip, int take, string message, int? statusCode = null)
            : base(data, message, statusCode)
        {
            TotalCount = totalCount;
            Skip = skip;
            Take = take;
        }

        public ApiPagedResponse(IList<T> data,string message,int? statusCode=null)
            :base(data,message,statusCode)
        {           
        }

        public ApiPagedResponse(IList<T> data, string message)
            : base(data, message)
        {
        }

        public ApiPagedResponse(string message)
            : base(message)
        {
        }       
    }
}
