using Microsoft.AspNetCore.Mvc;

namespace Snake.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SnakeController : ControllerBase
    {
        public SnakeController()
        {
            
        }

        [HttpGet, Route("Test")]
        public async Task<IActionResult> Test(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
