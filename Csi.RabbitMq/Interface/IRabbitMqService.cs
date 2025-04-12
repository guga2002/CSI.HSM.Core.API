namespace Csi.RabbitMq.Interface
{
    public interface IRabbitMqService : IAsyncDisposable
    {
        ValueTask PublishAsync<T>(
            string exchange,
            string routingKey,
            T message,
            IDictionary<string, object>? headers = null,
            int? delayMs = null);

        void Subscribe<T>(string queueName, Func<T, Task> handler);

        bool QueueExists(string queueName);

        void DeclareQueue(
            string queueName,
            bool durable = true,
            bool exclusive = false,
            bool autoDelete = false,
            IDictionary<string, object>? arguments = null);

        void DeleteQueue(
            string queueName,
            bool ifUnused = false,
            bool ifEmpty = false);

        void PurgeQueue(string queueName);
    }
}
