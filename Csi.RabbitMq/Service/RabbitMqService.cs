using Csi.RabbitMq.Interface;
using Csi.RabbitMq.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System.Text;
using System.Text.Json;

namespace Csi.RabbitMq.Service;

public class RabbitMqService : IRabbitMqService, IAsyncDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly ILogger<RabbitMqService> _logger;
    private readonly RabbitMqOptions _options;

    public RabbitMqService(IOptions<RabbitMqOptions> options, ILogger<RabbitMqService> logger)
    {
        _logger = logger;
        _options = options.Value;

        var factory = new ConnectionFactory
        {
            HostName = _options.HostName,
            UserName = _options.UserName,
            Password = _options.Password,
            VirtualHost = _options.VirtualHost,
            Port = _options.Port,
            DispatchConsumersAsync = true,
            AutomaticRecoveryEnabled = true
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public async ValueTask PublishAsync<T>(string exchange, string routingKey, T message, IDictionary<string, object>? headers = null, int? delayMs = null)
    {
        try
        {
            var envelope = new RabbitMqEnvelope<T>
            {
                Payload = message,
                Type = typeof(T).Name,
                Timestamp = DateTime.UtcNow
            };

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(envelope));
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;
            properties.Headers = headers ?? new Dictionary<string, object>();

            if (delayMs.HasValue)
            {
                properties.Headers["x-delay"] = delayMs.Value;
            }

            await Task.Yield();
            _channel.BasicPublish(exchange: exchange, routingKey: routingKey, basicProperties: properties, body: body);

            _logger.LogInformation("Published message to {Exchange}/{RoutingKey}", exchange, routingKey);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to publish message to {Exchange}/{RoutingKey}", exchange, routingKey);
            throw;
        }
    }

    public void Subscribe<T>(string queueName, Func<T, Task> handler)
    {
        var args = new Dictionary<string, object>
        {
            { "x-dead-letter-exchange", _options.DeadLetterExchange ?? "dlx.exchange" }
        };

        _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: args);

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.Received += async (sender, ea) =>
        {
            try
            {
                var body = Encoding.UTF8.GetString(ea.Body.ToArray());
                var envelope = JsonSerializer.Deserialize<RabbitMqEnvelope<T>>(body);

                if (envelope.Payload is not null)
                {
                    await handler(envelope.Payload);
                    _channel.BasicAck(ea.DeliveryTag, multiple: false);
                }
                else
                {
                    _logger.LogWarning("Received invalid or null envelope for type {Type}", typeof(T).Name);
                    _channel.BasicNack(ea.DeliveryTag, false, false);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing message from queue {Queue}", queueName);
                _channel.BasicNack(ea.DeliveryTag, false, false);
            }
        };

        _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
        _logger.LogInformation("Subscribed to queue: {Queue}", queueName);
    }

    public bool QueueExists(string queueName)
    {
        try
        {
            _channel.QueueDeclarePassive(queueName);
            return true;
        }
        catch (OperationInterruptedException)
        {
            return false;
        }
    }

    public void DeclareQueue(string queueName, bool durable = true, bool exclusive = false, bool autoDelete = false, IDictionary<string, object>? arguments = null)
    {
        _channel.QueueDeclare(queueName, durable, exclusive, autoDelete, arguments);
        _logger.LogInformation("Declared queue: {Queue}", queueName);
    }

    public void DeleteQueue(string queueName, bool ifUnused = false, bool ifEmpty = false)
    {
        _channel.QueueDelete(queueName, ifUnused, ifEmpty);
        _logger.LogInformation("Deleted queue: {Queue}", queueName);
    }

    public void PurgeQueue(string queueName)
    {
        _channel.QueuePurge(queueName);
        _logger.LogInformation("Purged queue: {Queue}", queueName);
    }

    public ValueTask DisposeAsync()
    {
        try
        {
            _channel?.Close();
            _channel?.Dispose();
            _connection?.Close();
            _connection?.Dispose();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error disposing RabbitMQ connection/channel");
        }

        return ValueTask.CompletedTask;
    }
}

