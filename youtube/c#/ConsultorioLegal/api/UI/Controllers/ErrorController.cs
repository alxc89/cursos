using ConsultorioLegal.api.UI.ModelViews.Erro;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConsultorioLegal.api.UI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;
            Response.StatusCode = 500;

            var idErro = Activity.Current?.Id;
            var requestId = HttpContext?.TraceIdentifier;
            return new ErrorResponse(idErro, requestId);
        }
    }
}
