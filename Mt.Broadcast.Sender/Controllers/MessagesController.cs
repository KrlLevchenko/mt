using Microsoft.AspNetCore.Mvc;
using Mt.Broadcast.Sender.Models;

namespace Mt.Broadcast.Sender.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        public IActionResult Post([FromBody] MessageDto message)
        {
            return Ok();
        }
    }
}