using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace aspcore_api_exception_handler.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;
            if (typeof(ArgumentException) == exception.GetType())
            {
                return this.Problem(title: exception.Message, statusCode: (int)HttpStatusCode.BadRequest);
            }

            return this.Problem(title: HttpContext.Features.Get<IExceptionHandlerFeature>().Error.Message);
        }
    }
}
