using MatchServiceApp.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace MatchServiceApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowSpecificOrigin")] // Apply CORS policy to the controller
    public class SwipingController : Controller
    {
        MatchService _matchService;

        public SwipingController(IConnection rabbitMQConnection)
        {
            _matchService = new MatchService(rabbitMQConnection);
        }

        [HttpPost("yes")]
        public IActionResult SwipedYes0(int swiperID, int id2)
        {
            // logic
            Console.WriteLine("SwipedYes got Called");
            Console.WriteLine($"id1:{swiperID} id2:{id2}");
            _matchService.AddIdToSwipedYes(swiperID, id2);
            return Ok();
        }

        [HttpPost("no")]
        public IActionResult SwipedNo(int swiperID, int id2)
        {
            // logic
            Console.WriteLine("SwipedNo got Called");
            Console.WriteLine($"id1:{swiperID} id2:{id2}");
            _matchService.AddIdToSwipedNo(swiperID, id2);
            return Ok();
        }
    }
}
