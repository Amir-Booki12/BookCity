

namespace _01_Framework.Application
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public OperationResult()
        {
            IsSuccess = false;
        }

        public OperationResult Succedded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSuccess = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message)
        {
            IsSuccess = false;
            Message = message;
            return this;
        }

        public OperationResult Failed(object passwordsNotMatch)
        {
            throw new NotImplementedException();
        }
    }
}
