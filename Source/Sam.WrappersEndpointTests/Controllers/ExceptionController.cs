using Microsoft.AspNetCore.Mvc;
using Sam.Wrappers;

namespace Sam.WrappersEndpointTests.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ExceptionController : ControllerBase
{
    [HttpGet]
    public IActionResult ThrowAppException(ErrorCode errorCode)
    {
        AppException.Throw(errorCode, "AppException Message");
        return Ok();
    }

    [HttpGet]
    public IActionResult ThrowException()
    {
        throw new Exception("Exception Message");
    }
}
