using System;
using Mt.Broadcast.Contracts;

namespace Mt.Broadcast.Receiver.Models
{
    public class MessageDto: IBroadcastMessage
    {
        public string Text { get; set; }
        public DateTime SentTimeUtc { get; set; }
    }
}