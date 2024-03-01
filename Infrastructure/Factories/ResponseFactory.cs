

using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ResponseFactory
{
    public static ResponseResult Ok()
    {
        return new ResponseResult
        {
           
            Message = "Succeded",
            StatusCode = StatusCodes.OK

        };
    }

    public static ResponseResult Ok(string? message = null)
    {
        return new ResponseResult
        {
           
            Message = message ?? "Succeded",
            StatusCode = StatusCodes.OK

        };
    }

    public static ResponseResult Ok(Object obj, string? message = null)
    {
        return new ResponseResult
        {
            ContentResult = obj,
            Message = message ?? "Succeded",
            StatusCode = StatusCodes.OK

        };
    }


    public static ResponseResult Error( string? message = null)
    {
        return new ResponseResult
        {

            Message = message ?? "Failed ",
            StatusCode = StatusCodes.ERROR

        };
    }

    public static ResponseResult NotFound(string? message = null)
    {
        return new ResponseResult
        {

            Message = message ?? "Not found",
            StatusCode = StatusCodes.NOTFOUND

        };
    }

    public static ResponseResult Exists(string? message = null)
    {
        return new ResponseResult
        {

            Message = message ?? "Already Exists",
            StatusCode = StatusCodes.EXISTS

        };
    }

}
