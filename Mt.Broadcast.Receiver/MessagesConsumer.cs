using System.Threading.Tasks;
using MassTransit;
using Mt.Broadcast.Contracts;
using Mt.Broadcast.Receiver.Models;

namespace Mt.Broadcast.Receiver
{
    public class MessagesConsumer: IConsumer<IBroadcastMessage>
    {
        private readonly MessageStore _messageStore;

        public MessagesConsumer(MessageStore messageStore)
        {
            _messageStore = messageStore;
        }
        public Task Consume(ConsumeContext<IBroadcastMessage> context)
        {
            _messageStore.AddMessage(context.Message);
            return Task.CompletedTask;
        }
    }
}