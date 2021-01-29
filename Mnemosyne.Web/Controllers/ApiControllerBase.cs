using Microsoft.AspNetCore.Mvc;

namespace Mnemosyne.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public abstract class ApiControllerBase : ControllerBase
    {

    }
}
