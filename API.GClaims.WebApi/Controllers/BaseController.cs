using API.GClaims.CrossCutting;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.GClaims.WebApi.Controllers
{
    
    [ApiController]
    public class BaseController : Controller
    {
        protected BaseController()
        {
        }

        protected IActionResult CreateResponse(HttpStatusCode statusCode, string message = null)
        {
            if (statusCode == HttpStatusCode.OK)
            {
                return HttpResult<object>.Success(null, message);
            }

            return HttpResult<object>.Error((int)statusCode, $"{message}");
        }
        protected IActionResult CreateResponse(HttpStatusCode statusCode, object result, string message = null)
        {
            if (statusCode == HttpStatusCode.OK)
            {
                return HttpResult<object>.Success(result, message);
            }

            return HttpResult<object>.Error((int)statusCode, $"{message}");
        }
    }
}
