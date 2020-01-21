using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace netCoreAPI.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public string Get()
        {
            return "netCoreAPI is ONLINE";
        }
    }
}