using Microsoft.AspNetCore.Mvc;
namespace WebShopInc.ApiWrappings;


public class BaseController : ControllerBase
{
    public BaseController() { }

    // TODO: remove this?
    public ActionResult<T> FormatResult<T>(T result)
    {

        ApiResponse<T> response = new ApiResponse<T>
        {
            Data = result,
            Errors = null
        };

        return Ok(response);
    }

    // TODO: remove this?
    public ActionResult<T> FormatError<T>(T result)
    {

        ApiResponse<T> response = new ApiResponse<T>
        {
            Data = result,
            Errors = null
        };

        return Ok(response);
    }
}
