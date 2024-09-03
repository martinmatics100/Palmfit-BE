

namespace Palmfit.Application.Responses
{
    public class GeneralResponse
    {
        public bool Flag { get; }
        public string Message { get; }

        public GeneralResponse(bool flag, string message = null!)
        {
            Flag = flag;
            Message = message;
        }
    }
}
