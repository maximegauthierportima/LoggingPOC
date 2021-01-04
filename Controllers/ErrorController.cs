using LoggingPOC.Attributes;
using LoggingPOC.BL;
using Microsoft.AspNetCore.Mvc;

namespace LoggingPOC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Logger]
    public class ErrorController : ControllerBase
    {
        private readonly IErrorBl _errorBl;

        public ErrorController(IErrorBl errorBl)
        {
            _errorBl = errorBl;
        }

        [HttpGet]
        [Route("argumentnullexception")]
        public IActionResult GetArgumentNullException()
        {
            _errorBl.ThrowingArgumentNullException();
            return Ok();
        }

        [HttpGet]
        [Route("exception")]
        public IActionResult GetException()
        {
            _errorBl.ThrowingException();
            return Ok();
        }
    }
}
