using Microsoft.AspNetCore.Mvc;

namespace Mnemosyne.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}