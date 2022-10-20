using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ciusss.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class HeureController : ControllerBase
    {
        [HttpGet()]
        public DateTime Get() {
            return DateTime.Now;
        }
    }
}
