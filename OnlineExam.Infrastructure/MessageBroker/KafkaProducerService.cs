using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Newtonsoft.Json;
using OnlineExam.Domain.Interfaces;

namespace OnlineExam.Infrastructure.MessageBroker
{
    public class KafkaProducerService : IEventPublisher
    {
        private readonly IProducer<string, string> _producer;
        private readonly string _topic;

        // Ensure you're receiving the producer and topic name as constructor parameters
        public KafkaProducerService(IProducer<string, string> producer, string topic)
        {
            // Assign the values passed into the constructor directly to the class-level fields
            var producer1 = producer;
            Console.WriteLine(producer1);
            _producer = producer ?? throw new ArgumentNullException(nameof(producer));
            _topic = topic ?? throw new ArgumentNullException(nameof(topic));
            Console.WriteLine($"KafkaProducerService: producer created: {producer}, topic: {topic}");
        }

        public async Task Publish<T>(T @event) where T : IDomainEvent
        {
            // Serialize the event to JSON and publish it to Kafka
            var eventMessage = JsonConvert.SerializeObject(@event);
            await _producer.ProduceAsync(_topic, new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(), // Unique key
                Value = eventMessage // Event data
            });
        }
    }
}
