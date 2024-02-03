using Microsoft.AspNetCore.Mvc;

namespace WebShopInc.ApiWrappings;

// https://datatracker.ietf.org/doc/html/rfc7807
public class ApiResponse<T>
{
    public T? Data { get; set; }

    public ProblemDetails? Errors { get; set; }
}
