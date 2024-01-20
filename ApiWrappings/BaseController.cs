using Microsoft.AspNetCore.Mvc;
namespace WebShopInc.ApiWrappings;


public class BaseController : ControllerBase
{
    public BaseController() { }

    public ActionResult<ApiResponse<T>> Format<T>(T result)
    {

        ApiResponse<T> response = new ApiResponse<T>
        {
            Data = result,
            Errors = new List<string> { "abc " }
        };


        return Ok(response);
    }
}
