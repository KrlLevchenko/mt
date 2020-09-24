using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Mt.Broadcast.Contracts;

namespace Mt.Broadcast.Receiver.Models
{
    public class MessageStore
    {
        private ConcurrentBag<IBroadcastMessage> _messages = new ConcurrentBag<IBroadcastMessage>();

        public void AddMessage(IBroadcastMessage message)
        {
            _messages.Add(message);
        }

        public IEnumerable<MessageDto> GetAll() => _messages.Select(x => new MessageDto
        {
            Text = x.Text,
            SentTimeUtc = x.SentTimeUtc,
        }).ToList();
    }
}