

namespace Palmfit.Application.Responses
{
    public class DataResponse<T>
    {
        public bool Flag { get; }
        public string Message { get; }
        public T Data { get; }

        public DataResponse(bool flag, string message = null!, T data = default!)
        {
            Flag = flag;
            Message = message;
            Data = data;
        }
    }
}
