using Microsoft.AspNetCore.Mvc;

namespace WebApp
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly IRandomActor _randomActor;

        public ExampleController(IRandomActor randomActor)
        {
            _randomActor = randomActor;
        }

        [HttpGet]
        public string Get()
        {
            return _randomActor.Act();
        }
    }
}
