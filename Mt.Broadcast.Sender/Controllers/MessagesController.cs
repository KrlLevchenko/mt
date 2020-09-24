using System;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Mt.Broadcast.Contracts;
using Mt.Broadcast.Sender.Models;

namespace Mt.Broadcast.Sender.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly IBusControl _busControl;

        public MessagesController(IBusControl busControl)
        {
            _busControl = busControl;
        }
        
        public IActionResult Post([FromBody] MessageDto message)
        {
            _busControl.Publish<IBroadcastMessage>(new BroadcastMessage(message.Text));
            return Ok();
        }

        private class BroadcastMessage : IBroadcastMessage
        {
            public BroadcastMessage(string text)
            {
                Text = text;
            }

            public string Text { get; }
            public DateTime SentTimeUtc { get; } = DateTime.UtcNow;
        }
    }
    
}