using Newtonsoft.Json;

namespace FilmManagement.Application.Common.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] //StatusCode parametresi gönderilmezse response'da görünmez.
        public int? StatusCode { get; set; }       //Opsiyonel       

        public ApiResponse(T data, string message, int? statusCode = null)
        {
            Data = data;
            Message = message;
            StatusCode = statusCode;
        }

        public ApiResponse(T data, string message)
        {
            Data = data;
            Message = message;
        }

        public ApiResponse(string message)
        {
            Message = message;
        }
    }
}
