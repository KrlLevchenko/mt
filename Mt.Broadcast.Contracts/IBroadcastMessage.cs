using System;

namespace Mt.Broadcast.Contracts
{
    public interface IBroadcastMessage
    {
        public string Text { get; }

        public DateTime SentTimeUtc { get; }
    }
}