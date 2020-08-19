using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MySqlDogs.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly ILogger<DogsController> _logger;

        public DogsController(ILogger<DogsController> logger)
        {
            _logger = logger;
        }
    }
}
