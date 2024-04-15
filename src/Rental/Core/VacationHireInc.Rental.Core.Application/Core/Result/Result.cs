namespace VacationHireInc.Rental.Core.Application.Core.Result;

public class Result<T> : Result
{
    public Result(Exception? ex = null)
    {
        IsEmpty = false;
        if (ex is not null)
            Errors.Add(ex);
    }
    
    public Result(T payload)
    {
        Payload = payload;
        IsEmpty = false;
    }
    
    public T? Payload { get; protected set; }

    public static Result<T> Success(T payload) => new Result<T>(payload);
    public static new Result<T> Failure(Exception ex = null!) => new Result<T>(ex);

}

public class Result
{
    public Result()
    {
        Succeeded = true;
        IsEmpty = false;
    }
    
    public Result(Exception ex = default!)
    {
        Succeeded = false;
        Errors.Add(ex);
        IsEmpty = false;
    }
    
    public bool Succeeded { get; protected set; }
    
    public bool Failed => !Succeeded;

    public bool IsEmpty { get; protected set; } = true;
    public List<Exception> Errors { get; } = new();

    public static Result Success() => new Result { Succeeded = true, IsEmpty = false };

    public static Result Failure(Exception ex = default!) => new(ex);

    public static Result Empty => new Result { Succeeded = false, IsEmpty = true };
    
    // Extensible to any kind of status
}
