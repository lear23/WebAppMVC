﻿

namespace Infrastructure.Models;

public enum StatusCodes
{
    OK = 200, 
    ERROR = 400,
    NOTFOUND = 404,
    EXISTS = 409
}


public class ResponseResult
{
    public StatusCodes StatusCode { get; set; }
    public object? ContentResult { get; set; }
    public string? Message { get; set; }


}
