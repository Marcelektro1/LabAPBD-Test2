namespace LabAPBD_Test2.Services.Utils;

// code from: simpleFileHost app by github.com/Marcelektro
public class ServiceResult<T>
{
    public bool Success { get; private set; }
    public T? Data { get; private set; } // Only present if Success is true
    public string? ErrorCode { get; private set; } // Only present if Success is false
    public string? Message { get; private set; } // Only present if Success is false

    public static ServiceResult<T> SuccessResult(T data)
    {
        return new ServiceResult<T>
        {
            Success = true,
            Data = data
        };
    }

    public static ServiceResult<T> FailureResult(string errorCode, string message)
    {
        return new ServiceResult<T>
        {
            Success = false,
            ErrorCode = errorCode,
            Message = message
        };
    }
}