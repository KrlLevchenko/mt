using System;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Mt.Broadcast.Contracts;
using Mt.Broadcast.Receiver.Models;

namespace Mt.Broadcast.Receiver.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly MessageStore _store;

        public MessagesController(MessageStore store)
        {
            _store = store;
        }
        
        public IActionResult Get()
        {
            return Ok(_store.GetAll());
        }
    }
}